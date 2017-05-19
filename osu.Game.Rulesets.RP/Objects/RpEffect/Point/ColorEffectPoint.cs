using System;
using OpenTK.Graphics;


namespace osu.Game.Rulesets.RP.Objects.RpEffect.Point
{
    /// <summary>
    /// Sparkle effect point.
    /// </summary>
    public class ColorEffectPoint : EffectPoint
    {
        public ColorEffectPoint()
        {
            //Set default effect ProcessTime is 200ms
            ProcessTime = 200;

        }

        /// <summary>
        /// New Scale
        /// </summary>
        /// <value>The new scale.</value>
        public Color4 Color { get; set; }
    }
}
