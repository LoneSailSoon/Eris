using Eris.Misc.Functor;
using Eris.YRSharp;
using Eris.YRSharp.Helpers;

namespace Eris.Utilities.Ini;

public static class IniExtension
{
    extension(IniReader)
    {
        public static IniReader Read(Pointer<CCIniClass> pIni)
        {
            return new(pIni, IniBuffer.Default);
        }

        public static bool Art(IIniId id, out IniSection art)
            => id.GetArtSection(Read(CCIniClass.IniAI), out art);
    }
}
