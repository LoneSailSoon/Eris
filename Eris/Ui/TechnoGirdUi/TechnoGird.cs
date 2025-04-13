using Eris.Ui.NaegleriaUi;
using PatcherYrSharp;
using PatcherYrSharp.GeneralDefinitions;
using PatcherYrSharp.GeneralStructures;
using PatcherYrSharp.Helpers;
using PatcherYrSharp.Utilities;
using System.Linq;

namespace Eris.Ui.TechnoGirdUi;

public static class TechnoGird
{
    private static bool _rightDown = false;
    private static bool _leftDown = false;
    private static bool _actived = false;

    private static Point2D? _start = null;
    private static Point2D? _end = null;

    public static bool ProcessMouseButtonEvent(bool botton, Point2D mousePos, bool isDouble, bool down)
    {
        if (down)
        {
            if (botton)
            {
                _leftDown = true;
            }
            else
            {
                _rightDown = true;
            }
        }
        else
        {
            if (_rightDown && _leftDown)
            {
                if (_start is not null && _end is not null)
                {
                    //pSurface.Ref.DrawLine(_start.Value, _end.Value, (255, 255, 255));

                    var coord = NaegleriaUiMissionManager.ClientToCoord(_start.Value);
                    //ShowPos(pSurface, TacticalClass.Instance.CoordsToClient(coord));

                    if (ObjectClass.CurrentObjects.Count > 0)
                    {
                        var technos = ObjectClass.CurrentObjects.Select(o =>
                                o.AsNullable?.CastToTechno(out var pTechno) ?? false
                                    ? pTechno
                                    : Pointer<TechnoClass>.Zero)
                            .Where(o => o.IsNotNull &&
                                        o.Ref.BaseAbstract.WhatAmI() is AbstractType.Unit or AbstractType.Infantry &&
                                        o.Ref.Owner.Ref.ArrayIndex == HouseClass.Player.Ref.ArrayIndex)
                            .ToArray();

                        if (technos.Length != 0)
                        {
                            var offset = _end.Value - _start.Value;
                            if (offset != default)
                            {
                                var rad = Math.Atan2(offset.X, offset.Y);

                                var face = 16 - (int)Math.Round((Math.PI - rad) * 8 / Math.PI);


                                var index = (face + 4) % 16;
                                var (f1, f2) = (Offsets[index, 0], Offsets[index, 1]);

                                int i = 0;

                                int technoIndex = 0;
                                //var right = technos.Length / 2 + 1;
                                //var coordRight = coord;


                                //for (; i < right; i++)
                                //{
                                //    ShowPos(pSurface, TacticalClass.Instance.CoordsToClient(coordRight));

                                //    if (i % 2 == 0)
                                //    {
                                //        coordRight += (f2.x * 256, f2.y * 256, 0);
                                //    }
                                //    else
                                //    {
                                //        coordRight += (f1.x * 256, f1.y * 256, 0);
                                //    }
                                //}

                                //var coordLeft = coord;
                                //for (; i < technos.Length; i++)
                                //{
                                //    if (i % 2 == 0)
                                //    {
                                //        coordLeft -= (f2.x * 256, f2.y * 256, 0);
                                //    }
                                //    else
                                //    {
                                //        coordLeft -= (f1.x * 256, f1.y * 256, 0);
                                //    }

                                //    ShowPos(pSurface, TacticalClass.Instance.CoordsToClient(coordLeft));

                                //}

                                var length = face % 16;
                                var (l1, l2) = (Offsets[length, 0], Offsets[length, 1]);

                                var l = Math.Max(Math.Sqrt(offset.X * offset.X + offset.Y * offset.Y) / 30, 1.0);
                                l = Math.Ceiling(Math.Sqrt(technos.Length / l));


                                var count = 0;
                                var width = (int)Math.Ceiling(technos.Length / l);
                                var halfWidth = width / 2 + 1;

                                var coordLength = coord;
                                for (i = 0; i < l; i++)
                                {
                                    //ShowPos(pSurface, TacticalClass.Instance.CoordsToClient(coordLength));
                                    var coordRight = coordLength;
                                    var coordLeft = coordLength;

                                    int j = 0;

                                    if (count + width <= technos.Length)
                                    {
                                        for (; j < halfWidth; j++)
                                        {
                                            if (MapClass.Instance.TryGetCellAt(coordRight, out var pCell))
                                            {
                                                MoveTo(technos[technoIndex], pCell);
                                            }

                                            //ShowPos(pSurface, TacticalClass.Instance.CoordsToClient(coordRight));
                                            technoIndex++;
                                            if (j % 2 == 0)
                                            {
                                                coordRight += (f2.x * 256, f2.y * 256, 0);
                                            }
                                            else
                                            {
                                                coordRight += (f1.x * 256, f1.y * 256, 0);
                                            }
                                        }


                                        for (; j < width; j++)
                                        {
                                            if (j % 2 == 0)
                                            {
                                                coordLeft -= (f2.x * 256, f2.y * 256, 0);
                                            }
                                            else
                                            {
                                                coordLeft -= (f1.x * 256, f1.y * 256, 0);
                                            }

                                            if (MapClass.Instance.TryGetCellAt(coordLeft, out var pCell))
                                            {
                                                MoveTo(technos[technoIndex], pCell);
                                            }

                                            //ShowPos(pSurface, TacticalClass.Instance.CoordsToClient(coordLeft));
                                            technoIndex++;
                                        }
                                    }
                                    else if (technos.Length - count > 0)
                                    {
                                        for (; j < (technos.Length - count) / 2 + 1; j++)
                                        {
                                            if (MapClass.Instance.TryGetCellAt(coordRight, out var pCell))
                                            {
                                                MoveTo(technos[technoIndex], pCell);
                                            }

                                            //ShowPos(pSurface, TacticalClass.Instance.CoordsToClient(coordRight));
                                            technoIndex++;
                                            if (j % 2 == 0)
                                            {
                                                coordRight += (f2.x * 256, f2.y * 256, 0);
                                            }
                                            else
                                            {
                                                coordRight += (f1.x * 256, f1.y * 256, 0);
                                            }
                                        }


                                        for (; j < technos.Length - count; j++)
                                        {
                                            if (j % 2 == 0)
                                            {
                                                coordLeft -= (f2.x * 256, f2.y * 256, 0);
                                            }
                                            else
                                            {
                                                coordLeft -= (f1.x * 256, f1.y * 256, 0);
                                            }

                                            if (MapClass.Instance.TryGetCellAt(coordLeft, out var pCell))
                                            {
                                                MoveTo(technos[technoIndex], pCell);
                                            }


                                            //ShowPos(pSurface, TacticalClass.Instance.CoordsToClient(coordLeft));
                                            technoIndex++;
                                        }
                                    }


                                    count += width;
                                    if (i % 2 == 0)
                                    {
                                        coordLength -= (l2.x * 256, l2.y * 256, 0);
                                    }
                                    else
                                    {
                                        coordLength -= (l1.x * 256, l1.y * 256, 0);
                                    }
                                }
                                //int i = 0;
                                //for (; i < right; i++)
                                //{
                                //    //ShowPos(pSurface, TacticalClass.Instance.CoordsToClient(coordRight));
                                //    var techno = technos[i];

                                //    if (MapClass.Instance.TryGetCellAt(coordRight, out var pCell))
                                //    {
                                //        MoveTo(techno, pCell);
                                //    }


                                //    if (i % 2 == 0)
                                //    {
                                //        coordRight += (f2.x * 256, f2.y * 256, 0);
                                //    }
                                //    else
                                //    {
                                //        coordRight += (f1.x * 256, f1.y * 256, 0);
                                //    }
                                //}

                                //var coordLeft = coord;
                                //for (; i < technos.Length; i++)
                                //{
                                //    if (i % 2 == 0)
                                //    {
                                //        coordLeft -= (f2.x * 256, f2.y * 256, 0);
                                //    }
                                //    else
                                //    {
                                //        coordLeft -= (f1.x * 256, f1.y * 256, 0);
                                //    }

                                //    //ShowPos(pSurface, TacticalClass.Instance.CoordsToClient(coordLeft));
                                //    var techno = technos[i];

                                //    if (MapClass.Instance.TryGetCellAt(coordLeft, out var pCell))
                                //    {
                                //        MoveTo(techno, pCell);
                                //    }

                                //}

                                //Console.WriteLine((DisplayClass.pInstance + 0x555A).Convert<byte>().Data);
                                var pbyte = (DisplayClass.pInstance + 0x555A).Convert<byte>();
                                if (pbyte.Ref != 0)
                                {
                                    //11CF

                                    var pIsRect = (DisplayClass.pInstance + 0x11CF).Convert<byte>();
                                    //Sub6DA080();
                                    //Sub6D9FF0();
                                    TacticalClass.Instance.Band = default;
                                    pIsRect.Ref = 0;

                                    DisplayClass.Instance.RightMouseButtonUp(0);
                                    pbyte.Ref = 0;

                                    foreach (var technno in technos)
                                    {
                                        technno.Ref.Base.Select();
                                    }
                                    //ReleaseCapture();
                                }

                                _actived = true;

                                //DisplayClass.Instance.RightMouseButtonUp(0);
                                //ReleaseCapture();
                                //foreach(var technno in technos)
                                //{
                                //    technno.Ref.Base.Select();
                                //}

                                //coord += (f1.x * 256, f1.y * 256, 0);
                                //
                                //ShowPos(pSurface, TacticalClass.Instance.CoordsToClient(coord));
                                //
                                //coord += (f2.x * 256, f2.y * 256, 0);
                                //
                                //ShowPos(pSurface, TacticalClass.Instance.CoordsToClient(coord));
                                static void MoveTo(Pointer<TechnoClass> techno, Pointer<CellClass> cell)
                                {
                                    EventClass @event = new();

                                    @event.Type = EventType.Megamission;
                                    @event.HouseIndex = (byte)HouseClass.Player.Ref.ArrayIndex;
                                    @event.Frame = (uint)Game.CurrentFrame;
                                    @event.Data.MegaMission.Whom = new TargetClass()
                                        .Pack_AbstractClass(techno.Cast<AbstractClass>()).Data;
                                    @event.Data.MegaMission.Mission = (byte)Mission.Move;
                                    @event.Data.MegaMission.Destination =
                                        new TargetClass().Pack_CellStruct(cell.Ref.MapCoords)
                                            .Data; // @event.Data.MegaMission.Target;

                                    @event.Data.MegaMission.Follow = new()
                                        { m_ID = @event.Data.MegaMission.Destination.m_ID };


                                    //@event.EventClass_MegaMission(,s
                                    //    , Mission.Enter,
                                    //    , default,
                                    //    default);
                                    EventClass.AddEvent(@event);
                                }
                                //6DA080
                            }
                        }
                    }
                }
            }


            var ret = false;
            if (botton)
            {
                _leftDown = false;
            }
            else
            {
                _rightDown = false;
            }

            ret = _actived;
            if (!_rightDown && !_leftDown)
            {
                _actived = false;
            }

            if (ret)
            {
            }


            return ret;
        }

        return false;
    }

