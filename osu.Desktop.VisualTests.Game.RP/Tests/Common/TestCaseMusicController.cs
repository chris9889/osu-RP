// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE


using osu.Framework.Graphics.Containers;
using osu.Framework.Timing;
using osu.Game.Overlays;
using osu.Framework.Graphics;

namespace osu.Desktop.VisualTests.Tests.Common
{
    /// <summary>
    /// show Music controller show in the right up
    /// </summary>
    internal class TestCaseMusicController : CategoryTestCase
    {
        public override string Description => @"Tests music controller ui.";

        public override string Category => TestCaseCategory.Common.ToString();

        public override string TestName => @"MusicController";

        private MusicController mc;

        public TestCaseMusicController()
        {
            Clock = new FramedClock();
            Clock.ProcessFrame();
            mc = new MusicController
            {
                Origin = Anchor.Centre,
                Anchor = Anchor.Centre
            };
            Add(mc);

            AddToggleStep(@"toggle visibility", state => mc.State = state ? Visibility.Visible : Visibility.Hidden);
            AddStep(@"show", () => mc.State = Visibility.Visible);
        }
    }
}
