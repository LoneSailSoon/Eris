using System.Runtime.InteropServices;
using PatcherYrSharp.GeneralDefinitions;
using PatcherYrSharp.GeneralStructures;
using PatcherYrSharp.Helpers;

namespace PatcherYrSharp;

    [StructLayout(LayoutKind.Explicit, Size = 36)]
    public struct AbstractClass
    {
        public const nint ArrayPointer = 0xA8E360;
        public static ref DynamicVectorClass<Pointer<ObjectClass>> Array => ref DynamicVectorClass<Pointer<ObjectClass>>.GetDynamicVector(ArrayPointer);

        public unsafe void Init()
        {
            var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(9);
            func(this.GetThisPointer());
        }
        public unsafe void PointerExpired(Pointer<AbstractClass> pAbstract, bool removed)
        {
            var func = (delegate* unmanaged[Thiscall]<nint, nint, bool, void>)this.GetVirtualFunctionPointer(10);
            func(this.GetThisPointer(), pAbstract, removed);
        }
        public unsafe AbstractType WhatAmI()
        {
            var func = (delegate* unmanaged[Thiscall]<nint, AbstractType>)this.GetVirtualFunctionPointer(11);
            return func(this.GetThisPointer());
        }
        public unsafe int Size()
        {
            var func = (delegate* unmanaged[Thiscall]<nint, int>)this.GetVirtualFunctionPointer(12);
            return func(this.GetThisPointer());
        }
        public unsafe void CalculateChecksum(Pointer<Checksummer> checksum)
        {
            var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)this.GetVirtualFunctionPointer(13);
            func(this.GetThisPointer(), checksum);
        }
        public unsafe int GetOwningHouseIndex()
        {
            var func = (delegate* unmanaged[Thiscall]<nint, int>)this.GetVirtualFunctionPointer(14);
            return func(this.GetThisPointer());
        }
        public unsafe Pointer<HouseClass> GetOwningHouse()
        {
            var func = (delegate* unmanaged[Thiscall]<nint, nint>)this.GetVirtualFunctionPointer(15);
            return func(this.GetThisPointer());
        }
        public unsafe int GetArrayIndex()
        {
            var func = (delegate* unmanaged[Thiscall]<nint, int>)this.GetVirtualFunctionPointer(16);
            return func(this.GetThisPointer());
        }
        public unsafe bool IsDead()
        {
            var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(17);
            return func(this.GetThisPointer());
        }
        public unsafe CoordStruct GetCoords()
        {
            var func = (delegate* unmanaged[Thiscall]<nint, nint, nint>)this.GetVirtualFunctionPointer(18);

            CoordStruct ret = default;
            func(this.GetThisPointer(), Pointer<CoordStruct>.AsPointer(ref ret));
            return ret;
        }
        public unsafe CoordStruct GetDestination(Pointer<TechnoClass> pDocker = default)
        {
            var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, nint>)this.GetVirtualFunctionPointer(19);

            CoordStruct ret = default;
            func(this.GetThisPointer(), Pointer<CoordStruct>.AsPointer(ref ret), pDocker);
            return ret;
        }
        public unsafe bool IsOnFloor()
        {
            var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(20);
            return func(this.GetThisPointer());
        }
        public unsafe bool IsInAir()
        {
            var func = (delegate* unmanaged[Thiscall]<nint, bool>)this.GetVirtualFunctionPointer(21);
            return func(this.GetThisPointer());
        }

        public unsafe void Update()
        {
            var func = (delegate* unmanaged[Thiscall]<nint, void>)this.GetVirtualFunctionPointer(23);
            func(this.GetThisPointer());
        }


        // public unsafe void AnnounceExpiredPointer(bool removed = true)
        // {
        //     var func = (delegate* unmanaged[Thiscall]<int, ref AbstractClass, Bool, void>)ASM.FastCallTransferStation;
        //     func(0x7258D0, ref this, removed);
        // }

        [FieldOffset(0)] public nint Vfptr;

        [FieldOffset(16)] public int UniqueID;
        [FieldOffset(20)] public AbstractFlags AbstractFlags;
        [FieldOffset(24)] public int unknown_18;
        [FieldOffset(28)] public int RefCount;
        [FieldOffset(32)] public Bool Dirty;
    }
