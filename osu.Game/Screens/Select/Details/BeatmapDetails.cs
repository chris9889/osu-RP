// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Framework.Graphics.Containers;
using osu.Game.Database;

namespace osu.Game.Screens.Select.Details
{
    public class BeatmapDetails : Container
    {
        public BeatmapInfo Beatmap { get; internal set; }
    }
}