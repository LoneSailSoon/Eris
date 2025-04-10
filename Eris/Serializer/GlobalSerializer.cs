using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Eris.Extension.Eris.Style;
using Eris.Utilities.Helpers;
using NaegleriaSerializer;
using NaegleriaSerializer.Streaming;
using PatcherYrSharp.Helpers;

namespace Eris.Serializer;

public static class GlobalSerializer
{
    public static bool IsSaving { get; private set; }
    public static bool IsLoading { get; private set; }
    public static void StartSave(string savePath)
    {
        try
        {
            Saver.Write();
            IsSaving = true;
        }
        catch (Exception e)
        {
            LogHelper.Log(e);
        }
        
    }

    public static void EndSave(string savePath)
    {
        try
        {
            StyleType.ExtMap.Serialize(Saver);
            
            File.WriteAllBytes(GetSavePath(savePath), Saver.Buffer.AsSpan());
            Saver.Reset();
            IsSaving = false;
        }
        catch (Exception ex)
        {
            LogHelper.Log(ex);
        }

    }

    public static void StartLoad(string savePath)
    {
        try
        {
            Loader.Read(File.ReadAllBytes(GetSavePath(savePath)));
            IsLoading = true;
        }
        catch (Exception ex)
        {

            LogHelper.Log(ex);
        }
        
    }

    public static void EndLoad(string savePath)
    {
        try
        {
            StyleType.ExtMap.Deserialize(Loader);
            Loader.Reset();
            IsLoading = false;
        }
        catch (Exception ex)
        {

            LogHelper.Log(ex);
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

        var fileName = Path.ChangeExtension(name, "eris.data");
        return Path.Combine(saveDir, fileName);
    }

    public static void WriteObject(INaegleriaSerializable obj)
    {
        try
        {
            Saver.Serialize(obj);
        }
        catch (Exception ex)
        {
            LogHelper.Log(ex);
        }

    }

    public static INaegleriaSerializable? ReadObject()
    {
        try
        {
            return Loader.Deserialize();
        }
        catch (Exception ex)
        {
            LogHelper.Log(ex);
        }
        return null;
    }

    private static readonly NaegleriaSerializeStream Saver = new NaegleriaSerializeStream();
    private static readonly NaegleriaDeserializeStream Loader = new NaegleriaDeserializeStream();


    //[Hook(HookType.AresHook, Address = 0x67CEF0, Size = 6)]
    [UnmanagedCallersOnly(EntryPoint = "SaveGame_Start", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe UInt32 SaveGame_Start(Registers* r)
    {
        string fileName = AnsiStringPointer.From((nint)r->ECX);
        
        StartSave(fileName);

        return 0;
    }

    //[Hook(HookType.AresHook, Address = 0x67D2F1, Size = 0x6)]
    [UnmanagedCallersOnly(EntryPoint = "SaveGame_End", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe UInt32 SaveGame_End(Registers* r)
    {
        string fileName = AnsiStringPointer.From((nint)r->EDI);
        
        EndSave(fileName);

        return 0;
    }

    //[Hook(HookType.AresHook, Address = 0x67E440, Size = 6)]
    [UnmanagedCallersOnly(EntryPoint = "LoadGame_Start", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe UInt32 LoadGame_Start(Registers* r)
    {
        string fileName = AnsiStringPointer.From((nint)r->ECX);
        StartLoad(fileName);

        return 0;
    }

    //[Hook(HookType.AresHook, Address = 0x67E720, Size = 6)]
    [UnmanagedCallersOnly(EntryPoint = "LoadGame_End", CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe UInt32 LoadGame_End(Registers* r)
    {
        string fileName = AnsiStringPointer.From((nint)r->ESI);
        EndLoad(fileName);

        return 0;
    }

}