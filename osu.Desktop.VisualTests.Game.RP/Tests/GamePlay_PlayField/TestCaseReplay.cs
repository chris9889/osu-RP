// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using osu.Game.Beatmaps;
using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.Osu.Mods;
using osu.Game.Screens.Play;

namespace osu.Desktop.VisualTests.Tests.GamePlay_PlayField
{
    /// <summary>
    /// replay the game record
    /// or autoplay
    /// </summary>
    internal class TestCaseReplay : TestCasePlayer
    {
        public override string Description => @"Testing replay playback.";

        public override string Category => TestCaseCategory.GamePlay_PlayField.ToString();

        public override string TestName => @"Test Replay";

        //testing reply
        protected override Player CreatePlayer(WorkingBeatmap beatmap)
        {
            beatmap.Mods.Value = new Mod[] { new OsuModAutoplay() };
            return base.CreatePlayer(beatmap);
        }
    }
}
