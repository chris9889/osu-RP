// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using osu.Framework.Graphics.Containers;
using osu.Game.Modes.RP.Objects;
using osu.Game.Modes.Objects;
using System.Collections.Generic;

namespace osu.Game.Modes.RP.UI.GamePlay.Playfield.Layout.HitObjectConnector
{
    /// <summary>
    /// Connects hit objects visually, for example with follow points.
    /// </summary>
    abstract class ConnectionRenderer<T> : Container where T : BaseHitObject
    {
        /// <summary>
        /// Hit objects to create connections for
        /// </summary>
        public abstract IEnumerable<T> HitObjects { get; set; }

        public abstract void ScanSameTuple();
    }
}
