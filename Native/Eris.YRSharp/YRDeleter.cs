namespace Eris.YRSharp;

public static class YRDeleter
{
    public static void Delete(Pointer<CCFileClass> file)
    {
        CCFileClass.Destructor(file);
        YRMemory.Deallocate(file);
    }
}