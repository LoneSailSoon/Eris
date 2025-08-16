using Eris.YRSharp.String.Ansi;

namespace Eris.YRSharp;

public class Powerups
{
    public const nint effects = 0x7E523C;
    public static FixedArray<AnsiStringPointer> Effects => new(effects, 19);
    public const nint weights = 0x81DA8C;
    public static FixedArray<int> Weights => new(weights, 19);
    public const nint arguments = 0x89EC28;
    public static FixedArray<double> Arguments => new(arguments, 19);
    public const nint naval = 0x89ECC0;
    public static FixedArray<Bool> Naval => new(naval, 19);
    public const nint anims = 0x81DAD8;
    public static FixedArray<int> Anims => new(anims, 19);

}