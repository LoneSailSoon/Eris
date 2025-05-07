using Eris.Utilities.Helpers;
using Eris.Utilities.Logger;
using Eris.Utilities.Network;
using PatcherYrSharp;
using PatcherYrSharp.GeneralDefinitions;
using PatcherYrSharp.GeneralStructures;
using PatcherYrSharp.Helpers;
using PatcherYrSharp.Utilities;

namespace Eris.Ui.NaegleriaUi;

public partial class NaegleriaUiMissionManager
{
    public static List<NaegleriaUiMissionEventArg> DoList = [];
    public static string? LastMission = null;

    public static string? AddMission(string data)
    {
        string trimData = data.Trim();
        if (trimData == "/" && null != LastMission)
        {
            trimData = LastMission;
        }

        if (trimData.StartsWith('/') && null != LastMission)
        {
            trimData = LastMission.Split('/')[0].Trim() + data;
        }

        Parse(trimData, out var result, ref LastMission, out var arg);
        if (null == result)
        {
            DoList.Add(arg);
        }
        
        //return false;
        return result;
    }

    public static void Parse(string data, out string? result, ref string? lastMission,
        out NaegleriaUiMissionEventArg value)
    {
        value = default;
        var missionPart = data.Split('/')[0].Trim().ToLower();
        if (TryFindIndex(missionPart, out var missionIndex))
        {
            string? ex = null;
            try
            {
                if (null == (ex = GetMission(missionIndex).Parser
                        .Invoke(data, out var vals)))
                {
                    value = vals;
                    value.MissionIndex = missionIndex;

                    //DoList.Add(this);

                    LastMission = data;
                }
            }
            catch (Exception e)
            {
                Logger.LogException(e);
            }

            result = ex;
            return;
        }

        result = "";
    }

    public static void Run(NaegleriaUiMissionEventArg value)
    {
        var mission = GetMission(value.MissionIndex);

        if (mission.ForEach)
        {
            var count = ObjectClass.CurrentObjects.Count;
            for (var i = count-1; i >= 0; i--)
            {
                Pointer<ObjectClass> pObject;
                if ((pObject = ObjectClass.CurrentObjects.Get(i)).IsNotNull)
                {
                    var pNetId = new TargetClass(pObject.Convert<AbstractClass>());
                    value.Value1 = pNetId.m_ID;

                    NaegleriaUiMissionNetworkHandle.Send(0x92, value);
                    //OnMission(mission, value);
                    //EventHandlerBase<ConsoleMissionEventArg>.Create(0x92, Value);
                }
            }
        }
        else
        {
            NaegleriaUiMissionNetworkHandle.Send(0x92, value);
            //OnMission(mission, value);
            //EventHandlerBase<ConsoleMissionEventArg>.Create(0x92, Value);
        }
    }

    public static void Running()
    {
        if (DoList.Count != 0)
        {
            DoList.ForEach(Run);
            DoList.Clear();
        }
    }

