using System.Runtime.InteropServices;
using Eris.YRSharp;
using Eris.YRSharp.GeneralDefinitions;
using Eris.YRSharp.Helpers;

namespace Eris.Utilities.Helpers;

[StructLayout(LayoutKind.Sequential)]
public struct TypeId
{
    private int _index;
    private byte _type;

    public TypeId(int index, byte type)
    {
        _index = index;
        _type = type;
    }

    public TypeId(int index, AbstractType type)
    {
        _index = index;
        _type = (byte)type;
    }

    public TypeId(Pointer<TechnoTypeClass> type)
    {
        var abs = type.Ref.BaseAbstractType.Base.WhatAmI();
        _index = abs switch
        {
            AbstractType.BuildingType => type.Convert<BuildingTypeClass>().Ref.ArrayIndex,
            AbstractType.AircraftType => type.Convert<AircraftTypeClass>().Ref.ArrayIndex,
            AbstractType.InfantryType => type.Convert<InfantryTypeClass>().Ref.ArrayIndex,
            AbstractType.UnitType => type.Convert<UnitTypeClass>().Ref.ArrayIndex,
            _ => -1
        };
        _type = (byte)abs;
    }

    public TypeId(Pointer<SuperWeaponTypeClass> type)
    {
        _type = (byte)AbstractType.SuperWeaponType;
        _index = type.Ref.ArrayIndex;
    }
    
    public AbstractType Type => (AbstractType)_type;
    
    public Pointer<TechnoTypeClass> ToTechnoType => ObjectClass.GetTechnoType((AbstractType)_type, _index);
    public Pointer<SuperWeaponTypeClass> ToSuperWaponType => SuperWeaponTypeClass.AbstractTypeArray[_index];
    public Pointer<WeaponTypeClass> ToWeaponType => WeaponTypeClass.AbstractTypeArray[_index];
    public Pointer<WarheadTypeClass> ToWarheadType => WarheadTypeClass.AbstractTypeArray[_index];
    public Pointer<BulletClass> ToBulletClass => BulletClass.Array[_index];
}