using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using Eris.Serializer;
using Eris.Utilities.Helpers;

namespace Eris;
public static class Program
{
    [StructLayout(LayoutKind.Sequential)]
    struct SyringeHandshakeInfo
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
    
    public const string Logo = "\u250c\u2500\u2500\u0020\u0045\u0052\u0049\u0053\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2510\u000d\u000a\u2502\u0020\u0020\u0020\u0020\u0020\u0020\u0020\u005f\u005f\u005f\u005f\u005f\u005f\u0020\u0020\u0020\u005f\u005f\u005f\u005f\u0020\u0020\u0020\u0020\u0020\u005f\u005f\u005f\u005f\u0020\u0020\u0020\u005f\u005f\u005f\u005f\u005f\u0020\u0020\u0020\u2502\u000d\u000a\u2502\u0020\u0020\u0020\u0020\u0020\u0020\u002f\u0020\u005f\u005f\u005f\u005f\u002f\u0020\u0020\u002f\u0020\u005f\u005f\u0020\u005c\u0020\u0020\u0020\u002f\u0020\u0020\u005f\u002f\u0020\u0020\u002f\u0020\u005f\u005f\u005f\u002f\u0020\u0020\u0020\u2502\u000d\u000a\u2502\u0020\u0020\u0020\u0020\u0020\u002f\u0020\u005f\u005f\u002f\u0020\u0020\u0020\u0020\u002f\u0020\u002f\u005f\u002f\u0020\u002f\u0020\u0020\u0020\u002f\u0020\u002f\u0020\u0020\u0020\u0020\u005c\u005f\u005f\u0020\u005c\u0020\u0020\u0020\u0020\u2502\u000d\u000a\u2502\u0020\u0020\u0020\u0020\u002f\u0020\u002f\u005f\u005f\u005f\u0020\u0020\u0020\u002f\u0020\u005f\u005f\u0020\u005f\u002f\u0020\u0020\u005f\u002f\u0020\u002f\u0020\u0020\u0020\u0020\u005f\u005f\u005f\u002f\u0020\u002f\u0020\u0020\u0020\u0020\u2502\u000d\u000a\u2502\u0020\u0020\u0020\u002f\u005f\u005f\u005f\u005f\u005f\u002f\u0020\u0020\u002f\u005f\u002f\u0020\u007c\u005f\u007c\u0020\u0020\u002f\u005f\u005f\u005f\u002f\u0020\u0020\u0020\u002f\u005f\u005f\u005f\u005f\u002f\u0020\u0020\u0020\u0020\u0020\u2502\u000d\u000a\u2502\u0020\u0020\u0020\u0020\u0020\u0020\u0020\u0020\u0020\u0020\u0020\u0020\u0020\u0020\u0020\u0020\u0020\u0020\u0020\u0020\u0020\u0020\u0020\u0020\u0020\u0020\u0020\u0020\u0020\u0020\u0020\u0020\u0020\u0020\u0020\u0020\u0020\u0020\u0020\u0020\u2502\u000d\u000a\u2514\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2518\u000d\u000a";
    //长度100以内即可
    public const string HandshakeMassage = "Eris Loader Handshake";

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
    public static unsafe uint Eris_Action(nint r)
    {
        if (AllocConsole())
        {
          
            Console.Title = "Eris Debug Console";
            //ConsoleColor originFgColor = Console.ForegroundColor;
            //ConsoleColor originBgColor = Console.BackgroundColor;
            ////LogHelper.Log($".NETVersion:{Environment.Version}", "Eris active", 20 , ConsoleColor.Green);
            //Console.ForegroundColor = ConsoleColor.Black;
            //Console.BackgroundColor = ConsoleColor.White;

            Console.Write(Logo);

            //Console.ForegroundColor = originFgColor;
            //Console.BackgroundColor = originBgColor;s


            //Console.WriteLine("[+] Eris active");
            //Console.WriteLine($"[+] .NETVersion:{Environment.Version}");
            LogHelper.Log($"{Environment.Version}", ".NETVersion", 15, ConsoleColor.Green);
        
            //LogHelper.Log($"Failed to parse Ini file content: [MultipleMindControlTower]Anim=YURICNTL", "Warning", 15, ConsoleColor.Yellow);
            //LogHelper.Log($"HTNK", "ObjectInfo", 15);
            //LogHelper.Log(new Exception());
        }
        SerializeRegister.Register();
        return 0;
    }


    [DllImport("kernel32.dll")]
    public static extern bool AllocConsole();
    
    public static string RootDirectory => Environment.CurrentDirectory;
}