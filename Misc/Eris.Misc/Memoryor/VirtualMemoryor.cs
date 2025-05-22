using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Eris.Misc.Memoryor;

public class VirtualMemoryor : IDisposable
{

    private nint _handle;
    public nint Handle => _handle;

    public VirtualMemoryor(byte[] data)
    {
        _handle = Marshal.AllocHGlobal(data.Length);

        Marshal.Copy(data, 0, _handle, data.Length);

        VirtualProtectExecute(_handle, data.Length);
    }
    
    public void Dispose()
    {
        if (_handle != nint.Zero)
        {
            try
            {
                Marshal.FreeHGlobal(_handle);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            _handle = IntPtr.Zero;
        }
    }

    ~VirtualMemoryor()
    {
        if (_handle != nint.Zero)
        {
            try
            {
                Marshal.FreeHGlobal(_handle);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            _handle = IntPtr.Zero;
        }
    }

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern int VirtualProtectEx(nint hProcess, nint lpAddress, int dwSize, int flNewProtect,
        ref int lpflOldProtect);

    private static bool VirtualProtectExecute(nint address, int size)
    {
        const int pageExecuteReadwrite = 0x40;
        var old = 0;
        return VirtualProtectEx(Process.GetCurrentProcess().Handle, address, size, pageExecuteReadwrite, ref old) == 0;
    }

}