using System.Collections;
using Eris.YRSharp.Vector;

namespace Eris.YRSharp.Utilities;

// Enumerates the cell offsets using the cell spread logic.
/*
    Enumeration starts at the center. Returned values are to be considered
    offsets, so the center is the origin.

    Offsets are returned in unspecified order, but all cells of CellSpread N
    are guaranteed to be returned before enumerating cells of N+1. This means
    that this class can extend or replace the original CellSpread table, as
    long as a single mechanism is used to complete a CellSpread distance.

    The algorithm does not generate any cell offset not in the requested
    CellSpread range.

    The following properties might change in the future:

    Currently, the implementation matches the output order of the original
    CellSpread table for values less than 11, except for the offsets 2 and 4
    (which are swapped here).

    The enumeration stops at Max not because of technical reasons, but because
    at some point is gets unfeasible to enumerate cell contents like this. A
    CellSpread of 256 contains 175789 cells. Input like 1000 to mean full map
    effect is a bad way to do something, and people should be punished for it.

    \author AlexB
*/
public class CellSpreadEnumerator : IEnumerable<CellStruct>, IEnumerator<CellStruct>
{
    public const uint Max = 0x100u;

    public CellStruct Current => _current;

    object IEnumerator.Current => Current;

    public CellSpreadEnumerator(uint spread, uint start = 0u)
    {
        this._spread = spread;

        if (spread > Max)
        {
            this._spread = Max;
        }

        Reset(start);
    }

    public bool HasNext()
    {
        return _curspread <= _spread;
    }

    public void Reset(uint radius)
    {
        _curspread = radius;
        _current.X = (short)(radius != 0 ? -1 : 0);
        _current.Y = (short)-radius;
        _hasTwo = true;
        _hadTwo = true;
    }

    public void Reset()
    {
        Reset(0);
    }


    public bool MoveNext()
    {
        // already done?
        if (!HasNext())
        {
            return false;
        }

        // center or top-right-most cell finishes this
        // round. move to the start of the next one.
        if (_current == default || (_current.X == 1 && _current.Y == (short)_curspread))
        {
            Reset(_curspread + 1);
            return HasNext();
        }

        // finish this line
        if (_hasTwo)
        {
            _current.X++;

            // quick way to finish first and last line
            _hasTwo = _current.X == 0;
            return true;
        }

        // if we are on the left side, mirror to the
        // right side and restore hasTwo.
        if (_current.X < 0)
        {
            _current.X = (short)-_current.X;
            _hasTwo = _hadTwo;
            return true;
        }

        // move up to the next line
        _current.Y++;

        // map upper part to lower part
        // this is reverted later
        bool changeSign = _current.Y > 0;
        if (changeSign)
        {
            _current.Y = (short)-_current.Y;
        }

        // for each line up, go two steps left
        _current.X = (short)(((short)_curspread + _current.Y) * -2 - 1);

        int diff = _current.X - _current.Y;
        _hasTwo = diff >= 0;
        _hadTwo = _hasTwo;

        if (diff == -1)
        {
            // "clip" the one
            _current.X++;
        }
        else if (diff < 0)
        {
            // get from other direction
            _current.X = (short)(-_current.Y / 2 - (short)_curspread);
        }

        // revert the sign change
        if (changeSign)
        {
            _current.Y = (short)-_current.Y;
        }

        return true;
    }

    public void Dispose()
    {
    }

    public IEnumerator<CellStruct> GetEnumerator() => this;
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();


    private CellStruct _current;
    private readonly uint _spread;
    private uint _curspread;
    private bool _hasTwo;
    private bool _hadTwo;
}

// public class RandomCellEnumerator : IEnumerable<CellStruct>, IEnumerator<CellStruct>
// {
//     public CellStruct Current => GetRandomCell();
//
//     object IEnumerator.Current => Current;
//
//     public RandomCellEnumerator(int range, int cellCount)
//     {
//         _range = range;
//         _cellCount = cellCount;
//
//         Reset();
//     }
//
//     private CellStruct GetRandomCell()
//     {
//         CellStruct tmp;
//         CoordStruct offset;
//         Random random = MathEx.MathUtilities.Random;
//         do
//         {
//             offset = new CoordStruct(random.Next(-_range, _range + 1), random.Next(-_range, _range + 1), 0);
//             tmp = CellClass.Coord2Cell(offset);
//         } while (offset.DistanceFrom(new CoordStruct(0, 0, 0)) > _range);
//
//         return tmp;
//     }
//
//     public bool MoveNext()
//     {
//         if (_curCell < _cellCount)
//         {
//             _curCell++;
//             return true;
//         }
//
//         return false;
//     }
//
//     public void Reset()
//     {
//         _curCell = 0;
//     }
//
//
//     public void Dispose()
//     {
//     }
//
//     public IEnumerator<CellStruct> GetEnumerator() => this;
//     IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
//
//     private int _curCell;
//     private readonly int _range;
//     private readonly int _cellCount;
// }