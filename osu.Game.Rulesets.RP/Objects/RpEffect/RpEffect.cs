using System;
using System.Collections.Generic;
using osu.Game.Rulesets.RP.Objects.RpEffect.Point;

namespace osu.Game.Rulesets.RP.Objects.RpEffect
{
    /// <summary>
    /// define single effect point
    /// </summary>
    public class RpEffect
    {
        /// <summary>
        /// Effect ID
        /// </summary>
        public int ID;

        public bool Loop = false;

        public List<EffectPoint> ListEffectPoint;
    }
}
