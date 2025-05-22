using Eris.Extension.Core.Generic;
using Eris.Extension.Core.Style;
using Eris.Extension.Core.Style.Modules.Behavior;
using Eris.Extension.Core.Style.Modules.DamageSelf;
using NaegleriaSerializer;

namespace Eris.Serializer;

public static class SerializeRegister
{
    public const int TechnoTypeExtSerializeType = 1;
    public const int TechnoExtSerializeType = 2;
    public const int CellExtSerializeType = 3;
    public const int BulletTypeExtSerializeType = 4;
    public const int BulletExtSerializeType = 5;
    public const int HouseTypeExtSerializeType = 6;
    public const int HouseExtSerializeType = 7;
    public const int SuperWeaponTypeExtSerializeType = 8;
    public const int SuperWeaponExtSerializeType = 9;
    public const int WarheadTypeExtSerializeType = 10;
    public const int WeaponTypeExtSerializeType = 11;
    public const int StyleTypeType = 12;
    public const int StyleInstanceType = 13;
    public const int GameObjectType = 14;
    public const int StyleStateModuleType = 15;
    public const int DamageSelfModuleType = 16;
    public const int DamageSelfModuleDataType = 17;
    public const int DestroySelfStateType = 18;
    public const int DestroySelfDataType = 19;
    public const int BehaviorMoudleType = 20;
    public const int BehaviorMoudleDataType = 21;


    public static void Register()
    {
        DeserializeObjectActivator.Register(TechnoTypeExtSerializeType, static () => new Extension.TechnoTypeExt());
        DeserializeObjectActivator.Register(TechnoExtSerializeType, static () => new Extension.TechnoExt());
        DeserializeObjectActivator.Register(CellExtSerializeType, static () => new Extension.CellExt());
        DeserializeObjectActivator.Register(BulletTypeExtSerializeType, static () => new Extension.BulletTypeExt());
        DeserializeObjectActivator.Register(BulletExtSerializeType, static () => new Extension.BulletExt());
        DeserializeObjectActivator.Register(HouseTypeExtSerializeType, static () => new Extension.HouseTypeExt());
        DeserializeObjectActivator.Register(HouseExtSerializeType, static () => new Extension.HouseExt());
        DeserializeObjectActivator.Register(SuperWeaponTypeExtSerializeType, static () => new Extension.SWTypeExt());
        DeserializeObjectActivator.Register(SuperWeaponExtSerializeType, static () => new Extension.SuperWeaponExt());
        DeserializeObjectActivator.Register(WarheadTypeExtSerializeType, static () => new Extension.WarheadTypeExt());
        DeserializeObjectActivator.Register(WeaponTypeExtSerializeType, static () => new Extension.WeaponTypeExt());
        DeserializeObjectActivator.Register(StyleTypeType, static () => new StyleType());
        DeserializeObjectActivator.Register(StyleInstanceType, static () => new StyleInstance());
        DeserializeObjectActivator.Register(GameObjectType, static () => new GameObject());
        DeserializeObjectActivator.Register(StyleStateModuleType, static () => new StyleStateManager());
        DeserializeObjectActivator.Register(DamageSelfModuleType, static () => new DamageSelfModule());
        DeserializeObjectActivator.Register(DamageSelfModuleDataType, static () => new DamageSelfModuleData());
        DeserializeObjectActivator.Register(DestroySelfStateType, static () => new BehaviorMoudle());
        DeserializeObjectActivator.Register(DestroySelfDataType, static () => new BehaviorMoudleData());
    }
}