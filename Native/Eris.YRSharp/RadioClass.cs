using System.Runtime.InteropServices;
using Eris.YRSharp.GeneralDefinitions;
using Eris.YRSharp.GeneralStructures;
using Eris.YRSharp.Helpers;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit, Size = 240)]
public struct RadioClass
{

    public unsafe RadioCommand SendToFirstLink(RadioCommand command)
    {
        var func = (delegate* unmanaged[Thiscall]<ref RadioClass, RadioCommand, RadioCommand>)this.GetVirtualFunctionPointer(157);
        return func(ref this, command);
    }
    public unsafe RadioCommand SendCommand(RadioCommand command, Pointer<TechnoClass> pRecipient)
    {
        var func = (delegate* unmanaged[Thiscall]<ref RadioClass, RadioCommand, IntPtr, RadioCommand>)this.GetVirtualFunctionPointer(158);
        return func(ref this, command, pRecipient);
    }
    public unsafe RadioCommand SendCommandWithData(RadioCommand command, ref Pointer<AbstractClass> pInOut, Pointer<TechnoClass> pRecipient)
    {
        var func = (delegate* unmanaged[Thiscall]<ref RadioClass, RadioCommand, IntPtr, IntPtr, RadioCommand>)this.GetVirtualFunctionPointer(159);
        return func(ref this, command, pInOut.GetThisPointer(), pRecipient);
    }
    public unsafe void SendToEachLink(RadioCommand command)
    {
        var func = (delegate* unmanaged[Thiscall]<ref RadioClass, RadioCommand, void>)this.GetVirtualFunctionPointer(160);
        func(ref this, command);
    }
    public unsafe bool HasAnyLink()
    {
        var func = (delegate* unmanaged[Thiscall]<ref RadioClass, Bool>)0x65AE30;
        return func(ref this);
    }

        
    [FieldOffset(0)] public MissionClass Base;
    [FieldOffset(0)] public ObjectClass BaseObject;
    [FieldOffset(0)] public AbstractClass BaseAbstract;
    [FieldOffset(212)] public RadioCommand LastCommand;
    [FieldOffset(216)] public RadioCommand LastCommand1;
    [FieldOffset(220)] public RadioCommand LastCommand2;
    [FieldOffset(224)] public byte radioLinks;
    public ref Vector<Pointer<TechnoClass>> RadioLinks => ref Pointer<byte>.AsPointer(ref radioLinks).Convert<Vector<Pointer<TechnoClass>>>().Ref;
}