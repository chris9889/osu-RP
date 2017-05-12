﻿using System;
using OpenTK;
using osu.Framework.Graphics;

namespace osu.Game.Rulesets.RP.Objects.RpEffect.Point
{
    /// <summary>
    /// define single Scale effect point.
    /// </summary>
    public class ScaleEffectPoint : EffectPoint
    {
        public ScaleEffectPoint()
        {
            //Set default effect ProcessTime is 200ms
            ProcessTime = 200;

        }

        /// <summary>
        /// New Scale
        /// </summary>
        /// <value>The new scale.</value>
        public Vector2 NewScale { get; set; }

       

    }
}
