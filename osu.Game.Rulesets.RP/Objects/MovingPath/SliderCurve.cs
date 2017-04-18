//Copyright (c) 2007-2016 ppy Pty Ltd <contact@ppy.sh>.
//Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using osu.Framework.MathUtils;
using osu.Game.Rulesets.RP.Objects.type;
using OpenTK;

namespace osu.Game.Rulesets.RP.Objects.MovingPath
{
    /// <summary>
    /// </summary>
    public class SliderCurve
    {
        //Slider應該要有的長度
        public double Length = 0;

        //整個曲線的總長度
        public double PathLength;

        //控制點
        public List<Vector2> ControlPoints = new List<Vector2>();

        /// <summary>
        ///     曲線類型
        /// </summary>
        public RpBaseObjectType.CurveTypes CurveType;

        //開始位置
        public Vector2 StartPosition
        {
            get
            {
                if (ControlPoints.Count == 0)
                    ControlPoints.Add(new Vector2(0, 0));
                return ControlPoints[0];
            }
            set
            {
                if (ControlPoints.Count == 0)
                    ControlPoints.Add(new Vector2(0, 0));
                ControlPoints[0] = value;
            }
        }

        //結束位置
        public Vector2 EndPosition
        {
            get
            {
                if (ControlPoints.Count == 1)
                    ControlPoints.Add(new Vector2(0, 0));
                return ControlPoints[ControlPoints.Count - 1];
            }
            set
            {
                if (ControlPoints.Count == 1)
                    ControlPoints.Add(new Vector2(0, 0));
                ControlPoints[ControlPoints.Count - 1] = value;
            }
        }

        private readonly List<Vector2> calculatedPath = new List<Vector2>();
        private readonly List<double> cumulativeLength = new List<double>();

        /// <summary>
        ///     自動產生出結束的座標
        /// </summary>
        public void AntoGenerateEndPosition(Vector2 Direction)
        {
            //如果只有一個物件
            if (ControlPoints.Count == 1)
            {
                var _canvasWidth = 512 * 2;
                var _canvasHeight = 384 * 2;
                //需要加上這個確保物件在外面
                var _multiple = 1.5f;
                if (Direction == new Vector2(-1, 0)) //左
                    EndPosition = new Vector2(StartPosition.X + _canvasWidth * _multiple, StartPosition.Y + 40);
                else if (Direction == new Vector2(1, 0)) //右
                    EndPosition = new Vector2(StartPosition.X - _canvasWidth * _multiple, StartPosition.Y - 40);
                else if (Direction == new Vector2(0, -1)) //上
                    EndPosition = new Vector2(StartPosition.X - 40, StartPosition.Y + _canvasHeight * _multiple);
                else if (Direction == new Vector2(0, 1)) //下
                    EndPosition = new Vector2(StartPosition.X - 40, StartPosition.Y - _canvasHeight * _multiple);
            }
        }

        //產生中間的路徑()
        public void GenrtateMiddlePath()
        {
            if (ControlPoints.Count == 2)
            {
                var middlePosition1 = StartPosition - (StartPosition - EndPosition) / 3 * 1 + new Vector2(200, 200);
                var middlePosition2 = StartPosition - (StartPosition - EndPosition) / 3 * 2 - new Vector2(200, 200);
                ControlPoints.Insert(1, middlePosition1);
                ControlPoints.Insert(2, middlePosition2);
            }
        }

        /// <summary>
        ///     計算
        /// </summary>
        public void Calculate()
        {
            calculatePath();
            calculateCumulativeLengthAndTrimPath();
        }

        /// <summary>
        ///     Computes the slider curve until a given progress that ranges from 0 (beginning of the slider)
        ///     to 1 (end of the slider) and stores the generated path in the given list.
        /// </summary>
        /// <param name="path">The list to be filled with the computed curve.</param>
        /// <param name="progress">Ranges from 0 (beginning of the slider) to 1 (end of the slider).</param>
        public void GetPathToProgress(List<Vector2> path, double p0, double p1)
        {
            var d0 = progressToDistance(p0);
            var d1 = progressToDistance(p1);

            path.Clear();

            var i = 0;
            for (; i < calculatedPath.Count && cumulativeLength[i] < d0; ++i) ;

            path.Add(interpolateVertices(i, d0));

            for (; i < calculatedPath.Count && cumulativeLength[i] <= d1; ++i)
                path.Add(calculatedPath[i]);

            path.Add(interpolateVertices(i, d1));
        }

