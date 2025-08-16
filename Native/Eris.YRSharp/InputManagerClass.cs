namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit, Size = 31)]
public struct InputManagerClass
{
    private const nint instance = 0x87F770;
    public static ref InputManagerClass Instance => ref instance.Convert<InputManagerClass>().Ref;

    public unsafe bool IsKeyPressed(int key)
    {
        var func = (delegate* unmanaged[Thiscall]<ref InputManagerClass, int, bool>)0x54F5C0;
        return func(ref this, key);
    }

    public bool IsForceFireKeyPressed()
    {
        return IsKeyPressed(GameOptionsClass.Instance.KeyForceFire1)
               || IsKeyPressed(GameOptionsClass.Instance.KeyForceFire2);
    }

    public bool IsForceMoveKeyPressed()
    {
        return IsKeyPressed(GameOptionsClass.Instance.KeyForceMove1)
               || IsKeyPressed(GameOptionsClass.Instance.KeyForceMove2);
    }

    public bool IsForceSelectKeyPressed()
    {
        return IsKeyPressed(GameOptionsClass.Instance.KeyForceSelect1)
               || IsKeyPressed(GameOptionsClass.Instance.KeyForceSelect2);
    }
}