    /// <summary>
    /// 来自JacobYoung的AttackLaserBlit2D.cs
    /// </summary>
    /// <param name="client"></param>
    /// <returns></returns>
    public static CoordStruct ClientToCoord(Point2D client)
    {
        CoordStruct pos = TacticalClass.Instance.ClientToCoords(client);
        // Logger.Log($"[DEBUG] pos: {pos.X}, {pos.Y}, {pos.Z}");
        if (MapClass.Instance.TryGetCellAt(pos, out var pCell))
        {
            pos.Z = pCell.Ref.Base.GetCoords().Z; // 手动修正地形高度
            if (pCell.Ref.ContainsBridge())
            {
                pos.Z += Game.BridgeHeight; // 手动修正桥面高度
            }

            int layerFix = pos.Z / 104 * 128;
            pos.X += layerFix;
            pos.Y += layerFix;
        }

        if (MapClass.Instance.TryGetCellAt(pos, out var pCell2))
        {
            pos.Z = pCell2.Ref.Base.GetCoords().Z; // 手动修正地形高度
            if (pCell2.Ref.ContainsBridge())
            {
                pos.Z += Game.BridgeHeight; // 手动修正桥面高度
            }
        }

        CoordStruct posTemp = pos;
        posTemp.Z = 0;
        Point2D p2DTemp;

        for (int i = 0; i < 8; i++) // 向SE方向扫描8次，以应对屏幕二维点地形很高而获取到的格子地形很低，即悬崖遮挡问题
        {
            posTemp.X += 128;
            posTemp.Y += 128;

            if (MapClass.Instance.TryGetCellAt(posTemp, out var pCell3))
            {
                posTemp.Z = pCell3.Ref.Base.GetCoords().Z; // 手动修正地形高度
                if (pCell3.Ref.ContainsBridge())
                {
                    posTemp.Z += Game.BridgeHeight; // 手动修正桥面高度
                }
            }

            p2DTemp = TacticalClass.Instance.CoordsToClient(posTemp);

            if (Math.Pow(p2DTemp.X - client.X, 2.0) + Math.Pow(p2DTemp.Y - client.Y, 2.0) < 400)
            {
                pos = posTemp;
            }
        }

        return pos;
    }

    public static void OnMission(in NaegleriaUiMissionData e, in NaegleriaUiMissionEventArg value)
    {
        HouseIndex = HouseClass.Player.Ref.ArrayIndex;
        e.Handler(value);
        HouseIndex = -1;
    }


    private static void KillMission(NaegleriaUiMissionEventArg arg)
    {
        Pointer<ObjectClass> pObject = new TargetClass() { m_ID = arg.Value1, m_RTTI = (byte)AbstractType.Abstract }
            .UNPACK_Abstract().Cast<ObjectClass>();
        pObject.Ref.TakeDamage(pObject.Ref.Health + 1, pObject.Ref.GetTechnoType().AsNullable?.Ref.Crewed ?? false);
    }

    private static string? KillMissionParser(string val, out NaegleriaUiMissionEventArg data)
    {
        data = default;
        if (ObjectClass.CurrentObjects.Count <= 0) return "[提示] 需要先选中单位再执行此命令";
        return null;
    }

    private static void RemoveMission(NaegleriaUiMissionEventArg arg)
    {
        Pointer<ObjectClass> pObject = new TargetClass() { m_ID = arg.Value1, m_RTTI = (byte)AbstractType.Abstract }
            .UNPACK_Abstract().Cast<ObjectClass>();
        pObject.Ref.Remove();
        pObject.Ref.UnInit();
    }

    private static string? RemoveMissionParser(string val, out NaegleriaUiMissionEventArg data)
    {
        data = default;
        if (ObjectClass.CurrentObjects.Count <= 0) return "[提示] 需要先选中单位再执行此命令";

        return null;
    }

    private static void ExpMission(NaegleriaUiMissionEventArg arg)
    {
        Pointer<ObjectClass> pObject = new TargetClass() { m_ID = arg.Value1, m_RTTI = (byte)AbstractType.Abstract }
            .UNPACK_Abstract().Cast<ObjectClass>();
        if (pObject.CastToTechno(out var pTechno))
        {
            pTechno.Ref.Veterancy.Add(arg.Value2 / (double)pTechno.Ref.Type.Ref.Cost);
        }
    }

    private static string? ExpMissionParser(string val, out NaegleriaUiMissionEventArg data)
    {
        var list = val.Split('/');
        data = default;
        if (ObjectClass.CurrentObjects.Count <= 0) return "[提示] 需要先选中单位再执行此命令";

        if (list.Length >= 2 && int.TryParse(list[1].Trim(), out var exp))
        {
            data.Value2 = exp;
        }
        else
        {
            return "[提示] 请输入参数作为单位获取的经验值";
        }

        return null;
    }