        /// <summary>
        ///     Computes the position on the slider at a given progress that ranges from 0 (beginning of the slider)
        ///     to 1 (end of the slider).
        ///     會根據 progress 0~1丟出對應座標
        /// </summary>
        /// <param name="progress">Ranges from 0 (beginning of the slider) to 1 (end of the slider).</param>
        /// <returns></returns>
        public Vector2 PositionAt(double progress)
        {
            //取得進度對應的路徑位置長度
            var d = progressToDistance(progress);
            //根據長度取的對應的頂點
            return interpolateVertices(indexOfDistance(d), d);
        }


        private List<Vector2> calculateSubpath(List<Vector2> subControlPoints)
        {
            switch (CurveType)
            {
                case RpBaseObjectType.CurveTypes.Linear:
                    return subControlPoints;
                case RpBaseObjectType.CurveTypes.PerfectCurve:
                    // If we have a different amount than 3 control points, use bezier for perfect curves.
                    if (ControlPoints.Count != 3)
                        return new BezierApproximator(subControlPoints).CreateBezier();
                    Debug.Assert(subControlPoints.Count == 3);

                    // Here we have exactly 3 control points. Attempt to fit a circular arc.
                    var subpath = new CircularArcApproximator(subControlPoints[0], subControlPoints[1], subControlPoints[2]).CreateArc();

                    if (subpath.Count == 0)
                        // For some reason a circular arc could not be fit to the 3 given points. Fall back
                        // to a numerically stable bezier approximation.
                        subpath = new BezierApproximator(subControlPoints).CreateBezier();

                    return subpath;
                default:
                    return new BezierApproximator(subControlPoints).CreateBezier();
            }
        }

        /// <summary>
        ///     算出全部的路徑
        /// </summary>
        private void calculatePath()
        {
            calculatedPath.Clear();

            // Sliders may consist of various subpaths separated by two consecutive vertices
            // with the same position. The following loop parses these subpaths and computes
            // their shape independently, consecutively appending them to calculatedPath.
            var subControlPoints = new List<Vector2>();
            for (var i = 0; i < ControlPoints.Count; ++i)
            {
                subControlPoints.Add(ControlPoints[i]);
                if (i == ControlPoints.Count - 1 || ControlPoints[i] == ControlPoints[i + 1])
                {
                    var subpath = calculateSubpath(subControlPoints);
                    for (var j = 0; j < subpath.Count; ++j)
                        // Only add those vertices that add a new segment to the path.
                        if (calculatedPath.Count == 0 || calculatedPath.Last() != subpath[j])
                            calculatedPath.Add(subpath[j]);

                    subControlPoints.Clear();
                }
            }
        }

        /// <summary>
        ///     算出路徑對應的個別點的長度壘家
        /// </summary>
        private void calculateCumulativeLengthAndTrimPath()
        {
            double l = 0;

            cumulativeLength.Clear();
            cumulativeLength.Add(l);

            for (var i = 0; i < calculatedPath.Count - 1; ++i)
            {
                var diff = calculatedPath[i + 1] - calculatedPath[i];
                double d = diff.Length;

                l += d;
                cumulativeLength.Add(l);
            }
            //總長度
            PathLength = l;
        }

        /// <summary>
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        private int indexOfDistance(double d)
        {
            var i = cumulativeLength.BinarySearch(d);
            if (i < 0) i = ~i;

            return i;
        }

        /// <summary>
        ///     取得位於長度
        /// </summary>
        /// <param name="progress"></param>
        /// <returns></returns>
        private double progressToDistance(double progress)
        {
            return MathHelper.Clamp(progress, 0, 1) * PathLength;
        }

        private Vector2 interpolateVertices(int i, double d)
        {
            if (calculatedPath.Count == 0)
                return Vector2.Zero;

            if (i <= 0)
                return calculatedPath.First();
            if (i >= calculatedPath.Count)
                return calculatedPath.Last();

            var p0 = calculatedPath[i - 1];
            var p1 = calculatedPath[i];

            var d0 = cumulativeLength[i - 1];
            var d1 = cumulativeLength[i];

            // Avoid division by and almost-zero number in case two points are extremely close to each other.
            if (Precision.AlmostEquals(d0, d1))
                return p0;

            var w = (d - d0) / (d1 - d0);
            return p0 + (p1 - p0) * (float)w;
        }
    }
}
