﻿using System.Runtime.InteropServices;
using PatcherYrSharp.Helpers;

namespace PatcherYrSharp;

[StructLayout(LayoutKind.Explicit, Size = 8)]
public struct CommandClass
{
    public static readonly IntPtr ArrayPointer = new IntPtr(0x87F658);

    public static GlobalDvcArray<CommandClass> ABSTRACTTYPE_ARRAY = new GlobalDvcArray<CommandClass>(ArrayPointer);

}