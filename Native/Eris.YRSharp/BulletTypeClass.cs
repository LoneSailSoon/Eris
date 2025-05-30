﻿using System.Runtime.InteropServices;
using Eris.YRSharp.Helpers;

namespace Eris.YRSharp;

[StructLayout(LayoutKind.Explicit, Size = 760)]
public struct BulletTypeClass
{
	public const nint ArrayPointer = 0xA83C80;

	public static GlobalDvcArray<BulletTypeClass> AbstractTypeArray { get; } = new(ArrayPointer);

	public unsafe Pointer<BulletClass> CreateBullet(Pointer<AbstractClass> target, Pointer<TechnoClass> owner, int damage, Pointer<WarheadTypeClass> wh, int speed, bool bright)
	{
		var func = (delegate* unmanaged[Thiscall]<nint, /*Pointer<AbstractClass> @edx, */nint, int, nint, int , bool, nint>)0x46B050;

		Pointer<BulletClass> ret = func(this.GetThisPointer(), owner, damage, wh, speed, bright);
		ret.Ref.Target = target;
		return ret;
	}

	[FieldOffset(0)] public ObjectTypeClass Base;
	[FieldOffset(0)] public AbstractTypeClass BaseAbstractType;

	[FieldOffset(660)] public Bool Airburst;
	[FieldOffset(661)] public Bool Floater;
	[FieldOffset(662)] public Bool SubjectToCliffs;
	[FieldOffset(663)] public Bool SubjectToElevation;
	[FieldOffset(664)] public Bool SubjectToWalls;
	[FieldOffset(665)] public Bool VeryHigh;
	[FieldOffset(666)] public Bool Shadow;
	[FieldOffset(667)] public Bool Arcing;
	[FieldOffset(668)] public Bool Dropping;
	[FieldOffset(669)] public Bool Level;
	[FieldOffset(670)] public Bool Inviso;
	[FieldOffset(671)] public Bool Proximity;
	[FieldOffset(672)] public Bool Ranged;
	[FieldOffset(673)] public Bool NoRotate; // actually has opposite meaning of Rotates. false means Rotates=yes.
	[FieldOffset(674)] public Bool Inaccurate;
	[FieldOffset(675)] public Bool FlakScatter;
	[FieldOffset(676)] public Bool AA;
	[FieldOffset(677)] public Bool AG;
	[FieldOffset(678)] public Bool Degenerates;
	[FieldOffset(679)] public Bool Bouncy;
	[FieldOffset(680)] public Bool AnimPalette;
	[FieldOffset(681)] public Bool FirersPalette;

	[FieldOffset(684)] public int Cluster;
	[FieldOffset(688)] public Pointer<WeaponTypeClass> AirburstWeapon;
	[FieldOffset(692)] public Pointer<WeaponTypeClass> ShrapnelWeapon;
	[FieldOffset(696)] public int ShrapnelCount;
	[FieldOffset(700)] public int DetonationAltitude;
	[FieldOffset(704)] public Bool Vertical;

	[FieldOffset(712)] public double Elasticity;
	[FieldOffset(720)] public int Acceleration;
	//[FieldOffset(724)] public Pointer<ColorScheme> Color;
	[FieldOffset(728)] public Pointer<AnimTypeClass> Trailer;
	[FieldOffset(732)] public int ROT;
	[FieldOffset(736)] public int CourseLockDuration;
	[FieldOffset(740)] public int SpawnDelay;
	[FieldOffset(744)] public int ScaledSpawnDelay;
	[FieldOffset(748)] public Bool Scalable;

	[FieldOffset(752)] public int Arm;
	[FieldOffset(756)] public byte AnimLow;	 // not bool
	[FieldOffset(757)] public byte AnimHigh; // not bool
	[FieldOffset(758)] public byte AnimRate; // not bool
	[FieldOffset(759)] public Bool Flat;
}