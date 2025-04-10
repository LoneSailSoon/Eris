using PatcherYrSharp.GeneralStructures;
using PatcherYrSharp.Helpers;
using PatcherYrSharp.FileFormats;

namespace PatcherYrSharp;

public static class YrCreater
{
    public struct UnCotrPointer<T>(Pointer<T> pointer)
    {
        internal Pointer<T> Pointer = pointer;
    }

    public static UnCotrPointer<T> Create<T>()
    {
        return new(YRMemory.Allocate<T>());
    }

    // public static Pointer<SHPReference> Constructor(this UnCotrPointer<SHPReference> pThis, string fileName)
    // {
    //     SHPReference.Constructor(pThis.Pointer, fileName);
    //     return pThis.Pointer;
    // }

    public static Pointer<AnimClass> Constructor(this UnCotrPointer<AnimClass> pThis, Pointer<AnimTypeClass> pAnimType, CoordStruct location)
    {
        PointerNullReferenceException.ThrowIfNull(pThis.Pointer);
        PointerNullReferenceException.ThrowIfNull(pAnimType);

        AnimClass.Constructor(pThis.Pointer, pAnimType, location);
        return pThis.Pointer;
    }

    public static Pointer<AnimClass> Constructor(this UnCotrPointer<AnimClass> pThis, Pointer<AnimTypeClass> pAnimType, CoordStruct location, int loopDelay = 0,
        int loopCount = 1, uint flags = 0x600, int forceZAdjust = 0, bool reverse = false)
    {
        PointerNullReferenceException.ThrowIfNull(pThis.Pointer);
        PointerNullReferenceException.ThrowIfNull(pAnimType);

        AnimClass.Constructor(pThis.Pointer, pAnimType, location, loopDelay, loopCount, flags, forceZAdjust, reverse);
        return pThis.Pointer;
    }

    public static Pointer<CaptureManagerClass> Constructor(this UnCotrPointer<CaptureManagerClass> pThis, Pointer<TechnoClass> pOwner, int nMaxControlNodes, bool bInfiniteControl)
    {
        CaptureManagerClass.Constructor(pThis.Pointer, pOwner, nMaxControlNodes, bInfiniteControl);
        return pThis.Pointer;
    }

    public static Pointer<CCFileClass> Constructor(this UnCotrPointer<CCFileClass> pThis, string fileName)
    {
        CCFileClass.Constructor(pThis.Pointer, fileName);
        return pThis.Pointer;
    }

    public static Pointer<CCINIClass> Constructor(this UnCotrPointer<CCINIClass> pThis)
    {
        CCINIClass.Constructor(pThis.Pointer);
        return pThis.Pointer;
    }

    public static Pointer<ConvertClass> Constructor(this UnCotrPointer<ConvertClass> pThis, Pointer<BytePalette> palette, Pointer<BytePalette> palette2, Pointer<Surface> pSurface, uint ShadeCount, bool skipBlitters)
    {
        ConvertClass.Constructor(pThis.Pointer, palette, palette2, pSurface, ShadeCount, skipBlitters);
        return pThis.Pointer;
    }
    
    // public static Pointer<EBolt> Constructor(this UnCotrPointer<EBolt> pThis)
    // {
    //     EBolt.Constructor(pThis.Pointer);
    //     return pThis.Pointer;
    // }

    public static Pointer<GenericNode> Constructor(this UnCotrPointer<GenericNode> pThis)
    {
        GenericNode.Constructor(pThis.Pointer);
        return pThis.Pointer;
    }

    public static Pointer<LaserDrawClass> Constructor(this UnCotrPointer<LaserDrawClass> pThis, CoordStruct source, CoordStruct target, int zAdjust, byte unknown,
        ColorStruct innerColor, ColorStruct outerColor, ColorStruct outerSpread,
        int duration, bool blinks = false, bool fades = true,
        float startIntensity = 1.0f, float endIntensity = 0.0f)
    {
        LaserDrawClass.Constructor(pThis.Pointer, source, target, zAdjust, unknown, innerColor, outerColor, outerSpread, duration, blinks, fades, startIntensity, endIntensity);
        return pThis.Pointer;
    }

