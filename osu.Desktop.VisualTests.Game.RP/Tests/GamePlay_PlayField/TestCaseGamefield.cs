﻿// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System.Collections.Generic;
using osu.Desktop.VisualTests.Beatmaps;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.MathUtils;
using osu.Framework.Timing;
using osu.Game.Beatmaps;
using osu.Game.Beatmaps.ControlPoints;
using osu.Game.Database;
using osu.Game.Rulesets.Mania.UI;
using osu.Game.Rulesets.Objects;
using osu.Game.Rulesets.Osu.Objects;
using osu.Game.Rulesets.Osu.UI;
using osu.Game.Rulesets.RP.UI.GamePlay.HitRenderer;
using osu.Game.Rulesets.Taiko.UI;
using OpenTK;

namespace osu.Desktop.VisualTests.Tests.GamePlay_PlayField
{
    /// <summary>
    /// show RP gameField
    /// </summary>
    internal class TestCaseGamefield : CategoryTestCase
    {
        private RulesetDatabase rulesets;

        public override string Description => @"Showing hitobjects and what not.";

        public override string Category => TestCaseCategory.GamePlay_PlayField.ToString();

        public override string TestName => @"GameField";


        [BackgroundDependencyLoader]
        private void load(RulesetDatabase rulesets)
        {
            this.rulesets = rulesets;
        }

        public override void Reset()
        {
            base.Reset();

            List<HitObject> objects = new List<HitObject>();

            int time = 500;
            for (int i = 0; i < 100; i++)
            {
                objects.Add(new HitCircle
                {
                    StartTime = time,
                    Position = new Vector2(RNG.Next(0, (int)OsuPlayfield.BASE_SIZE.X), RNG.Next(0, (int)OsuPlayfield.BASE_SIZE.Y)),
                    Scale = RNG.NextSingle(0.5f, 1.0f),
                });

                time += RNG.Next(50, 500);
            }

            var controlPointInfo = new ControlPointInfo();
            controlPointInfo.TimingPoints.Add(new TimingControlPoint
            {
                BeatLength = 200
            });

            WorkingBeatmap beatmap = new RpTestWorkingBeatmap(new Beatmap
            {
                HitObjects = objects,
                BeatmapInfo = new BeatmapInfo
                {
                    Difficulty = new BeatmapDifficulty(),
                    Ruleset = rulesets.Query<RulesetInfo>().First(),
                    Metadata = new BeatmapMetadata
                    {
                        Artist = @"Unknown",
                        Title = @"Sample Beatmap",
                        Author = @"peppy",
                    },
                },
                ControlPointInfo = controlPointInfo
            });

            Add(new Drawable[]
            {
                new Container
                {
                    RelativeSizeAxes = Axes.Both,
                    //ensure we are at offset 0
                    Clock = new FramedClock(),
                    Children = new Drawable[]
                    {
                        new OsuHitRenderer(beatmap, false)
                        {
                            Scale = new Vector2(0.5f),
                            Anchor = Anchor.TopLeft,
                            Origin = Anchor.TopLeft
                        },
                        new TaikoHitRenderer(beatmap, false)
                        {
                            Scale = new Vector2(0.5f),
                            Anchor = Anchor.TopRight,
                            Origin = Anchor.TopRight
                        },
                        new RpHitRenderer(beatmap, false)
                        {
                            Scale = new Vector2(0.5f),
                            Anchor = Anchor.BottomLeft,
                            Origin = Anchor.BottomLeft
                        },
                        new ManiaHitRenderer(beatmap, false)
                        {
                            Scale = new Vector2(0.5f),
                            Anchor = Anchor.BottomRight,
                            Origin = Anchor.BottomRight
                        }
                    }
                }
            });
        }
    }
}
