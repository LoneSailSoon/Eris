using System.Runtime.CompilerServices;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit)]
public struct ScriptTypeClass
{
    [FieldOffset(0)] public AbstractTypeClass Base;
    [FieldOffset(152)] public int ArrayIndex;
    [FieldOffset(156)] public Bool IsGlobal;
    [FieldOffset(160)] public int ActionsCount;
    [FieldOffset(164)] public byte scriptActions;
    public FixedArray<ScriptActionNode> ScriptActions => new(ref Unsafe.As<byte, ScriptActionNode>(ref scriptActions), 50);
}

[StructLayout(LayoutKind.Sequential)]
public struct ScriptActionNode
{
    public int Action;
    public int Argument;
}