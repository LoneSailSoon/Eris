using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using Eris.Scripts;
using Eris.Serializer;

namespace Eris;
public static class Program
{
    [StructLayout(LayoutKind.Sequential)]
    private struct SyringeHandshakeInfo
    {
        public int cbSize;
        public int numHooks;
        public int checksum;
        public uint exeFilesize;
        public uint exeTimestamp;
        public uint exeCRC;
        public int cchMessage;
        public nint Message;
    }
    
    private const string Logo = "\u250c\u2500\u2500\u0020\u0045\u0052\u0049\u0053\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2510\u000d\u000a\u2502\u0020\u0020\u0020\u0020\u0020\u0020\u0020\u005f\u005f\u005f\u005f\u005f\u005f\u0020\u0020\u0020\u005f\u005f\u005f\u005f\u0020\u0020\u0020\u0020\u0020\u005f\u005f\u005f\u005f\u0020\u0020\u0020\u005f\u005f\u005f\u005f\u005f\u0020\u0020\u0020\u2502\u000d\u000a\u2502\u0020\u0020\u0020\u0020\u0020\u0020\u002f\u0020\u005f\u005f\u005f\u005f\u002f\u0020\u0020\u002f\u0020\u005f\u005f\u0020\u005c\u0020\u0020\u0020\u002f\u0020\u0020\u005f\u002f\u0020\u0020\u002f\u0020\u005f\u005f\u005f\u002f\u0020\u0020\u0020\u2502\u000d\u000a\u2502\u0020\u0020\u0020\u0020\u0020\u002f\u0020\u005f\u005f\u002f\u0020\u0020\u0020\u0020\u002f\u0020\u002f\u005f\u002f\u0020\u002f\u0020\u0020\u0020\u002f\u0020\u002f\u0020\u0020\u0020\u0020\u005c\u005f\u005f\u0020\u005c\u0020\u0020\u0020\u0020\u2502\u000d\u000a\u2502\u0020\u0020\u0020\u0020\u002f\u0020\u002f\u005f\u005f\u005f\u0020\u0020\u0020\u002f\u0020\u005f\u005f\u0020\u005f\u002f\u0020\u0020\u005f\u002f\u0020\u002f\u0020\u0020\u0020\u0020\u005f\u005f\u005f\u002f\u0020\u002f\u0020\u0020\u0020\u0020\u2502\u000d\u000a\u2502\u0020\u0020\u0020\u002f\u005f\u005f\u005f\u005f\u005f\u002f\u0020\u0020\u002f\u005f\u002f\u0020\u007c\u005f\u007c\u0020\u0020\u002f\u005f\u005f\u005f\u002f\u0020\u0020\u0020\u002f\u005f\u005f\u005f\u005f\u002f\u0020\u0020\u0020\u0020\u0020\u2502\u000d\u000a\u2502\u0020\u0020\u0020\u0020\u0020\u0020\u0020\u0020\u0020\u0020\u0020\u0020\u0020\u0020\u0020\u0020\u0020\u0020\u0020\u0020\u0020\u0020\u0020\u0020\u0020\u0020\u0020\u0020\u0020\u0020\u0020\u0020\u0020\u0020\u0020\u0020\u0020\u0020\u0020\u0020\u2502\u000d\u000a\u2514\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2518\u000d\u000a";
    //长度100以内即可
    public const string ErisVersion = "R0.003";
    private const string HandshakeMassage = $"Applying Eris {ErisVersion}";
    
    
    [UnmanagedCallersOnly(EntryPoint = "SyringeHandshake", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint SyringeHandshake(nint pInfo)
    {
        if (pInfo is not 0)
        {
            fixed (byte* pchName = Encoding.ASCII.GetBytes(HandshakeMassage))
            {
                Buffer.MemoryCopy(pchName, Unsafe.AsRef<SyringeHandshakeInfo>(pInfo.ToPointer()).Message.ToPointer(), HandshakeMassage.Length, HandshakeMassage.Length);
            } 
            return 0;
        }
        return 0;
    }

    [UnmanagedCallersOnly(EntryPoint = "Eris_Action", CallConvs = [typeof(CallConvCdecl)])]
    public static uint Eris_Action(nint r)
    {
        if (AllocConsole())
        {
            Console.Title = "Eris Debug Console";
            
            Console.Write(Logo);
        }

        SerializeRegister.Register();
        ScriptsRegister.Register();
        return 0;
    }

    [DllImport("kernel32.dll")]
    public static extern bool AllocConsole();
    
    public static string RootDirectory => Environment.CurrentDirectory;
}