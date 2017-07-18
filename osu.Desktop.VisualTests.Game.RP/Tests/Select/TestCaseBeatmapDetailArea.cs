﻿﻿// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using osu.Game.Screens.Select;
using OpenTK;
using osu.Framework.Graphics;


namespace osu.Desktop.VisualTests.Tests.Select
{
    internal class TestCaseBeatmapDetailArea : CategoryTestCase
    {
        public override string Description => @"Beatmap details in song select";

        public override string Category => TestCaseCategory.Select.ToString();

        public override string TestName => @"Beatmap Detail Area";


        public TestCaseBeatmapDetailArea()
        {
            Add(new BeatmapDetailArea
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Size = new Vector2(550f, 450f),
            });
        }
    }
}