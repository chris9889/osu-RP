// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System;

namespace osu.Desktop.VisualTests.Ruleset.RP.Tests.Common
{
    /// <summary>
    /// not sure will have custome textAwsome
    /// </summary>
    internal class TestCaseTextAwesome : CategoryTestCase
    {
        public override string Description => @"Tests display of icons";

        public override string Category => TestCaseCategory.Common.ToString();

        public override string TestName => @"TextAwsome";

        public override void Reset()
        {
            base.Reset();

            FillFlowContainer flow;

            Add(flow = new FillFlowContainer
            {
                RelativeSizeAxes = Axes.Both,
                Size = new Vector2(0.5f),
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre
            });

            int i = 50;
            foreach (FontAwesome fa in Enum.GetValues(typeof(FontAwesome)))
            {
                flow.Add(new TextAwesome
                {
                    Icon = fa,
                    TextSize = 60,
                    Colour = new Color4(
                        Math.Max(0.5f, RNG.NextSingle()),
                        Math.Max(0.5f, RNG.NextSingle()),
                        Math.Max(0.5f, RNG.NextSingle()),
                        1)
                });

                if (i-- == 0) break;
            }
        }
    }
}
