using System;
using OpenTK;

namespace osu.Game.Rulesets.RP.Objects.RpEffect.Point
{
    public class PositionEffectPoint : EffectPoint
    {
        public PositionEffectPoint()
        {
            
        }

        /// <summary>
        /// New Position
        /// </summary>
        /// <value>The new scale.</value>
        public Vector2 NewPotition { get; set; }
    }
}
