using osu.Desktop.VisualTests.TestsScript.Beatmaps;
using osu.Framework.Allocation;
using osu.Game.Beatmaps;
using osu.Game.Database;

namespace osu.Desktop.VisualTests.Tests.GamePlay
{
    /// <summary>
    /// convert osu beatmap into RP beatmap
    /// </summary>
    internal class TestCaseBeatmapConvertor : CategoryTestCase
    {
        public override string Category => TestCaseCategory.GamePlay_PlayField.ToString();

        public override string TestName => @"Breadcrumbs";

        GetWorkingBeatmapScript _getOsuBeatmapScript;

        [BackgroundDependencyLoader]
        private void load(BeatmapDatabase db, RulesetDatabase rulesets)
        {
            _getOsuBeatmapScript = new GetWorkingBeatmapScript(db, rulesets);
        }

        public override void Reset()
        {
            WorkingBeatmap beatmap = _getOsuBeatmapScript.GetWorkingBeatmap();
            //TODO : get beatmap info of someing that can be test

        }
    }
}
