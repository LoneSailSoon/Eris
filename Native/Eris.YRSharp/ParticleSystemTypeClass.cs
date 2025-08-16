using System.Numerics;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit)]
public struct ParticleSystemTypeClass
{
    [FieldOffset(0)] public ObjectTypeClass Base;
    [FieldOffset(660)] public int HoldsWhat;
    [FieldOffset(664)] public Bool Spawns;
    [FieldOffset(668)] public int SpawnFrames;
    [FieldOffset(672)] public float Slowdown;
    [FieldOffset(676)] public int ParticleCap;
    [FieldOffset(680)] public int SpawnRadius;
    [FieldOffset(684)] public float SpawnCutoff;
    [FieldOffset(688)] public float SpawnTranslucencyCutoff;
    [FieldOffset(692)] public BehavesLike BehavesLike;
    [FieldOffset(696)] public int Lifetime;
    [FieldOffset(700)] public Vector3 SpawnDirection;
    [FieldOffset(712)] public double ParticlesPerCoord;
    [FieldOffset(720)] public double SpiralDeltaPerCoord;
    [FieldOffset(728)] public double SpiralRadius;
    [FieldOffset(736)] public double PositionPerturbationCoefficient;
    [FieldOffset(744)] public double MovementPerturbationCoefficient;
    [FieldOffset(752)] public double VelocityPerturbationCoefficient;
    [FieldOffset(760)] public double SpawnSparkPercentage;
    [FieldOffset(768)] public int SparkSpawnFrames;
    [FieldOffset(772)] public int LightSize;
    [FieldOffset(776)] public ColorStruct LaserColor;
    [FieldOffset(779)] public Bool Laser;
    [FieldOffset(780)] public Bool OneFrameLight;

}