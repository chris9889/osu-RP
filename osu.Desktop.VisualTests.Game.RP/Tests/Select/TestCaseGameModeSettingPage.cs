using osu.Game.Graphics;
using osu.Game.Screens.Select.Options;
using OpenTK.Graphics;
using OpenTK.Input;

namespace osu.Desktop.VisualTests.Tests.Select
{
    /// <summary>
    /// show the 
    ///  // Remove / Clear / Edit / Delete // 
    /// Beatmap Button
    /// </summary>
    internal class TestCaseGameModeSettingPage : CategoryTestCase
    {
        public override string Description => @"testing game setting page";

        public override string Category => TestCaseCategory.Select.ToString();

        public override string TestName => @"BeatmapOptionOverlay";


        public TestCaseGameModeSettingPage()
        {
            var overlay = new BeatmapOptionsOverlay();

            overlay.AddButton(@"Remove", @"from unplayed", FontAwesome.fa_times_circle_o, Color4.Purple, null, Key.Number1);
            overlay.AddButton(@"Clear", @"local scores", FontAwesome.fa_eraser, Color4.Purple, null, Key.Number2);
            overlay.AddButton(@"Edit", @"Beatmap", FontAwesome.fa_pencil, Color4.Yellow, null, Key.Number3);
            overlay.AddButton(@"Delete", @"Beatmap", FontAwesome.fa_trash, Color4.Pink, null, Key.Number4, float.MaxValue);

            //add this view to sereen
            Add(overlay);

            //add a step button
            AddStep(@"Toggle", overlay.ToggleVisibility);

        }
    }
}
