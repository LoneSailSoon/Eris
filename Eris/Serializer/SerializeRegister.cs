using Eris.Component.Generic;
using Eris.Entity;

namespace Eris.Serializer;

public static class SerializeRegister
{
    public const int TechnoTypeEntitySerializeType = 1;
    public const int TechnoEntitySerializeType = 2;
    public const int CellEntitySerializeType = 3;
    public const int BulletTypeEntitySerializeType = 4;
    public const int BulletEntitySerializeType = 5;
    public const int HouseTypeEntitySerializeType = 6;
    public const int HouseEntitySerializeType = 7;
    public const int SuperWeaponTypeEntitySerializeType = 8;
    public const int SuperWeaponEntitySerializeType = 9;
    public const int WarheadTypeEntitySerializeType = 10;
    public const int WeaponTypeEntitySerializeType = 11;
    public const int GameObjectType = 12;


    public static void Register()
    {
        BeonSerializer.DeserializeObjectActivator.Register(TechnoTypeEntitySerializeType, static () => new TechnoTypeEntity());
        BeonSerializer.DeserializeObjectActivator.Register(TechnoEntitySerializeType, static () => new TechnoEntity());
        BeonSerializer.DeserializeObjectActivator.Register(CellEntitySerializeType, static () => new CellEntity());
        BeonSerializer.DeserializeObjectActivator.Register(BulletTypeEntitySerializeType, static () => new BulletTypeEntity());
        BeonSerializer.DeserializeObjectActivator.Register(BulletEntitySerializeType, static () => new BulletEntity());
        BeonSerializer.DeserializeObjectActivator.Register(HouseTypeEntitySerializeType, static () => new HouseTypeEntity());
        BeonSerializer.DeserializeObjectActivator.Register(HouseEntitySerializeType, static () => new HouseEntity());
        BeonSerializer.DeserializeObjectActivator.Register(SuperWeaponTypeEntitySerializeType, static () => new SWTypeEntity());
        BeonSerializer.DeserializeObjectActivator.Register(SuperWeaponEntitySerializeType, static () => new SuperWeaponEntity());
        BeonSerializer.DeserializeObjectActivator.Register(WarheadTypeEntitySerializeType, static () => new WarheadTypeEntity());
        BeonSerializer.DeserializeObjectActivator.Register(WeaponTypeEntitySerializeType, static () => new WeaponTypeEntity());
        BeonSerializer.DeserializeObjectActivator.Register(GameObjectType, static () => new GameObject());
    }
}