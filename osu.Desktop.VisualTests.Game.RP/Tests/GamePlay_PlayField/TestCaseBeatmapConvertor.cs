using osu.Desktop.VisualTests.TestsScript.Beatmaps;
using osu.Framework.Allocation;
using osu.Framework.Graphics.Shapes;
using osu.Game.Beatmaps;
using osu.Game.Database;

namespace osu.Desktop.VisualTests.Tests.GamePlay_PlayField
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

        protected override void LoadComplete()
        {
            WorkingBeatmap beatmap = _getOsuBeatmapScript.GetWorkingBeatmap();
            //TODO : get beatmap info of someing that can be test
            Add(new Box());
        }
    }
}
