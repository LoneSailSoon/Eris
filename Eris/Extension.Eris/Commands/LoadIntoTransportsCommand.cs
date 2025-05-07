using System.Collections.Generic;
using System.Runtime.InteropServices;
using Eris.Utilities.Helpers;
using Eris.Utilities.Logger;
using PatcherYrSharp;
using PatcherYrSharp.GeneralDefinitions;
using PatcherYrSharp.Helpers;

namespace Eris.Extension.Eris.Commands;

public class LoadIntoTransportsCommand
{
    public static readonly GetNameFunc GetName = static pThis => new AnsiString(Name());
    public static readonly GetUINameFunc GetUiName = static pThis => new UniString(UiName());
    public static readonly GetUINameFunc GetUiDescription = static pThis => new UniString(UiDescription());
    public static readonly ExecuteFunc Execute = ExecuteProxy;



    public static string Name() => "LoadIntoTransportsCommand";

    public static string UiName() => "自动装载单位";


    public static string UiDescription() => "自动装载单位";


    public static void ExecuteProxy(IntPtr pThis, WwKey input)
    {
        if (ObjectClass.CurrentObjects.Count != 0)
        {
            List<Pointer<TechnoClass>> transports = [];
            List<(Pointer<TechnoClass> passenger, bool moving)> passengers = [];

            foreach (var obj in ObjectClass.CurrentObjects)
            {
                if (obj.CastToTechno(out var techno) && !techno.Ref.Base.InLimbo && techno.Ref.Base.Health > 0 && techno.Ref.Owner.Ref.ArrayIndex == HouseClass.Player.Ref.ArrayIndex && techno.Ref.Type is var type)
                {
                    if (
                        type.Ref.Passengers > 0 &&
                        techno.Ref.Passengers.NumPassengers < type.Ref.Passengers &&
                        techno.Ref.Passengers.GetTotalSize() < type.Ref.Passengers)
                    {
                        transports.Add(techno);
                    }
                    else if (techno.Ref.BaseAbstract.WhatAmI() != AbstractType.Aircraft)
                    {
                        passengers.Add((techno, false));
                    }
                }
            }

            if (transports.Count < 0 || passengers.Count < 0)
            {
                return;
            }

            foreach (var transport in transports)
            {
                var type = transport.Ref.Type;
                var empty = type.Ref.Passengers - transport.Ref.Passengers.GetTotalSize();

                for (var i = 0; i < passengers.Count; i++)
                {
                    if (empty <= 0)
                    {
                        break;
                    }

                    var (techno, moving) = passengers[i];
                    if (!moving && techno != transport)
                    {

                        var passengerType = techno.Ref.Type;


                        if (passengerType.Ref.Size > 0
                            && passengerType.Ref.Size <= type.Ref.SizeLimit
                            && passengerType.Ref.Size <= empty)
                        {
                            empty -= (int)passengerType.Ref.Size;
                            passengers[i] = (techno, true);


                            //Console.WriteLine($"{passengerType.Ref.BaseAbstractType.ID} -> {type.Ref.BaseAbstractType.ID}");

                            EventClass @event = new();

                            @event.Type = EventType.Megamission;
                            @event.HouseIndex = (byte)HouseClass.Player.Ref.ArrayIndex;
                            @event.Frame = (uint)Game.CurrentFrame;
                            @event.Data.MegaMission.Whom = new TargetClass().Pack_AbstractClass(techno.Cast<AbstractClass>()).Data;
                            @event.Data.MegaMission.Mission = (byte)Mission.Enter;
                            @event.Data.MegaMission.Destination = new TargetClass().Pack_AbstractClass(transport.Cast<AbstractClass>()).Data;// @event.Data.MegaMission.Target;

                            @event.Data.MegaMission.Follow = new() { m_ID = @event.Data.MegaMission.Destination.m_ID };


                            //@event.EventClass_MegaMission(,s
                            //    , Mission.Enter,s
                            //    , default,
                            //    default);
                            EventClass.AddEvent(@event);
                        }
                    }
                }
            }
        }


    }

    public static void Register()
    {
        Pointer<Pointer<Command>> pVfptr = YRMemory.Allocate(4);

        Pointer<Command> vtable = YRMemory.Allocate(4 * 9);

        vtable.Ref.VTableDTOR = Marshal.GetFunctionPointerForDelegate(CommandBase.DTOR);
        vtable.Ref.VTableGetName = Marshal.GetFunctionPointerForDelegate(GetName);
        vtable.Ref.VTableGetUIName = Marshal.GetFunctionPointerForDelegate(GetUiName);
        vtable.Ref.VTableGetUICategory = Marshal.GetFunctionPointerForDelegate(CommandBase.GetUICategory);
        vtable.Ref.VTableGetUIDescription = Marshal.GetFunctionPointerForDelegate(GetUiDescription);
        vtable.Ref.VTablePreventCombinationOverride =
            Marshal.GetFunctionPointerForDelegate(CommandBase.PreventCombinationOverride);
        vtable.Ref.VTableExtraTriggerCondition =
            Marshal.GetFunctionPointerForDelegate(CommandBase.ExtraTriggerCondition);
        vtable.Ref.VTableCheckLoop55E020 = Marshal.GetFunctionPointerForDelegate(CommandBase.CheckLoop55E020);
        vtable.Ref.VTableExecute = Marshal.GetFunctionPointerForDelegate(Execute);

        pVfptr.Data = vtable;
        CommandClass.ABSTRACTTYPE_ARRAY.Array.AddItem(pVfptr.Convert<CommandClass>());
    }
}