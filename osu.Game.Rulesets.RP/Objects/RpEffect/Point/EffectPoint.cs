using System;
using osu.Framework.Graphics;

namespace osu.Game.Rulesets.RP.Objects.RpEffect.Point
{
    /// <summary>
    /// single point of RpEffect
    /// </summary>
    public abstract class EffectPoint
    {
        /// <summary>
        /// Time
        /// </summary>
        public double Time { get; set; }


        /// <summary>
        /// EastingType
        /// </summary>
        /// <value>The easing types.</value>
        public EasingTypes EasingTypes { get; set; }

        /// <summary>
        /// Gets or sets the process time.
        /// </summary>
        /// <value>The process time.</value>
        public Double ProcessTime { get; set}
    }
}
