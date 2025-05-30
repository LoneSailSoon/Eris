using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Eris.YRSharp.Helpers;

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct Register
    {
        UInt32 data;

        /// <summary>Get data by word.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort Get16()
        {
            return (ushort)data;
        }

        /// <summary>Get data by dword.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint Get()
        {
            return data;
        }

        /// <summary>Get data by T.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T Get<T>()
        {
            return Unsafe.As<uint, T>(ref data);
        }

        /// <summary>Set data by dword.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint Set(uint value)
        {
            return data = value;
        }

        /// <summary>Set data by T.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Set<T>(T value)
        {
            data = Unsafe.As<T, uint>(ref value);
        }

        /// <summary>Set data by word.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Set16(ushort value)
        {
            data |= value;
        }

        /// <summary>Get high byte of data.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte Get8Hi()
        {
            return (byte)(data >> 8);
        }

        /// <summary>Get low byte of data.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte Get8Lo()
        {
            return (byte)data;
        }

        /// <summary>Set high byte of data.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Set8Hi(byte value)
        {
            data |= ((uint)value << 8);
        }

        /// <summary>Set low byte of data.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Set8Lo(byte value)
        {
            data |= value;
        }
        /// <summary>Get T* by register + offset</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T* Lea<T>(int byteOffset) where T : unmanaged
        {
            return (T*)Lea(byteOffset);
        }

        /// <summary>Get dword by register + offset</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint Lea(int byteOffset)
        {
            return (uint)(data + byteOffset);
        }

        /// <summary>Get T by [register + offset]</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T At<T>(int byteOffset)
        {
            return Unsafe.Read<T>((void*)Lea(byteOffset));
        }

        /// <summary>Set [register + offset] by T</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void At<T>(int byteOffset, T value)
        {
            Unsafe.Write((void*)Lea(byteOffset), value);
        }
    };

    /// <summary>Represent the context of ares hook</summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct Registers
    {
        private UInt32 origin;
        private UInt32 flags;

        public Register _EDI;
        public Register _ESI;
        public Register _EBP;
        public Register _ESP;
        public Register _EBX;
        public Register _EDX;
        public Register _ECX;
        public Register _EAX;

        /// <summary>Current Hook Address</summary>
        public uint Origin
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => origin;
        }

        /// <summary>Data of flag register </summary>
        public uint EFLAGS
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => flags;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => flags = value;
        }

        /// <summary>Data of EAX</summary>
        public uint EAX
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _EAX.Get();
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => _EAX.Set(value);
        }

        /// <summary>Data of ECX</summary>
        public uint ECX
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _ECX.Get();
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => _ECX.Set(value);
        }

        /// <summary>Data of EDX</summary>
        public uint EDX
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _EDX.Get();
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => _EDX.Set(value);
        }

        /// <summary>Data of EBX</summary>
        public uint EBX
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _EBX.Get();
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => _EBX.Set(value);
        }

        /// <summary>Data of ESP</summary>
        public uint ESP
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _ESP.Get();
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => _ESP.Set(value);
        }

        /// <summary>Data of EBP</summary>
        public uint EBP
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _EBP.Get();
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => _EBP.Set(value);
        }

        /// <summary>Data of EDI</summary>
        public uint EDI
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _EDI.Get();
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => _EDI.Set(value);
        }

        /// <summary>Data of ESI</summary>
        public uint ESI
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _ESI.Get();
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => _ESI.Set(value);
        }
        #region REG_SHORTCUTS_XHL(A)

        /// <summary>Data of AX</summary>
        public ushort AX
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _EAX.Get16();
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => _EAX.Set16(value);
        }

        /// <summary>Data of AH</summary>
        public byte AH
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _EAX.Get8Hi();
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => _EAX.Set8Hi(value);
        }

        /// <summary>Data of AL</summary>
        public byte AL
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _EAX.Get8Lo();
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => _EAX.Set8Lo(value);
        }
        #endregion
        #region REG_SHORTCUTS_XHL(B)

        /// <summary>Data of BX</summary>
        public ushort BX
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _EBX.Get16();
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => _EBX.Set16(value);
        }

        /// <summary>Data of BH</summary>
        public byte BH
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _EBX.Get8Hi();
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => _EBX.Set8Hi(value);
        }

        /// <summary>Data of BL</summary>
        public byte BL
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _EBX.Get8Lo();
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => _EBX.Set8Lo(value);
        }
        #endregion
        #region REG_SHORTCUTS_XHL(C)

        /// <summary>Data of CX</summary>
        public ushort CX
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _ECX.Get16();
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => _ECX.Set16(value);
        }

        /// <summary>Data of CH</summary>
        public byte CH
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _ECX.Get8Hi();
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => _ECX.Set8Hi(value);
        }

        /// <summary>Data of CL</summary>
        public byte CL
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _ECX.Get8Lo();
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => _ECX.Set8Lo(value);
        }
        #endregion
        #region REG_SHORTCUTS_XHL(D)

        /// <summary>Data of DX</summary>
        public ushort DX
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _EDX.Get16();
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => _EDX.Set16(value);
        }

        /// <summary>Data of DH</summary>
        public byte DH
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _EDX.Get8Hi();
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => _EDX.Set8Hi(value);
        }

        /// <summary>Data of DL</summary>
        public byte DL
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _EDX.Get8Lo();
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => _EDX.Set8Lo(value);
        }
        #endregion

        /// <summary>Get T by ESP + offset</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T LeaStack<T>(int offset)
        {
            uint tmp = _ESP.Lea(offset);
            return Unsafe.As<uint, T>(ref tmp);
        }

        /// <summary>Get dword by ESP + offset</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint LeaStack(int offset)
        {
            return _ESP.Lea(offset);
        }

        /// <summary>Get T&amp; by ESP + offset</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ref T RefStack<T>(int offset)
        {
            return ref Unsafe.AsRef<T>((void*)LeaStack(offset));
        }

        /// <summary>Get T by [ESP + offset]</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T Stack<T>(int offset)
        {
            return _ESP.At<T>(offset);
        }

        /// <summary>Get dword by [ESP + offset]</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint Stack32(int offset)
        {
            return _ESP.At<uint>(offset);
        }

        /// <summary>Get word by [ESP + offset]</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort Stack16(int offset)
        {
            return _ESP.At<ushort>(offset);
        }

        /// <summary>Get byte by [ESP + offset]</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte Stack8(int offset)
        {
            return _ESP.At<byte>(offset);
        }

        /// <summary>Get T by [EBP + offset]</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T Base<T>(int offset)
        {
            return _EBP.At<T>(offset);
        }

        /// <summary>Set [ESP + offset] by T</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Stack<T>(int offset, T value)
        {
            _ESP.At(offset, value);
        }

        /// <summary>Set [ESP + offset] by word</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Stack16(int offset, ushort value)
        {
            _ESP.At(offset, value);
        }

        /// <summary>Set [ESP + offset] by byte</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Stack8(int offset, byte value)
        {
            _ESP.At(offset, value);
        }

        /// <summary>Set [EBP + offset] by T</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Base<T>(int offset, T value)
        {
            _EBP.At(offset, value);
        }
    };
