﻿// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using osu.Desktop.VisualTests.TestsScript.Beatmaps;
using osu.Framework.Allocation;
using osu.Framework.Graphics.Shapes;
using osu.Game.Beatmaps;
using osu.Game.Database;
using osu.Game.Screens.Play;
using OpenTK.Graphics;

namespace osu.Desktop.VisualTests.Tests.GamePlay
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
