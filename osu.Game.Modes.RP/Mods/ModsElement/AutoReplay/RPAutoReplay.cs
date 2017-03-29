// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System;
using System.Collections.Generic;
using System.Diagnostics;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Transforms;
using osu.Framework.MathUtils;
using osu.Game.Beatmaps;
using osu.Game.Modes.RP.Objects;
using osu.Game.Modes.RP.Objects.Drawables;
using OpenTK;

namespace osu.Game.Modes.RP.Mods.ModsElement.AutoReplay
{
    public class RpAutoReplay : LegacyReplay
    {
        private Beatmap<BaseRpObject> beatmap;

        public RpAutoReplay(Beatmap<BaseRpObject> beatmap)
        {
            this.beatmap = beatmap;
        }
    }
}
