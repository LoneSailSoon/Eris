namespace Eris.BeonSerializer;

public static class SerializeIdCreater
{
    private static ulong _id;
    public static ulong NewId() => ++_id;
}