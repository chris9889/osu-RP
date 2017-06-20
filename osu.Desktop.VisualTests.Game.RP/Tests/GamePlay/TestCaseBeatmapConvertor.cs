using osu.Desktop.VisualTests.TestsScript.Beatmaps;
using osu.Framework.Allocation;
using osu.Game.Beatmaps;
using osu.Game.Database;

namespace osu.Desktop.VisualTests.Tests.GamePlay
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
