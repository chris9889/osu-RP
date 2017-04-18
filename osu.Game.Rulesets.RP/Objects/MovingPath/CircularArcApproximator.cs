//Copyright (c) 2007-2016 ppy Pty Ltd <contact@ppy.sh>.
//Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System;
using System.Collections.Generic;
using osu.Framework.MathUtils;
using OpenTK;

namespace osu.Game.Rulesets.RP.Objects.MovingPath
{
    /// <summary>
    /// </summary>
    public class CircularArcApproximator
    {
        private const float TOLERANCE = 0.1f;
        private readonly Vector2 A;
        private readonly Vector2 B;
        private readonly Vector2 C;

        private int amountPoints;

        public CircularArcApproximator(Vector2 A, Vector2 B, Vector2 C)
        {
            this.A = A;
            this.B = B;
            this.C = C;
        }

        /// <summary>
        ///     Creates a piecewise-linear approximation of a circular arc curve.
        /// </summary>
        /// <returns>A list of vectors representing the piecewise-linear approximation.</returns>
        public List<Vector2> CreateArc()
        {
            var aSq = (B - C).LengthSquared;
            var bSq = (A - C).LengthSquared;
            var cSq = (A - B).LengthSquared;

            // If we have a degenerate triangle where a side-length is almost zero, then give up and fall
            // back to a more numerically stable method.
            if (Precision.AlmostEquals(aSq, 0) || Precision.AlmostEquals(bSq, 0) || Precision.AlmostEquals(cSq, 0))
                return new List<Vector2>();

            var s = aSq * (bSq + cSq - aSq);
            var t = bSq * (aSq + cSq - bSq);
            var u = cSq * (aSq + bSq - cSq);

            var sum = s + t + u;

            // If we have a degenerate triangle with an almost-zero size, then give up and fall
            // back to a more numerically stable method.
            if (Precision.AlmostEquals(sum, 0))
                return new List<Vector2>();

            var centre = (s * A + t * B + u * C) / sum;
            var dA = A - centre;
            var dC = C - centre;

            var r = dA.Length;

            var thetaStart = Math.Atan2(dA.Y, dA.X);
            var thetaEnd = Math.Atan2(dC.Y, dC.X);

            while (thetaEnd < thetaStart)
                thetaEnd += 2 * Math.PI;

            double dir = 1;
            var thetaRange = thetaEnd - thetaStart;

            // Decide in which direction to draw the circle, depending on which side of 
            // AC B lies.
            var orthoAC = C - A;
            orthoAC = new Vector2(orthoAC.Y, -orthoAC.X);
            if (Vector2.Dot(orthoAC, B - A) < 0)
            {
                dir = -dir;
                thetaRange = 2 * Math.PI - thetaRange;
            }

            // We select the amount of points for the approximation by requiring the discrete curvature
            // to be smaller than the provided tolerance. The exact angle required to meet the tolerance
            // is: 2 * Math.Acos(1 - TOLERANCE / r)
            if (2 * r <= TOLERANCE)
                // This special case is required for extremely short sliders where the radius is smaller than
                // the tolerance. This is a pathological rather than a realistic case.
                amountPoints = 2;
            else
                amountPoints = Math.Max(2, (int)Math.Ceiling(thetaRange / (2 * Math.Acos(1 - TOLERANCE / r))));

            var output = new List<Vector2>(amountPoints);

            for (var i = 0; i < amountPoints; ++i)
            {
                var fract = (double)i / (amountPoints - 1);
                var theta = thetaStart + dir * fract * thetaRange;
                var o = new Vector2((float)Math.Cos(theta), (float)Math.Sin(theta)) * r;
                output.Add(centre + o);
            }

            return output;
        }
    }
}
