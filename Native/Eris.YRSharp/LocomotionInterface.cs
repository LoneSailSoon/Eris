using Eris.YRSharp.GeneralDefinitions;
using Eris.YRSharp.GeneralStructures;
using Eris.YRSharp.Helpers;
using Eris.YRSharp.Vector;

namespace Eris.YRSharp;

public interface ILocomotion;

public static class Locomotion
{
	public static unsafe uint
		Link_To_Object(this ComPointer<ILocomotion> pThis, nint pointer) //Links object to locomotor.
	{
		return ((delegate*unmanaged[Stdcall]<nint, nint, uint>)pThis.VTable[3])(pThis, pointer);
	}

	public static unsafe bool Is_Moving(this ComPointer<ILocomotion> pThis) //Sees if object is moving.
	{
		return ((delegate*unmanaged[Stdcall]<nint, bool>)pThis.VTable[4])(pThis);
	}

	public static unsafe CoordStruct Destination(this ComPointer<ILocomotion> pThis) //Fetches destination coordinate.
	{
		CoordStruct tmp = default;
		((delegate*unmanaged[Stdcall]<nint, nint, uint>)pThis.VTable[5])(pThis, tmp.GetThisPointer());
		return tmp;
	}

	public static unsafe CoordStruct
		Head_To_Coord(this ComPointer<ILocomotion> pThis) // Fetches immediate (next cell) destination coordinate.
	{
		CoordStruct tmp = default;
		((delegate*unmanaged[Stdcall]<nint, nint, uint>)pThis.VTable[6])(pThis, tmp.GetThisPointer());
		return tmp;

	}

	public static unsafe Move Can_Enter_Cell(this ComPointer<ILocomotion> pThis, CoordStruct coord)
	{
		return (Move)((delegate*unmanaged[Stdcall]<nint, nint, int>)pThis.VTable[7])(pThis, coord.GetThisPointer());
	}

	public static unsafe bool Is_To_Have_Shadow(this ComPointer<ILocomotion> pThis)
	{
		return ((delegate*unmanaged[Stdcall]<nint, bool>)pThis.VTable[8])(pThis);
	}

	public static unsafe Matrix3D Draw_Matrix(this ComPointer<ILocomotion> pThis, nint pIndex)
	{
		Matrix3D tmp = default;
		((delegate*unmanaged[Stdcall]<nint, nint, nint, nint>)pThis.VTable[9])(pThis, tmp.GetThisPointer(), pIndex);
		return tmp;
	}

	public static unsafe Matrix3D Shadow_Matrix(this ComPointer<ILocomotion> pThis, nint pIndex)
	{
		Matrix3D tmp = default;
		((delegate*unmanaged[Stdcall]<nint, nint, nint, nint>)pThis.VTable[10])(pThis, tmp.GetThisPointer(), pIndex);
		return tmp;
	}

	public static unsafe Point2D Draw_Point(this ComPointer<ILocomotion> pThis)
	{
		Point2D tmp = default;
		((delegate*unmanaged[Stdcall]<nint, nint, nint>)pThis.VTable[11])(pThis, tmp.GetThisPointer());
		return tmp;
	}

	public static unsafe Point2D Shadow_Point(this ComPointer<ILocomotion> pThis)
	{
		Point2D tmp = default;
		((delegate*unmanaged[Stdcall]<nint, nint, nint>)pThis.VTable[12])(pThis, tmp.GetThisPointer());
		return tmp;
	}

	public static unsafe VisualType Visual_Character(this ComPointer<ILocomotion> pThis, bool unused)
	{
		return (VisualType)((delegate*unmanaged[Stdcall]<nint, ushort, int>)pThis.VTable[13])(pThis,
			unused ? (ushort)1 : (ushort)0);
	}

	public static unsafe int Z_Adjust(this ComPointer<ILocomotion> pThis)
	{
		return ((delegate*unmanaged[Stdcall]<nint, int>)pThis.VTable[14])(pThis);
	}

	public static unsafe ZGradient Z_Gradient(this ComPointer<ILocomotion> pThis)
	{
		return (ZGradient)((delegate*unmanaged[Stdcall]<nint, int>)pThis.VTable[15])(pThis);
	}

	public static unsafe bool Process(this ComPointer<ILocomotion> pThis)
	{
		return ((delegate*unmanaged[Stdcall]<nint, bool>)pThis.VTable[16])(pThis);
	}

	public static unsafe void Move_To(this ComPointer<ILocomotion> pThis, CoordStruct coord)
	{
		((delegate*unmanaged[Stdcall]<nint, nint, void>)pThis.VTable[17])(pThis, coord.GetThisPointer());
	}

