namespace Eris.Utilities.Ini;

public interface ISection
{
    public string? GetValue(string key);
}