    public static Pointer<LaserDrawClass> Constructor(this UnCotrPointer<LaserDrawClass> pThis, CoordStruct source, CoordStruct target, ColorStruct innerColor,
        ColorStruct outerColor, ColorStruct outerSpread, int duration)
    {
        LaserDrawClass.Constructor(pThis.Pointer, source, target, innerColor, outerColor, outerSpread, duration);
        return pThis.Pointer;
    }

    public static Pointer<MissionControlClass> Constructor(this UnCotrPointer<MissionControlClass> pThis)
    {
        MissionControlClass.Constructor(pThis.Pointer);
        return pThis.Pointer;
    }

    // public static Pointer<MixFileClass> Constructor(this UnCotrPointer<MixFileClass> pThis, string fileName)
    // {
    //     MixFileClass.Constructor(pThis.Pointer, fileName);
    //     return pThis.Pointer;
    // }
    //
    public static Pointer<DSurface> Constructor(this UnCotrPointer<DSurface> pThis, int Width, int Height, bool BackBuffer, bool Force3D)
    {
        DSurface.Constructor(pThis.Pointer, Width, Height, BackBuffer, Force3D);
        return pThis.Pointer;
    }
    
    public static Pointer<XSurface> Constructor(this UnCotrPointer<XSurface> pThis, int Width, int Height)
    {
        XSurface.Constructor(pThis.Pointer, Width, Height);
        return pThis.Pointer;
    }
    
    public static Pointer<BSurface> Constructor(this UnCotrPointer<BSurface> pThis, int Width, int Height)
    {
        BSurface.Constructor(pThis.Pointer, Width, Height);
        return pThis.Pointer;
    }
    //
    // public static Pointer<ParticleSystemClass> Constructor(this UnCotrPointer<ParticleSystemClass> pThis, Pointer<ParticleSystemTypeClass> pType, CoordStruct sourcePos, CoordStruct targetPos)
    // {
    //     ParticleSystemClass.Constructor(pThis.Pointer, pType, sourcePos, targetPos);
    //     return pThis.Pointer;
    // }
    //
    // public static Pointer<ParticleSystemClass> Constructor(this UnCotrPointer<ParticleSystemClass> pThis, Pointer<ParticleSystemTypeClass> pType, CoordStruct sourcePos, CoordStruct targetPos, Pointer<TechnoClass> pOwner)
    // {
    //     ParticleSystemClass.Constructor(pThis.Pointer, pType, sourcePos, targetPos, pOwner);
    //     return pThis.Pointer;
    // }
    //
    // public static Pointer<ParticleSystemClass> Constructor(this UnCotrPointer<ParticleSystemClass> pThis, Pointer<ParticleSystemTypeClass> pType, CoordStruct sourcePos, Pointer<AbstractClass> pTarget, Pointer<TechnoClass> pOwner)
    // {
    //     ParticleSystemClass.Constructor(pThis.Pointer, pType, sourcePos, pTarget, pOwner);
    //     return pThis.Pointer;
    // }
    //
    // public static Pointer<ParticleSystemClass> Constructor(this UnCotrPointer<ParticleSystemClass> pThis, Pointer<ParticleSystemTypeClass> pType, CoordStruct sourcePos, Pointer<AbstractClass> pTarget, Pointer<TechnoClass> pOwner, CoordStruct targetPos)
    // {
    //     ParticleSystemClass.Constructor(pThis.Pointer, pType, sourcePos, pTarget, pOwner, targetPos);
    //     return pThis.Pointer;
    // }
    //
    // public static Pointer<ParticleSystemClass> Constructor(this UnCotrPointer<ParticleSystemClass> pThis, Pointer<ParticleSystemTypeClass> pType, CoordStruct sourcePos, Pointer<AbstractClass> pTarget, Pointer<TechnoClass> pOwner, CoordStruct targetPos, int unk)
    // {
    //     ParticleSystemClass.Constructor(pThis.Pointer, pType, sourcePos, pTarget, pOwner, targetPos, unk);
    //     return pThis.Pointer;
    // }
}