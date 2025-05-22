using System.Runtime.InteropServices;
using Eris.YRSharp.GeneralDefinitions;
using Eris.YRSharp.Helpers;
using Eris.YRSharp.Vector;

namespace Eris.YRSharp;

    [StructLayout(LayoutKind.Explicit, Size = 5)]
    public struct TargetClass
    {
        [FieldOffset(0)] public int m_ID;
        [FieldOffset(4)] public byte m_RTTI;

        public TargetClass(Pointer<AbstractClass> toPack)
        {
            m_ID = 0;
            m_RTTI = 0;
            Pack_AbstractClass(toPack);
        }
        public TargetClass(CellStruct toPack)
        {
            m_ID = 0;
            m_RTTI = 0;
            Pack_CellStruct(toPack);
        }

        public TargetClass(Point2D toPack)
        {
            m_ID = 0;
            m_RTTI = 0;
            Pack_Point2D(toPack);
        }

        public unsafe Pointer<TargetClass> Pack_AbstractClass(Pointer<AbstractClass> toPack)
        {
            var func = (delegate* unmanaged[Thiscall]<nint, nint, nint>)0x6E6AB0;
            return func(this.GetThisPointer(), toPack);
        }

        public unsafe Pointer<TargetClass> Pack_CellStruct(CellStruct toPack)
        {
            var func = (delegate* unmanaged[Thiscall]<nint, nint, nint>)0x6E6B20;
            return func(this.GetThisPointer(), toPack.GetThisPointer());
        }

        public unsafe Pointer<TargetClass> Pack_Point2D(Point2D toPack)
        {
            var func = (delegate* unmanaged[Thiscall]<nint, nint, nint>)0x6E6B70;
            return func(this.GetThisPointer(), toPack.GetThisPointer());
        }

        public unsafe nint Unpack(int address)
        {
            var func = (delegate* unmanaged[Thiscall]<nint, nint>)address;
            return func(this.GetThisPointer());
        }

        public Pointer<AbstractTypeClass> UNPACK_AbstractType() => Unpack(0x6E6BB0);
        public Pointer<AbstractClass> UNPACK_Abstract() => Unpack(0x6E6E20);
        public Pointer<TechnoClass> UNPACK_Techno() => Unpack(0x6E6F20);
        public Pointer<ObjectClass> UNPACK_Object() => Unpack(0x6E6FF0);
        public Pointer<FootClass> UNPACK_Foot() => Unpack(0x6E70C0);
        public Pointer<HouseClass> UNPACK_House() => Unpack(0x6E7260);
        public Pointer<TechnoTypeClass> UNPACK_TechnoType() => Unpack(0x6E7330);
        //public Pointer<TerrainClass> UNPACK_Terrain() => UNPACK(0x6E75A0);
        public Pointer<BulletClass> UNPACK_Bullet() => Unpack(0x6E7670);
        public Pointer<AnimClass> UNPACK_Anim() => Unpack(0x6E7740);
        public Pointer<InfantryClass> UNPACK_Infantry() => Unpack(0x6E78E0);
        public Pointer<UnitClass> UNPACK_Unit() => Unpack(0x6E79B0);
        public Pointer<BuildingClass> UNPACK_Building() => Unpack(0x6E7A80);
        public Pointer<AircraftClass> UNPACK_Aircraft() => Unpack(0x6E7B50);
        public Pointer<CellClass> UNPACK_Cell() => Unpack(0x6E7C20);

    public override string ToString()
    {
        return $"{(AbstractType)m_RTTI} : {m_ID}";
    }
}
