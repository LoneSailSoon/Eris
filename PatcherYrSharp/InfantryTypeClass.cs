﻿using System.Runtime.InteropServices;

namespace PatcherYrSharp;

[StructLayout(LayoutKind.Explicit, Size = 3792)]
public struct InfantryTypeClass
{
    [FieldOffset(0)] public TechnoTypeClass Base;
    [FieldOffset(0)] public ObjectTypeClass BaseObjectType;
    [FieldOffset(0)] public AbstractTypeClass BaseAbstractType;
    [FieldOffset(3576)] public int ArrayIndex;

}