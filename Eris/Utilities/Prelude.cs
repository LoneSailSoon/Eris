global using short2 = Eris.YRSharp.Vector.CellStruct;
global using double3 = Eris.YRSharp.Vector.BulletVelocity;
global using byte3 = Eris.YRSharp.Vector.ColorStruct;
global using int4 = Eris.YRSharp.Vector.RectangleStruct;
global using int3 = Eris.YRSharp.Vector.CoordStruct;
global using int2 = Eris.YRSharp.Vector.Point2D;
global using float12 = Eris.YRSharp.Vector.Matrix3D;
global using static Eris.Utilities.Prelude;

using Eris.Misc.Functor;
using System.Runtime.CompilerServices;

namespace Eris.Utilities;

public static class Prelude
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MaybeRef<T> Just<T>(T value) where T : allows ref struct
        => value;

    public const Fail Nothing = default;
}