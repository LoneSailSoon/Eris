namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit, Size = 10, Pack = 1)]
public struct IPXAddressClass
{
    [FieldOffset(0)]public byte networkNumber;
    public FixedArray<byte> NetworkNumber => new(ref networkNumber, 4); 
    
    [FieldOffset(4)]public byte nodeAddress;
    public FixedArray<byte> NodeAddress => new(ref nodeAddress, 6); 
}