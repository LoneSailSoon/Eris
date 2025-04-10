using System.Runtime.InteropServices;
using PatcherYrSharp.GeneralDefinitions;
using PatcherYrSharp.GeneralStructures;
using PatcherYrSharp.Helpers;

namespace PatcherYrSharp;

[StructLayout(LayoutKind.Explicit, Size = 456)]
public struct AnimClass : IYrObject<AnimTypeClass>
{
	public const nint ArrayPointer = 0xA8E9A8;
	public static ref DynamicVectorClass<Pointer<AnimClass>> Array => ref DynamicVectorClass<Pointer<AnimClass>>.GetDynamicVector(ArrayPointer);

	Pointer<AnimTypeClass> IYrObject<AnimTypeClass>.Type => Type;


	public unsafe void SetOwnerObject(Pointer<ObjectClass> pOwner)
	{
		var func = (delegate* unmanaged[Thiscall]<nint, nint, void>)0x424B50;
		func(this.GetThisPointer(), pOwner);
	}

	public void Pause()
	{
		this.Paused = true;
		this.Unpaused = false;
		this.PausedAnimFrame = this.Animation.Value;
	}

	public void Unpause()
	{
		this.Paused = false;
		this.Unpaused = true;
	}

	public static void Constructor(Pointer<AnimClass> pThis, Pointer<AnimTypeClass> pAnimType, CoordStruct location)
	{
		Constructor(pThis, pAnimType, location, 0);
	}
	public static unsafe void Constructor(Pointer<AnimClass> pThis, Pointer<AnimTypeClass> pAnimType, CoordStruct location, int loopDelay = 0, 
		int loopCount = 1, uint flags = 0x600, int forceZAdjust = 0, bool reverse = false)
	{
		var func = (delegate* unmanaged[Thiscall]<nint, nint, nint, int,
			int, uint, int, bool, void>)0x421EA0;
		func(pThis, pAnimType, location.GetThisPointer(), loopDelay, loopCount, flags, forceZAdjust, reverse);
	}

	[FieldOffset(0)] public ObjectClass Base;
	[FieldOffset(0)] public AbstractClass BaseAbstract;


	[FieldOffset(172)] public ProgressTimer Animation;
	[FieldOffset(200)] public Pointer<AnimTypeClass> Type;
	[FieldOffset(204)] public Pointer<ObjectClass> OwnerObject;

	//[FieldOffset(212)] public Pointer<LightConvertClass> LightConvert;     //Palette?
	[FieldOffset(216)] public int LightConvertIndex; // assert( (*ColorScheme::Array)[this->LightConvertIndex] == this->LightConvert ;
	[FieldOffset(220)] public byte PaletteName_first; // filename set for destroy anims
	public AnsiStringPointer PaletteName => Pointer<byte>.AsPointer(ref PaletteName_first);
	[FieldOffset(252)] public int TintColor;
	[FieldOffset(256)] public int ZAdjust;
	[FieldOffset(260)] public int YSortAdjust; // same as YSortAdjust from Type
	[FieldOffset(264)] public CoordStruct FlamingGuyCoords; // the destination the anim tries to reach
	[FieldOffset(276)] public int FlamingGuyRetries; // number of failed attemts to reach water. the random destination generator stops if >= 7
	[FieldOffset(280)] public Bool IsBuildingAnim; // whether this anim will invalidate on buildings, and whether it's tintable
	[FieldOffset(281)] public Bool UnderTemporal; // temporal'd building's active anims
	[FieldOffset(282)] public Bool Paused; // if paused, does not advance anim, does not deliver damage
	[FieldOffset(283)] public Bool Unpaused; // set when unpaused
	[FieldOffset(284)] public int PausedAnimFrame; // the animation value when paused
	[FieldOffset(288)] public Bool Reverse; // anim is forced to be played from end to start

	//[FieldOffset(296)] public BounceClass Bounce;
	[FieldOffset(376)] public byte TranslucencyLevel; // on a scale of 1 - 100
	[FieldOffset(377)] public Bool TimeToDie; // or something to that effect, set just before UnInit
	[FieldOffset(380)] private nint attachedBullet;
	public Pointer<BulletClass> AttachedBullet { get => attachedBullet; set => attachedBullet = value; }

	[FieldOffset(384)] public Pointer<HouseClass> Owner; //Used for remap (AltPalette).
	[FieldOffset(388)] public int LoopDelay; // randomized value, depending on RandomLoopDelay
	[FieldOffset(392)] public double Damage; // defaults to 1.0 , added to Type->Damage in some cases
	[FieldOffset(400)] public BlitterFlags AnimFlags; // argument that's 0x600 most of the time
	[FieldOffset(404)] public Bool HasExtras; // enables IsMeteor and Bouncer special behavior (AnimExtras)
	[FieldOffset(405)] public int Loops; // defaulted to deleteAfterIterations, when reaches zero, UnInit() is called
	[FieldOffset(406)] public byte unknown_196;
	[FieldOffset(407)] public Bool ToDelete;
	[FieldOffset(408)] public Bool IsPlaying;
	[FieldOffset(409)] public Bool IsFogged;
	[FieldOffset(410)] public Bool FlamingGuyExpire; // finish animation and remove
	[FieldOffset(411)] public Bool UnableToContinue; // set when something prevents the anim from going on: cell occupied, veins destoyed or unit gone, ...
	[FieldOffset(412)] public Bool SkipProcessOnce; // set in constructor, cleared during Update. skips damage, veins, tiberium chain reaction and animation progress
	[FieldOffset(413)] public Bool Invisible; // don't draw, but Update state anyway
	[FieldOffset(414)] public Bool PowerOff; // powered animation has no power

	//[FieldOffset(416)] public AudioController Audio3;
	//[FieldOffset(436)] public AudioController Audio4;
}