	public static unsafe void Stop_Moving(this ComPointer<ILocomotion> pThis)
	{
		((delegate*unmanaged[Stdcall]<nint, void>)pThis.VTable[18])(pThis);
	}

	public static unsafe void Do_Turn(this ComPointer<ILocomotion> pThis, DirStruct direction)
	{
		((delegate*unmanaged[Stdcall]<nint, DirStruct, void>)pThis.VTable[19])(pThis, direction);
	}

	public static unsafe void Unlimbo(this ComPointer<ILocomotion> pThis)
	{
		((delegate*unmanaged[Stdcall]<nint, void>)pThis.VTable[20])(pThis);
	}

	public static unsafe void Tilt_Pitch_AI(this ComPointer<ILocomotion> pThis)
	{
		((delegate*unmanaged[Stdcall]<nint, void>)pThis.VTable[21])(pThis);
	}

	public static unsafe bool Power_On(this ComPointer<ILocomotion> pThis)
	{
		return ((delegate*unmanaged[Stdcall]<nint, bool>)pThis.VTable[22])(pThis);
	}

	public static unsafe bool Power_Off(this ComPointer<ILocomotion> pThis)
	{
		return ((delegate*unmanaged[Stdcall]<nint, bool>)pThis.VTable[23])(pThis);
	}

	public static unsafe bool Is_Powered(this ComPointer<ILocomotion> pThis)
	{
		return ((delegate*unmanaged[Stdcall]<nint, bool>)pThis.VTable[24])(pThis);
	}

	public static unsafe bool Is_Ion_Sensitive(this ComPointer<ILocomotion> pThis)
	{
		return ((delegate*unmanaged[Stdcall]<nint, bool>)pThis.VTable[25])(pThis);
	}

	public static unsafe bool Push(this ComPointer<ILocomotion> pThis, DirStruct direction)
	{
		return ((delegate*unmanaged[Stdcall]<nint, DirStruct, bool>)pThis.VTable[26])(pThis, direction);
	}

	public static unsafe bool Shove(this ComPointer<ILocomotion> pThis, DirStruct direction)
	{
		return ((delegate*unmanaged[Stdcall]<nint, DirStruct, bool>)pThis.VTable[27])(pThis, direction);
	}

	public static unsafe void Force_Track(this ComPointer<ILocomotion> pThis, int track, CoordStruct coord)
	{
		((delegate*unmanaged[Stdcall]<nint, int, CoordStruct, void>)pThis.VTable[28])(pThis, track, coord);
	}

	public static unsafe Layer In_Which_Layer(this ComPointer<ILocomotion> pThis)
	{
		return (Layer)((delegate*unmanaged[Stdcall]<nint, int>)pThis.VTable[29])(pThis);
	}

	public static unsafe void Force_Immediate_Destination(this ComPointer<ILocomotion> pThis, CoordStruct coord)
	{
		((delegate*unmanaged[Stdcall]<nint, CoordStruct, void>)pThis.VTable[30])(pThis, coord);
	}

	public static unsafe void Force_New_Slope(this ComPointer<ILocomotion> pThis, int ramp)
	{
		((delegate*unmanaged[Stdcall]<nint, int, void>)pThis.VTable[31])(pThis, ramp);
	}

	public static unsafe bool Is_Moving_Now(this ComPointer<ILocomotion> pThis)
	{
		return ((delegate*unmanaged[Stdcall]<nint, bool>)pThis.VTable[32])(pThis);
	}

	public static unsafe int Apparent_Speed(this ComPointer<ILocomotion> pThis)
	{
		return ((delegate*unmanaged[Stdcall]<nint, int>)pThis.VTable[33])(pThis);
	}

	public static unsafe int Drawing_Code(this ComPointer<ILocomotion> pThis)
	{
		return ((delegate*unmanaged[Stdcall]<nint, int>)pThis.VTable[34])(pThis);
	}

	public static unsafe FireError Can_Fire(this ComPointer<ILocomotion> pThis)
	{
		return (FireError)((delegate*unmanaged[Stdcall]<nint, int>)pThis.VTable[35])(pThis);
	}

	public static unsafe int Get_Status(this ComPointer<ILocomotion> pThis)
	{
		return ((delegate*unmanaged[Stdcall]<nint, int>)pThis.VTable[36])(pThis);
	}

	public static unsafe void Acquire_Hunter_Seeker_Target(this ComPointer<ILocomotion> pThis)
	{
		((delegate*unmanaged[Stdcall]<nint, void>)pThis.VTable[37])(pThis);
	}

