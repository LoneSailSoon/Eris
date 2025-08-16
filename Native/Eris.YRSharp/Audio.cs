using System.Runtime.CompilerServices;
using Eris.YRSharp.String.Ansi;
using Eris.YRSharp.String.Uni;

namespace Eris.YRSharp;

public class Audio;

[StructLayout(LayoutKind.Sequential)]
public struct AudioIDXHeader 
{
    public uint Magic;
    public uint Version;
    public uint numSamples;
}

[StructLayout(LayoutKind.Explicit)]
public struct AudioIDXEntry 
{ 
    [FieldOffset(0)]public byte name;
    public AnsiStringPointer Name => name.GetThisPointer();
    [FieldOffset(16)]public int Offset;
    [FieldOffset(20)]public int Size;
    [FieldOffset(24)]public uint SampleRate;
    [FieldOffset(28)]public uint Flags;
    [FieldOffset(32)]public uint ChunkSize;
}

[StructLayout(LayoutKind.Sequential)]
public struct AudioSampleData {

    public uint Data;
    public uint Format;
    public uint SampleRate;
    public uint NumChannels;
    public uint BytesPerSample;
    public uint ByteRate;
    public uint BlockAlign;
    public uint Flags;
}

[StructLayout(LayoutKind.Sequential)]
public struct AudioController
{
    public nint Event; // Pointer to audio event (AudioEventTag) associated with this controller, type not implemented in YRpp as of current.
    public uint Stamp;
    public nint eventType;
    public readonly Pointer<VocClass> EventType => eventType;
    public nint audioIndex;
    public readonly Pointer<Pointer<AudioIDXData>> AudioIndex => audioIndex;
    public uint Unused;
}

[StructLayout(LayoutKind.Explicit)]
public struct AudioIDXData
{
    [FieldOffset(0)] public nint samples;
    public readonly Pointer<AudioIDXEntry> Samples => samples;
    [FieldOffset(4)] public int SampleCount;
    [FieldOffset(8)] public byte path;
    public AnsiStringPointer Path => Pointer<byte>.AsPointer(ref path);
    [FieldOffset(268)] public nint bagFile;
    public readonly Pointer<CCFileClass> BagFile => bagFile;
    [FieldOffset(272)] public nint externalFile;
    public readonly Pointer<RawFileClass> ExternalFile => externalFile;
    [FieldOffset(276)] public int pathFound;

    public bool PathFound { get => pathFound != 0; set => pathFound = value ? 1 : 0; }

    [FieldOffset(280)] public nint currentSampleFile;
    public readonly Pointer<RawFileClass> CurrentSampleFile => currentSampleFile;
    [FieldOffset(284)] public int CurrentSampleSize;
    [FieldOffset(288)] public uint unknown_120;

}