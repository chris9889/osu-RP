using System;
using OpenTK.Graphics;


namespace osu.Game.Rulesets.RP.Objects.RpEffect.Point
{
    /// <summary>
    /// Sparkle effect point.
    /// </summary>
    public class SparkleEffectPoint : EffectPoint
    {
        public SparkleEffectPoint()
        {
            //Set default effect ProcessTime is 200ms
            ProcessTime = 200;

        }

        /// <summary>
        /// New Scale
        /// </summary>
        /// <value>The new scale.</value>
        public Color4 SparkleColor { get; set; }
    }
}
