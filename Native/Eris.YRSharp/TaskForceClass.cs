using System.Runtime.CompilerServices;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit)]
public struct TaskForceClass
{
    [FieldOffset(0)] public AbstractTypeClass Base;
    [FieldOffset(152)] public int Group;
    [FieldOffset(156)] public int CountEntries;
    [FieldOffset(160)] public Bool IsGlobal;
    [FieldOffset(164)] public byte entries;
    public FixedArray<TaskForceEntryStruct> Entries => new(ref Unsafe.As<byte, TaskForceEntryStruct>(ref entries), 6);
}

[StructLayout(LayoutKind.Sequential, Size = 8)]
public struct TaskForceEntryStruct
{
    public int Amount;
    public Pointer<TechnoTypeClass> Type;
}