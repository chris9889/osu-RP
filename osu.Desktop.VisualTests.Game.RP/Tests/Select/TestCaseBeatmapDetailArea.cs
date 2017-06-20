﻿// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

namespace osu.Desktop.VisualTests.Ruleset.RP.Tests.Select
{
    internal class TestCaseBeatmapDetailArea : CategoryTestCase
    {
        public override string Description => @"Beatmap details in song select";

        public override string Category => TestCaseCategory.Select.ToString();

        public override string TestName => @"Beatmap Detail Area";


        public override void Reset()
        {
            base.Reset();

            Add(new BeatmapDetailArea
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Size = new Vector2(550f, 450f),
            });
        }
    }
}