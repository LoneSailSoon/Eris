global using Eris.YRSharp.GeneralStructures;
global using Eris.YRSharp.GeneralDefinitions;
global using Eris.YRSharp.Helpers;
global using System.Runtime.InteropServices;
global using Eris.YRSharp.Vector;

namespace Eris.YRSharp;

public static class YRSharp;

public interface IYRObject<T,TType>
{
    static abstract Pointer<TType> Type(Pointer<T> pThis);
}

//      ABCDEFGHIGKLMNOPQRSTUV
//TODO: WXYZ