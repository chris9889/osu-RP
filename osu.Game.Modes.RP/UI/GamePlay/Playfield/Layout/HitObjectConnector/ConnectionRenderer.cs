// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System.Collections.Generic;
using osu.Framework.Graphics.Containers;
using osu.Game.Modes.RP.Objects.Drawables;

namespace osu.Game.Modes.RP.UI.GamePlay.Playfield.Layout.HitObjectConnector
{
    /// <summary>
    ///     Connects hit objects visually, for example with follow points.
    /// </summary>
    internal abstract class ConnectionRenderer<T> : Container where T : DrawableBaseHitObject
    {
        /// <summary>
        ///     Hit objects to create connections for
        /// </summary>
        public abstract IEnumerable<T> HitObjects { get; set; }

        public abstract void ScanSameTuple();
    }
}
