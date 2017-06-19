﻿// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System.Collections.Generic;
using System.Linq;
using osu.Framework.Allocation;
using osu.Framework.Testing;
using osu.Game.Beatmaps;
using OpenTK;
using osu.Framework.Graphics.Sprites;
using osu.Game.Database;
using osu.Game.Rulesets.Objects;
using osu.Game.Rulesets.Osu.Objects;
using osu.Game.Screens.Play;
using OpenTK.Graphics;
using osu.Desktop.VisualTests.Beatmaps;
using osu.Game.Rulesets.Osu.UI;
using osu.Desktop.VisualTests.Ruleset.RP.TestsScript.Beatmaps;

namespace osu.Desktop.VisualTests.Tests
{
    /// <summary>
    /// show the playField and can be played instancely
    /// </summary>
    internal class TestCasePlayer : CategoryTestCase
    {
        protected Player Player;

        public override string Description => @"Showing everything to play the game.";

        public override string Category => TestCaseCategory.GamePlay.ToString();

        public override string TestName => @"Test Case Player";

        GetOsuBeatmapScript _getOsuBeatmapScript;

        [BackgroundDependencyLoader]
        private void load(BeatmapDatabase db, RulesetDatabase rulesets)
        {
            _getOsuBeatmapScript = new GetOsuBeatmapScript(db, rulesets);
        }


        public override void Reset()
        {
            base.Reset();

            WorkingBeatmap beatmap = _getOsuBeatmapScript.GetOsuBeatmap();

            Add(new Box
            {
                RelativeSizeAxes = Framework.Graphics.Axes.Both,
                Colour = Color4.Black,
            });

            Add(Player = CreatePlayer(beatmap));

        }

        protected virtual Player CreatePlayer(WorkingBeatmap beatmap)
        {
            return new Player
            {
                Beatmap = beatmap
            };
        }
    }
}
