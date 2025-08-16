namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit)]
public struct ParticleTypeClass
{
    [FieldOffset(0)] public ObjectTypeClass Base;
    [FieldOffset(660)] public CoordStruct NextParticleOffset;
    [FieldOffset(672)] public int XVelocity;
    [FieldOffset(676)] public int YVelocity;
    [FieldOffset(680)] public int MinZVelocity;
    [FieldOffset(684)] public int ZVelocityRange;
    [FieldOffset(688)] public double ColorSpeed;
    [FieldOffset(696)] public byte colorList;
    public ref TypeList<Pointer<ColorStruct>> ColorList => ref Pointer<byte>.AsPointer(ref colorList).Convert<TypeList<Pointer<ColorStruct>>>().Ref;
    [FieldOffset(724)] public ColorStruct StartColor1;
    [FieldOffset(727)] public ColorStruct StartColor2;
    [FieldOffset(732)] public int MaxDC;
    [FieldOffset(736)] public int MaxEC;
    [FieldOffset(740)] public nint warhead;
    public Pointer<WarheadTypeClass> Warhead => warhead;
    [FieldOffset(744)] public int Damage;
    [FieldOffset(748)] public int StartFrame;
    [FieldOffset(752)] public int NumLoopFrames;
    [FieldOffset(756)] public int Translucency;
    [FieldOffset(760)] public int WindEffect;
    [FieldOffset(764)] public float Velocity;
    [FieldOffset(768)] public float Deacc;
    [FieldOffset(772)] public int Radius;
    [FieldOffset(776)] public Bool DeleteOnStateLimit;
    [FieldOffset(777)] public byte EndStateAI;
    [FieldOffset(778)] public byte StartStateAI;
    [FieldOffset(779)] public byte StateAIAdvance;
    [FieldOffset(780)] public byte FinalDamageState;
    [FieldOffset(781)] public byte Translucent25State;
    [FieldOffset(782)] public byte Translucent50State;
    [FieldOffset(783)] public Bool Normalized;
    [FieldOffset(784)] public nint nextParticle;
    public Pointer<ParticleTypeClass> NextParticle => nextParticle;
    [FieldOffset(788)] public BehavesLike BehavesLike;

}