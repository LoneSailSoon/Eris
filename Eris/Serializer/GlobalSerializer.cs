using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Eris.BeonSerializer;
using Eris.BeonSerializer.Streaming;
using Eris.Component.Root;
using Eris.Utilities.Logger;
using Eris.YRSharp.Helpers;
using Eris.YRSharp.String.Ansi;

namespace Eris.Serializer;

public static class GlobalSerializer
{
    public static bool IsSaving { get; private set; }
    public static bool IsLoading { get; private set; }
    private static void StartSave(string savePath)
    {
        try
        {
            Saver.Write();

            var version = Program.ErisVersion;
            Saver.ProcessStringInline(ref version);
            IsSaving = true;
        }
        catch (Exception e)
        {
            Logger.LogException(e);
        }
        
    }

    private static void EndSave(string savePath)
    {
        try
        {

            Root.Serialize(Saver);

            File.WriteAllBytes(GetSavePath(savePath), Saver.Buffer.AsSpan());
            Saver.Reset();
            IsSaving = false;
            
            GC.Collect();
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
        }

    }

    private static void StartLoad(string savePath)
    {
        try
        {
            Loader.Read(File.ReadAllBytes(GetSavePath(savePath)));
            IsLoading = true;

            string? version = null;
            Loader.ProcessStringInline(ref version);

            if(version?.Equals(Program.ErisVersion) != true)Logger.Log("阋神星版本错误，无法反序列化", LogLevel.Error);
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
        }
    }

    private static void EndLoad(string savePath)
    {
        try
        {
            Root.Deserialize(Loader);
            
            Loader.Reset();
            IsLoading = false;
            GC.Collect();
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
        }
    }

    private static string GetSavePath(string name)
    {
        string saveDir;
        if (name.Contains("Saved Games"))
        {
            saveDir = Program.RootDirectory;
        }
        else
        {
            saveDir = Path.Combine(Program.RootDirectory, "Saved Games");
        }

        if (!Directory.Exists(saveDir))
        {
            Directory.CreateDirectory(saveDir);
        }

        var fileName = Path.ChangeExtension(name, "beon");
        return Path.Combine(saveDir, fileName);
    }

    public static void WriteObject(IBeonSerializable obj)
    {
        try
        {
            Saver.Serialize(obj);
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
        }

    }

    public static IBeonSerializable? ReadObject()
    {
        try
        {
            return Loader.Deserialize();
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
        }
        return null;
    }

    private static readonly BeonSerializeStream Saver = new();
    private static readonly BeonDeserializeStream Loader = new();


    //[Hook(HookType.AresHook, Address = 0x67CEF0, Size = 6)]
    [UnmanagedCallersOnly(EntryPoint = "SaveGame_Start", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint SaveGame_Start(Registers* r)
    {
        string fileName = AnsiStringPointer.From((nint)r->ECX);
        
        StartSave(fileName);

        return 0;
    }

    //[Hook(HookType.AresHook, Address = 0x67D2F1, Size = 0x6)]
    [UnmanagedCallersOnly(EntryPoint = "SaveGame_End", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint SaveGame_End(Registers* r)
    {
        string fileName = AnsiStringPointer.From((nint)r->EDI);
        
        EndSave(fileName);

        return 0;
    }

    //[Hook(HookType.AresHook, Address = 0x67E440, Size = 6)]
    [UnmanagedCallersOnly(EntryPoint = "LoadGame_Start", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint LoadGame_Start(Registers* r)
    {
        string fileName = AnsiStringPointer.From((nint)r->ECX);
        StartLoad(fileName);

        return 0;
    }

    //[Hook(HookType.AresHook, Address = 0x67E720, Size = 6)]
    [UnmanagedCallersOnly(EntryPoint = "LoadGame_End", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint LoadGame_End(Registers* r)
    {
        string fileName = AnsiStringPointer.From((nint)r->ESI);
        EndLoad(fileName);

        return 0;
    }

    [UnmanagedCallersOnly(EntryPoint = "SwizzleManagerClass_Here_I_Am", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint SwizzleManagerClass_Here_I_Am(Registers* r)
    {
        SwizzleNode.HereIAm(r->Stack<nint>(8), r->Stack<nint>(12));
        //Console.WriteLine($"SwizzleManagerClass_Here_I_Am {r->Stack<nint>(8)} -> {r->Stack<nint>(12)}");
        return 0;
    }

    [UnmanagedCallersOnly(EntryPoint = "SwizzleManagerClass_ConvertNodes", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe uint SwizzleManagerClass_ConvertNodes(Registers* r)
    {
        SwizzleNode.Clear();
        //Console.WriteLine("SwizzleManagerClass_ConvertNodes");
        return 0;
    }
}