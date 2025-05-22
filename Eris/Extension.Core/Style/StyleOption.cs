using Eris.Utilities.Helpers;

namespace Eris.Extension.Core.Style;

public static class StyleOption
{
    public static readonly IReadOnlyDictionary<string, ulong> SameGroupBehaviorParser =
        EnumHelper.CreatePaser<SameGroupBehavior>("None", "Override", "ResetDuation", "MergeDuation");
}
public enum SameGroupBehavior
{
    None, Override, ResetDuation, MergeDuation
}