    private static void OwnMission(NaegleriaUiMissionEventArg arg)
    {
        if (new TargetClass { m_ID = arg.Value1, m_RTTI = (byte)AbstractType.Abstract }.UNPACK_Abstract()
            .CastToTechno(out var pTechno))
        {
            Pointer<HouseClass> pHouse;
            if (pTechno.Ref.Owner != (pHouse = HouseClass.Array.Get(HouseIndex)))
            {
                pTechno.Ref.SetOwningHouse(pHouse);
                if (pTechno.CastIf<BuildingClass>(AbstractType.Building, out var pBid))
                {
                    pBid.Ref.UpdateAnimations();
                }
            }
        }
    }

    private static string? OwnMissionParser(string val, out NaegleriaUiMissionEventArg data)
    {
        data = default;
        if (ObjectClass.CurrentObjects.Count <= 0) return "[提示] 需要先选中单位再执行此命令";
        return null;
    }

    //private static void GiveSWMission(NaegleriaUiMissionEventArg value)
    //{
    //    if (value.Value1 >= 0)
    //    {
    //        Pointer<HouseClass> pHouse = HouseClass.Array[HouseIndex];
    //        pHouse.Ref.Supers[value.Value1].Ref.Grant(false, false, false);
    //        pHouse.Ref.Supers[value.Value1].Ref.CanHold = false;
    //        pHouse.Ref.Supers[value.Value1].Ref.IsCharged = true;
    //        if (HouseClass.Player == pHouse)
    //        {
    //            SidebarClass.pInstance.Ref.AddCameo(AbstractType.Special, value.Value1);
    //            int objectTabIdx0 = SidebarClass.GetObjectTabIdx(AbstractType.Special, value.Value1, 0);

    //            SidebarClass.pInstance.Ref.RepaintSidebar(objectTabIdx0);

    //        }

    //    }
    //}

    //private static string? GiveSWMissionParser(string val, out NaegleriaUiMissionEventArg data)
    //{
    //    var list = val.Split('/');
    //    string temp;
    //    data = default;
    //    if (list.Length >= 2 && !string.IsNullOrWhiteSpace(temp = list[1].Trim()))
    //    {
    //        data.Value1 = SuperWeaponTypeClass.AbstractTypeArray.Find(temp, StringComparer.OrdinalIgnoreCase).AsNullable?.Ref.ArrayIndex ?? -1;
    //        if (data.Value1 == -1)
    //        {
    //            return $"[错误] 未找到超级武器 ： {list[1].Trim()}";

    //        }
    //    }
    //    else
    //    {
    //        return "[提示] 请输入参数作为玩家获取的超级武器";
    //    }
    //    return null;
    //}

    private static void MoneyMission(NaegleriaUiMissionEventArg value)
    {
        CurrentHouse.Ref.TransactMoney(value.Value1);
    }

    private static string? MoneyMissionParser(string val, out NaegleriaUiMissionEventArg data)
    {
        var list = val.Split('/');
        data = default;
        if (list.Length >= 2 && int.TryParse(list[1].Trim(), out var money))
        {
            data.Value1 = money;
        }
        else
        {
            return "[提示] 请输入参数作为玩家获取的资金";
        }

        return null;
    }

    // private static void ConvertMission(ConsoleMissionEventArg value)
    // {
    //     Pointer<TechnoClass> pTechno;
    //     Pointer<TechnoTypeClass> pType;
    //     if (value.Value2 >= 0
    //         && (pTechno = new TargetClass() { m_ID = value.Value1, m_RTTI = (byte)AbstractType.Abstract }.UNPACK_Abstract().Cast<TechnoClass>()).IsNotNull
    //         && (pType = TechnoTypeClass.AbstractTypeArray.Array.Get(value.Value2)).IsNotNull
    //         && pTechno.Ref.Type.Ref.Locomotor == pType.Ref.Locomotor)
    //     {
    //         AresFunctions.ConvertTypeTo(pTechno, pType);
    //     }
    // }
    //
    // private static string? ConvertMissionParser(string val, out ConsoleMissionEventArg data)
    // {
    //     var list = val.Split('/');
    //     string temp;
    //     data = default;
    //     if (ObjectClass.CurrentObjects.Count <= 0) return "[提示] 需要先选中单位再执行此命令";
    //     if (list.Length >= 2 && !string.IsNullOrWhiteSpace(temp = list[1].Trim()))
    //     {
    //         int id = TechnoTypeClass.AbstractTypeArray.OldFindIndex(temp, true);
    //         if (id < 0) return $"[错误] 未找到单位类型 : {list[1].Trim()} ";
    //         data.Value2 = id;
    //
    //     }
    //     else
    //     {
    //         return "[提示] 请输入参数作为单位变形的对象";
    //     }
    //
    //     return null;
    // }