    public static bool Update(Point2D point)
    {
        if (_rightDown && _leftDown)
        {
            _start ??= point;
            _end = point;
        }
        else
        {
            _start = null;
            _end = null;
        }

        return _rightDown && _leftDown;
    }

    public static void Render(Pointer<Surface> pSurface)
    {
        if (_start is not null && _end is not null)
        {
            //pSurface.Ref.DrawLine(_start.Value, _end.Value, (255, 255, 255));
            var cellSize = 256;
            var coord = NaegleriaUiMissionManager.ClientToCoord(_start.Value);
            //ShowPos(pSurface, TacticalClass.Instance.CoordsToClient(coord));

            if (ObjectClass.CurrentObjects.Count > 0)
            {
                var technos = ObjectClass.CurrentObjects.Select(o =>
                        o.AsNullable?.CastToTechno(out var pTechno) ?? false ? pTechno : Pointer<TechnoClass>.Zero)
                    .Where(o => o.IsNotNull &&
                                o.Ref.BaseAbstract.WhatAmI() is AbstractType.Unit or AbstractType.Infantry &&
                                o.Ref.Owner.Ref.ArrayIndex == HouseClass.Player.Ref.ArrayIndex)
                    .ToArray();


                if (technos.Length != 0)
                {
                    var offset = _end.Value - _start.Value;
                    if (offset != default)
                    {
                        var rad = Math.Atan2(offset.X, offset.Y);
                        var dir = MathEx.Radians2Dir(rad + Math.PI * 1.25);

                        var face = 16 - (int)Math.Round((Math.PI - rad) * 8 / Math.PI);


                        var index = (face + 4) % 16;
                        var (f1, f2) = (Offsets[index, 0], Offsets[index, 1]);

                        int i = 0;

                        int technoIndex = 0;
                        //var right = technos.Length / 2 + 1;
                        //var coordRight = coord;


                        //for (; i < right; i++)
                        //{
                        //    ShowPos(pSurface, TacticalClass.Instance.CoordsToClient(coordRight));

                        //    if (i % 2 == 0)
                        //    {
                        //        coordRight += (f2.x * 256, f2.y * 256, 0);
                        //    }
                        //    else
                        //    {
                        //        coordRight += (f1.x * 256, f1.y * 256, 0);
                        //    }
                        //}

                        //var coordLeft = coord;
                        //for (; i < technos.Length; i++)
                        //{
                        //    if (i % 2 == 0)
                        //    {
                        //        coordLeft -= (f2.x * 256, f2.y * 256, 0);
                        //    }
                        //    else
                        //    {
                        //        coordLeft -= (f1.x * 256, f1.y * 256, 0);
                        //    }

                        //    ShowPos(pSurface, TacticalClass.Instance.CoordsToClient(coordLeft));

                        //}

                        var length = face % 16;
                        var (l1, l2) = (Offsets[length, 0], Offsets[length, 1]);

                        var l = Math.Max(Math.Sqrt(offset.X * offset.X + offset.Y * offset.Y) / 30, 1.0);
                        l = Math.Ceiling(Math.Sqrt(technos.Length / l));


                        var count = 0;
                        var width = (int)Math.Ceiling(technos.Length / l);
                        var halfWidth = width / 2 + 1;

                        var coordLength = coord;
                        for (i = 0; i < l; i++)
                        {
                            //ShowPos(pSurface, TacticalClass.Instance.CoordsToClient(coordLength));
                            var coordRight = coordLength;
                            var coordLeft = coordLength;

                            int j = 0;

                            if (count + width <= technos.Length)
                            {
                                for (; j < halfWidth; j++)
                                {
                                    ShowPos(pSurface, TacticalClass.Instance.CoordsToClient(coordRight));

                                    //technos[technoIndex].Ref.Base.DrawIt(TacticalClass.Instance.CoordsToClient(coordRight), Surface.ViewBound);

                                    DrawTechno(technos[technoIndex], coordRight, dir);

                                    technoIndex++;
                                    if (j % 2 == 0)
                                    {
                                        coordRight += (f2.x * cellSize, f2.y * cellSize, 0);
                                    }
                                    else
                                    {
                                        coordRight += (f1.x * cellSize, f1.y * cellSize, 0);
                                    }
                                }


                                for (; j < width; j++)
                                {
                                    if (j % 2 == 0)
                                    {
                                        coordLeft -= (f2.x * cellSize, f2.y * cellSize, 0);
                                    }
                                    else
                                    {
                                        coordLeft -= (f1.x * cellSize, f1.y * cellSize, 0);
                                    }

                                    ShowPos(pSurface, TacticalClass.Instance.CoordsToClient(coordLeft));


                                    //technos[technoIndex].Ref.Base.DrawIt(TacticalClass.Instance.CoordsToClient(coordLeft), Surface.ViewBound);

                                    DrawTechno(technos[technoIndex], coordLeft, dir);

                                    technoIndex++;
                                }
                            }
                            else if (technos.Length - count > 0)
                            {
                                for (; j < (technos.Length - count) / 2 + 1; j++)
                                {
                                    ShowPos(pSurface, TacticalClass.Instance.CoordsToClient(coordRight));

                                    //technos[technoIndex].Ref.Base.DrawIt(TacticalClass.Instance.CoordsToClient(coordRight), Surface.ViewBound);

                                    DrawTechno(technos[technoIndex], coordRight, dir);


                                    technoIndex++;
                                    if (j % 2 == 0)
                                    {
                                        coordRight += (f2.x * cellSize, f2.y * cellSize, 0);
                                    }
                                    else
                                    {
                                        coordRight += (f1.x * cellSize, f1.y * cellSize, 0);
                                    }
                                }


                                for (; j < technos.Length - count; j++)
                                {
                                    if (j % 2 == 0)
                                    {
                                        coordLeft -= (f2.x * cellSize, f2.y * cellSize, 0);
                                    }
                                    else
                                    {
                                        coordLeft -= (f1.x * cellSize, f1.y * cellSize, 0);
                                    }

                                    ShowPos(pSurface, TacticalClass.Instance.CoordsToClient(coordLeft));

                                    //technos[technoIndex].Ref.Base.DrawIt(TacticalClass.Instance.CoordsToClient(coordLeft), Surface.ViewBound);
                                    DrawTechno(technos[technoIndex], coordLeft, dir);


                                    technoIndex++;
                                }
                            }


                            count += width;
                            if (i % 2 == 0)
                            {
                                coordLength -= (l2.x * 256, l2.y * 256, 0);
                            }
                            else
                            {
                                coordLength -= (l1.x * 256, l1.y * 256, 0);
                            }
                        }
                        //Console.WriteLine(technoIndex);
                        //coord += (f1.x * 256, f1.y * 256, 0);
                        //
                        //ShowPos(pSurface, TacticalClass.Instance.CoordsToClient(coord));
                        //
                        //coord += (f2.x * 256, f2.y * 256, 0);
                        //
                        //ShowPos(pSurface, TacticalClass.Instance.CoordsToClient(coord));
                    }
                }
            }
        }
        //if(_rightDown && _leftDown)
        //{
        //    Console.WriteLine($"Active {Game.CurrentFrame}");
        //}



        static void DrawTechno(Pointer<TechnoClass> pTechno, CoordStruct pos, DirStruct dir)
        {
            var cloackState = pTechno.Ref.CloakStates;
            var cloackable = pTechno.Ref.Cloakable;
            var body = pTechno.Ref.Facing;
            var tur =  pTechno.Ref.TurretFacing;
            var location = pTechno.Ref.Base.Location;
            //var bar =  pTechno.Ref.BarrelFacing;

            pTechno.Ref.Facing      .set(dir);
            pTechno.Ref.TurretFacing.set(dir);
            //pTechno.Ref.BarrelFacing.set(dir);



            pTechno.Ref.CloakStates = CloakStates.Cloaked;
            pTechno.Ref.Cloakable = true;

            pTechno.Ref.Base.Location = pos;

            pTechno.Ref.Base.DrawIt(TacticalClass.Instance.CoordsToClient(pos), Surface.ViewBound);


            pTechno.Ref.CloakStates = cloackState;
            pTechno.Ref.Cloakable = cloackable;


            pTechno.Ref.Facing = body;
            pTechno.Ref.TurretFacing = tur;

            pTechno.Ref.Base.Location = location;
            //pTechno.Ref.BarrelFacing = bar;

        }
    }

    private static void ShowPos(Pointer<Surface> pSurface, Point2D pos)
    {
        //pSurface.Ref.FillRect((pos - (5, 5), (10, 10)), (0, 255, 0));
    }

    private static readonly (int x, int y)[,] Offsets =
    {
        { (-1, -1), (-1, -1) },
        { (-1, -1), (-1, 0) },
        { (-1, 0), (-1, 0) },
        { (-1, 0), (-1, 1) },
        { (-1, 1), (-1, 1) },
        { (-1, 1), (0, 1) },
        { (0, 1), (0, 1) },
        { (0, 1), (1, 1) },
        { (1, 1), (1, 1) },
        { (1, 1), (1, 0) },
        { (1, 0), (1, 0) },
        { (1, 0), (1, -1) },
        { (1, -1), (1, -1) },
        { (1, -1), (0, -1) },
        { (0, -1), (0, -1) },
        { (0, -1), (-1, -1) }
    };
}