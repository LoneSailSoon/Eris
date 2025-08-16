using Eris.Misc.Memoryor;

namespace Eris.YRSharp.Utilities;

public static class NativeCode
{
    private static readonly VirtualMemoryor FastCallHandle = new([
        0x8B, 0x54, 0xE4, 0x08, //MOV EDX, [ESP + 8]
        0x58, // POP EAX
        0x89, 0x44, 0xE4, 0x04, // MOV [ESP + 4], EAX
        0x89, 0xC8, // MOV EAX, ECX
        0x59, // POP ECX
        0xFF, 0xE0 // JMP EAX
    ]);
    
    public static nint FastCallTransferStation => FastCallHandle.Handle;
    
    private static readonly VirtualMemoryor Std2ThisCallHandle = new([
        0x8B, 0x4C, 0x24, 0x08, //MOV ECX, [ESP + 8]
        0x58, //POP EAX
        0x89, 0x44, 0x24, 0x04, // MOV [ESP + 4], EAX
        0x58, //POP EAX
        0xFF, 0xE0 // JMP EAX
    ]);
    
    public static nint Std2ThisCallTransferStation => Std2ThisCallHandle.Handle;
}