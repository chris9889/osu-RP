using osu.Desktop.VisualTests.Ruleset.RP.TestsScript.Beatmaps;

namespace osu.Desktop.VisualTests.Ruleset.RP.Tests.GamePlay
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