    private static void CreateMission(NaegleriaUiMissionEventArg value)
    {
        try
        {
            var animType = AnimTypeClass.AbstractTypeArray["NUKEBALL"];
            if (animType)
            {
                YrCreater.Create<AnimClass>().Constructor(animType, MapClass.Instance.Cells[value.Value2].Ref.GetCenterCoords());
            }
            Pointer<CellClass> pCell;
            Pointer<TechnoTypeClass> pType;
            if ((pCell = MapClass.Instance.Cells[value.Value2]).IsNotNull
                && (pType = TechnoTypeClass.AbstractTypeArray[value.Value1]).IsNotNull)
            {
                for (int i = 0; i < value.Value3; i++)
                {
                    TechnoPlacer.PlaceTechnoNear(pType, CurrentHouse, CellClass.Coord2Cell(pCell.Ref.GetCenterCoords()), true);
                }
            }
        }
        catch (Exception e)
        {
            Logger.LogException(e);
        }
    }
    
    private static string? CreateMissionParser(string val, out NaegleriaUiMissionEventArg data)
    {
        var list = val.Split('/');
        string temp;
        data = default;
        if (list.Length >= 2 && !string.IsNullOrWhiteSpace(temp = list[1].Trim()))
        {
            int id = TechnoTypeClass.AbstractTypeArray.FindIndex(temp, StringComparer.OrdinalIgnoreCase);
            if (id < 0) return $"[错误] 未找到单位类型 : {temp} ";
            byte count = 1;
            if (list.Length >= 3 && !string.IsNullOrWhiteSpace(temp = list[2].Trim()) && byte.TryParse(temp, out var i))
            {
                count = i;
            }
            data.Value1 = id;
            data.Value2 = MapClass.GetCellIndex(CellClass.Coord2Cell(ClientToCoord(WWMouseClass.Instance.GetCoords())));
            data.Value3 = count;
        }
        else
        {
            return "[提示] 请输入参数作为将要创建的单位类型";
        }
    
    
        return null;
    }

    private static void LaunchSWMission(NaegleriaUiMissionEventArg value)
    {
        Pointer<CellClass> pCell;
        Pointer<SuperClass> pSuper;
        if (value.Value1 >= 0
            && (pSuper = CurrentHouse.Ref.Supers[value.Value1]).IsNotNull
            && (pCell = MapClass.Instance.Cells[value.Value2]).IsNotNull)
        {
            pSuper.Ref.IsCharged = true;
            pSuper.Ref.Launch(pCell.Ref.MapCoords, true);
            pSuper.Ref.IsCharged = false;
        }
    }

    private static string? LaunchSWMissionParser(string val, out NaegleriaUiMissionEventArg data)
    {
        var list = val.Split('/');
        string temp;
        data = default;
        if (list.Length >= 2 && !string.IsNullOrWhiteSpace(temp = list[1].Trim()))
        {
            data.Value1 = SuperWeaponTypeClass.AbstractTypeArray.Find(temp, StringComparer.OrdinalIgnoreCase).AsNullable?.Ref.ArrayIndex ?? -1;
            data.Value2 = MapClass.GetCellIndex(CellClass.Coord2Cell(ClientToCoord(WWMouseClass.Instance.GetCoords())));
            if (data.Value1 < 0) return $"[错误] 未找到超级武器类型 : {temp} ";
        }
        else
        {
            return "[提示] 请输入参数作为将要释放的超级武器";
        }

        return null;
    }


