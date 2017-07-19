﻿// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System;
using System.Collections.Generic;
using System.Linq;
using osu.Framework.Allocation;
using osu.Game.Beatmaps;
using osu.Game.Database;
using osu.Game.Rulesets.Scoring;
using osu.Game.Screens.Ranking;
using osu.Game.Users;

namespace osu.Desktop.VisualTests.Tests.GamePlay_PlayField
{
    /// <summary>
    /// show the gameMode's result
    /// </summary>
    internal class TestCaseResults : CategoryTestCase
    {
        private BeatmapDatabase db;

        public override string Description => @"Results after playing.";

        public override string Category => TestCaseCategory.GamePlay_PlayField.ToString();

        public override string TestName => @"Show GamePlay_PlayField Result";


        [BackgroundDependencyLoader]
        private void load(BeatmapDatabase db)
        {
            this.db = db;
        }

        private WorkingBeatmap beatmap;

        protected override void LoadComplete()
        {
            if (beatmap == null)
            {
                var beatmapInfo = db.Query<BeatmapInfo>().FirstOrDefault(b => b.RulesetID == 0);
                if (beatmapInfo != null)
                    beatmap = db.GetWorkingBeatmap(beatmapInfo);
            }

            Add(new Results(new Score
            {
                TotalScore = 2845370,
                Accuracy = 0.98,
                MaxCombo = 123,
                Rank = ScoreRank.A,
                Date = DateTimeOffset.Now,
                Statistics = new Dictionary<string, dynamic>()
                {
                    { "300", 50 },
                    { "100", 20 },
                    { "50", 50 },
                    { "x", 1 }
                },
                User = new User
                {
                    Username = "peppy",
                }
            })
            {
                InitialBeatmap = beatmap
            });
        }
    }
}
