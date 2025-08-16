namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit, Size = 44)]
public struct ControlClass
{
    
    [FieldOffset(0)] public GadgetClass Base;
    [FieldOffset(36)] public int Id;
    [FieldOffset(40)] public nint sendTo;
    public Pointer<GadgetClass> SendTo => sendTo;
}