    private static void DetonateMission(NaegleriaUiMissionEventArg value)
    {
        Pointer<CellClass> pCell;
        Pointer<WeaponTypeClass> pWeapon;
        if (value.Value1 >= 0
            && (pWeapon = WeaponTypeClass.AbstractTypeArray[value.Value1]).IsNotNull
            && (pCell = MapClass.Instance.Cells[value.Value2]).IsNotNull)
        {
            Pointer<BulletTypeClass> pType = pWeapon.Ref.Projectile;
            Pointer<BulletClass> pBullet = pType.Ref.CreateBullet(pCell.Convert<AbstractClass>(), nint.Zero,
                pWeapon.Ref.Damage, pWeapon.Ref.Warhead, 0, pWeapon.Ref.Bright);
            if (pBullet.IsNotNull)
            {
                pBullet.Ref.MoveTo(pCell.Ref.GetCenterCoords(), new BulletVelocity(0, 0, 1)); //Limbo();
                pBullet.Ref.Base.SetLocation(pCell.Ref.GetCenterCoords());
                pBullet.Ref.Fire(true);
                pBullet.Ref.Base.UnInit();
            }
        }
    }

    private static string? DetonateMissionParser(string val, out NaegleriaUiMissionEventArg data)
    {
        var list = val.Split('/');
        string temp;
        data = default;

        if (list.Length >= 2 && !string.IsNullOrWhiteSpace(temp = list[1].Trim()))
        {
            if (MapClass.Instance.TryGetCellAt(ClientToCoord(WWMouseClass.Instance.GetCoords()),
                    out Pointer<CellClass> pCell))
            {
                 var weaponIndex = WeaponTypeClass.AbstractTypeArray.FindIndex(temp, StringComparer.OrdinalIgnoreCase);
                 data.Value1 = weaponIndex;
                data.Value2 = MapClass.GetCellIndex(pCell.Ref.MapCoords);
                if (data.Value1 < 0) return $"[错误] 未找到武器类型 : {temp} ";
            }
        }
        else
        {
            return "[提示] 请输入参数作为将要发射的武器";
        }

        return null;
    }

    private static void DetonateEachMission(NaegleriaUiMissionEventArg value)
    {
        Pointer<ObjectClass> pObject = new TargetClass() { m_ID = value.Value1, m_RTTI = (byte)AbstractType.Abstract }
            .UNPACK_Abstract().Cast<ObjectClass>();
        Pointer<WeaponTypeClass> pWeapon;
        if (pObject.CastToTechno(out var pTechno) &&
            (pWeapon = WeaponTypeClass.AbstractTypeArray[value.Value2]).IsNotNull)
        {
            Pointer<BulletTypeClass> pType = pWeapon.Ref.Projectile;
            Pointer<BulletClass> pBullet = pType.Ref.CreateBullet(pTechno.Convert<AbstractClass>(), IntPtr.Zero,
                pWeapon.Ref.Damage, pWeapon.Ref.Warhead, 0, pWeapon.Ref.Bright);
            if (pBullet.IsNotNull)
            {
                pBullet.Ref.MoveTo(pTechno.Ref.BaseAbstract.GetCoords(), new BulletVelocity(0, 0, 1)); //Limbo();
                pBullet.Ref.Base.SetLocation(pTechno.Ref.BaseAbstract.GetCoords());
                pBullet.Ref.Fire(true);
                pBullet.Ref.Base.UnInit();
            }
        }
    }

    private static string? DetonateEachMissionParser(string val, out NaegleriaUiMissionEventArg data)
    {
        var list = val.Split('/');
        string temp;
        data = default;
        if (ObjectClass.CurrentObjects.Count <= 0) return "[提示] 需要先选中单位再执行此命令";

        if (list.Length >= 2 && !string.IsNullOrWhiteSpace(temp = list[1].Trim()))
        {
            data.Value2 = WeaponTypeClass.AbstractTypeArray.FindIndex(temp, StringComparer.OrdinalIgnoreCase);
        }
        else
        {
            return "[提示] 请输入参数作为将要发射的武器";
        }

        return null;
    }