	public static unsafe bool Is_Surfacing(this ComPointer<ILocomotion> pThis)
	{
		return ((delegate*unmanaged[Stdcall]<nint, bool>)pThis.VTable[38])(pThis);
	}

	public static unsafe void Mark_All_Occupation_Bits(this ComPointer<ILocomotion> pThis, int mark)
	{
		((delegate*unmanaged[Stdcall]<nint, int, void>)pThis.VTable[39])(pThis, mark);
	}

	public static unsafe bool Mark_All_Occupation_Bits(this ComPointer<ILocomotion> pThis, CoordStruct to)
	{
		return ((delegate*unmanaged[Stdcall]<nint, CoordStruct, bool>)pThis.VTable[40])(pThis, to);
	}

	public static unsafe bool Will_Jump_Tracks(this ComPointer<ILocomotion> pThis)
	{
		return ((delegate*unmanaged[Stdcall]<nint, bool>)pThis.VTable[41])(pThis);
	}

	public static unsafe bool Is_Really_Moving_Now(this ComPointer<ILocomotion> pThis)
	{
		return ((delegate*unmanaged[Stdcall]<nint, bool>)pThis.VTable[42])(pThis);
	}

	public static unsafe void Stop_Movement_Animation(this ComPointer<ILocomotion> pThis)
	{
		((delegate*unmanaged[Stdcall]<nint, void>)pThis.VTable[43])(pThis);
	}

	public static unsafe void Lock(this ComPointer<ILocomotion> pThis)
	{
		((delegate*unmanaged[Stdcall]<nint, void>)pThis.VTable[44])(pThis);
	}

	public static unsafe void Unlock(this ComPointer<ILocomotion> pThis)
	{
		((delegate*unmanaged[Stdcall]<nint, void>)pThis.VTable[45])(pThis);
	}

	public static unsafe void ILocomotion_B8(this ComPointer<ILocomotion> pThis)
	{
		((delegate*unmanaged[Stdcall]<nint, void>)pThis.VTable[46])(pThis);
	}

	public static unsafe int Get_Track_Number(this ComPointer<ILocomotion> pThis)
	{
		return ((delegate*unmanaged[Stdcall]<nint, int>)pThis.VTable[47])(pThis);
	}

	public static unsafe int Get_Track_Index(this ComPointer<ILocomotion> pThis)
	{
		return ((delegate*unmanaged[Stdcall]<nint, int>)pThis.VTable[48])(pThis);
	}

	public static unsafe int Get_Speed_Accum(this ComPointer<ILocomotion> pThis)
	{
		return ((delegate*unmanaged[Stdcall]<nint, int>)pThis.VTable[49])(pThis);
	}

	public static Pointer<LocomotionClass> ToLocomotionClass(this ComPointer<ILocomotion> pThis) => (nint)pThis - 4;
}

public interface IPiggyback;

public static class Piggyback
{
	public static unsafe void
		Begin_Piggyback(this ComPointer<IPiggyback> pThis,
			ComPointer<ILocomotion> locomotion) //Piggybacks a locomotor onto this one.
	{
		((delegate*unmanaged[Stdcall]<nint, nint, void>)pThis.VTable[3])(pThis, locomotion);
	}

	public static unsafe void
		End_Piggyback(this ComPointer<IPiggyback> pThis,
			out ComPointer<ILocomotion> locomotion) //End piggyback process and restore locomotor interface pointer.
	{
		locomotion = default;
		((delegate*unmanaged[Stdcall]<nint, nint, void>)pThis.VTable[4])(pThis, locomotion.GetThisPointer());
	}

	public static unsafe bool Is_Ok_To_End(this ComPointer<IPiggyback> pThis) //Is it ok to end the piggyback process?
	{
		return ((delegate*unmanaged[Stdcall]<nint, bool>)pThis.VTable[5])(pThis);
	}

	public static unsafe void Piggyback_CLSID(this ComPointer<IPiggyback> pThis, out Guid classid) //Fetches piggybacked locomotor class ID.
	{
		classid = Guid.Empty;
		((delegate*unmanaged[Stdcall]<nint, nint, void>)pThis.VTable[6])(pThis, classid.GetThisPointer());
	}

	public static unsafe bool Is_Piggybacking(this ComPointer<IPiggyback> pThis) //Is it currently piggy backing another locomotor?
	{
		return ((delegate*unmanaged[Stdcall]<nint, bool>)pThis.VTable[3])(pThis);
	}
}
