namespace Eris.Utilities.Ini.Parsers;

partial class Parsers
{
    public static void ParseConfig<TConfig>(string? value, ref TConfig? config) where TConfig : IniConfig => config?.Parser(value);
}