    private static void MissionMission(NaegleriaUiMissionEventArg value)
    {
        Pointer<ObjectClass> pObject = new TargetClass() { m_ID = value.Value1, m_RTTI = (byte)AbstractType.Abstract }
            .UNPACK_Abstract().Cast<ObjectClass>();
        if (pObject.CastToTechno(out var pTechno))
        {
            pTechno.Ref.BaseMission.ForceMission((Mission)(value.Value2));
        }
    }

    private static string? MissionMissionParser(string val, out NaegleriaUiMissionEventArg data)
    {
        var list = val.Split('/');
        string temp;
        data = default;
        if (ObjectClass.CurrentObjects.Count <= 0) return "[提示] 需要先选中单位再执行此命令";

        if (list.Length >= 2 && !string.IsNullOrWhiteSpace(temp = list[1].Trim()))
        {
            data.Value2 = (int)Enum.Parse(typeof(Mission), temp, true);
        }
        else
        {
            return "[提示] 请输入参数作为单位将要执行的任务";
        }

        return null;
    }

    private static void ICMission(NaegleriaUiMissionEventArg value)
    {
        Pointer<ObjectClass> pObject = new TargetClass() { m_ID = value.Value1, m_RTTI = (byte)AbstractType.Abstract }
            .UNPACK_Abstract().Cast<ObjectClass>();
        if (pObject.CastToTechno(out var pTechno))
        {
            pTechno.Ref.Base.IronCurtain(value.Value2, pTechno.Ref.Owner, false);
        }
    }

    private static string? ICMissionParser(string val, out NaegleriaUiMissionEventArg data)
    {
        var list = val.Split('/');
        data = default;
        if (ObjectClass.CurrentObjects.Count <= 0) return "[提示] 需要先选中单位再执行此命令";

        if (list.Length >= 2 && int.TryParse(list[1].Trim(), out var duration))
        {
            data.Value2 = duration;
        }
        else
        {
            return "[提示] 请输入参数作为单位将要附加铁幕的时长";
        }

        return null;
    }

    private static void HealthMission(NaegleriaUiMissionEventArg value)
    {
        Pointer<ObjectClass> pObject = new TargetClass() { m_ID = value.Value1, m_RTTI = (byte)AbstractType.Abstract }
            .UNPACK_Abstract().Cast<ObjectClass>();
        if (pObject.CastToTechno(out var pTechno))
        {
            if (value.Value2 < 0 && pObject.Ref.Health <= -value.Value2)
            {
                pObject.Ref.TakeDamage(pObject.Ref.Health + 1,
                    pObject.Ref.GetTechnoType().AsNullable?.Ref.Crewed ?? false);
                return;
            }

            if ((pObject.Ref.Health += value.Value2) > pTechno.Ref.Type.Ref.Base.Strength)
            {
                pObject.Ref.Health = pTechno.Ref.Type.Ref.Base.Strength;
            }
        }
    }

    private static string? HealthMissionParser(string val, out NaegleriaUiMissionEventArg data)
    {
        var list = val.Split('/');
        data = default;
        if (ObjectClass.CurrentObjects.Count <= 0) return "[提示] 需要先选中单位再执行此命令";

        if (list.Length >= 2 && int.TryParse(list[1].Trim(), out var value))
        {
            data.Value2 = value;
        }
        else
        {
            return "[提示] 请输入参数作为单位将要修改的血量";
        }

        return null;
    }
}

public class NaegleriaUiMissionNetworkHandle : NetworkHandle<NaegleriaUiMissionEventArg>
{
    public override byte Index => 0x92;
    public override uint Lenth => 24;
    public override string Name  => "ConsoleMission";
    protected override void Respond(Pointer<EventClass> pEvent, Pointer<NaegleriaUiMissionEventArg> pArg)
    {
        var mission = NaegleriaUiMissionManager.GetMission(pArg.Ref.MissionIndex);
        
        NaegleriaUiMissionManager.HouseIndex = HouseClass.Player.Ref.ArrayIndex;
        mission.Handler(pArg.Data);
        NaegleriaUiMissionManager.HouseIndex = -1;
    }
}