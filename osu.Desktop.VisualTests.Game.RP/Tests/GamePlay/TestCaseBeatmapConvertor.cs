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
    /// convert osu beatmap into RP beatmap
    /// </summary>
    public class TestCaseBeatmapConvertor : CategoryTestCase
    {
        public override string Category => TestCaseCategory.GamePlay.ToString();

        public override string TestName => @"Breadcrumbs";

        GetOsuBeatmapScript _getOsuBeatmapScript;

        [BackgroundDependencyLoader]
        private void load(BeatmapDatabase db, RulesetDatabase rulesets)
        {
            _getOsuBeatmapScript = new GetOsuBeatmapScript(db, rulesets);
        }

        public TestCaseBeatmapConvertor()
        {
            WorkingBeatmap beatmap = _getOsuBeatmapScript.GetOsuBeatmap();
            //TODO : get beatmap info of someing that can be test

        }
    }
}
