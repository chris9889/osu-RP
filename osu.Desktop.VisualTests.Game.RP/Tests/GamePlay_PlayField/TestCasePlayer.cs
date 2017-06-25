﻿// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System.Linq;
using osu.Desktop.VisualTests.TestsScript.Beatmaps;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Timing;
using osu.Game.Beatmaps;
using osu.Game.Database;
using osu.Game.Rulesets.RP;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield;
using osu.Game.Rulesets.Taiko.UI;
using osu.Game.Screens.Play;
using OpenTK.Graphics;

namespace osu.Desktop.VisualTests.Tests.GamePlay_PlayField
{
    /// <summary>
    /// show the playField and can be played instancely
    /// </summary>
    internal class TestCasePlayer : CategoryTestCase
    {

        public override string Description => @"Showing everything to play the game.";

        public override string Category => TestCaseCategory.GamePlay_PlayField.ToString();

        public override string TestName => @"Test Case Player";

        private Container playfieldContainer;

        private RpPlayfield playfield;

        protected Player Player;

        GetWorkingBeatmapScript _getOsuBeatmapScript;

        private RulesetDatabase _rulesets;

        [BackgroundDependencyLoader]
        private void load(BeatmapDatabase db, RulesetDatabase rulesets)
        {
            _rulesets = rulesets;
            _getOsuBeatmapScript = new GetWorkingBeatmapScript(db, rulesets);
        }


        public override void Reset()
        {
            base.Reset();

            WorkingBeatmap beatmap = _getOsuBeatmapScript.GetWorkingBeatmap();

            Add(new Box
            {
                RelativeSizeAxes = Framework.Graphics.Axes.Both,
                Colour = Color4.Black,
            });

            Add(Player = CreatePlayer(beatmap));
        }

        protected virtual Player CreatePlayer(WorkingBeatmap beatmap)
        {
            //change to RP mode
            beatmap.BeatmapInfo.Ruleset = _rulesets.Query<RulesetInfo>().FirstOrDefault(info => info.ID == 1111);
            return new Player
            {
                Beatmap = beatmap,
                
            };
        }
    }
}
