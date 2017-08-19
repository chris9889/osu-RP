﻿// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;
using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.RP.Judgements;
using osu.Game.Rulesets.RP.Objects;

namespace osu.Game.Rulesets.RP.UI.GamePlay.HitRenderer.ModsProcessor.HitObject
{
    public class HitObjectModsProcessor
    {
        private List<Mod> listMods;

        public HitObjectModsProcessor(List<Mod> listMods)
        {
            this.listMods = listMods;
        }

        internal void ProcessHitObject(DrawableHitObject<BaseRpObject, RpJudgement> returnObject)
        {
        }
    }
}
