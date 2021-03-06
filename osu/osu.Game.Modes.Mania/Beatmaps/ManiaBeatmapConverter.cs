﻿// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using osu.Game.Beatmaps;
using osu.Game.Modes.Mania.Objects;
using System.Collections.Generic;

namespace osu.Game.Modes.Mania.Beatmaps
{
    internal class ManiaBeatmapConverter : IBeatmapConverter<ManiaBaseHit>
    {
        public Beatmap<ManiaBaseHit> Convert(Beatmap original)
        {
            return new Beatmap<ManiaBaseHit>(original)
            {
                HitObjects = new List<ManiaBaseHit>() // Todo: Implement
            };
        }
    }
}
