﻿using OpenTK.Graphics;
using OpenTK.Input;
using osu.Framework.Testing;
using osu.Game.Graphics;
using osu.Game.Screens.Select.Options;

namespace osu.Desktop.VisualTests.Tests
{
    /// <summary>
    /// show the 
    ///  // Remove / Clear / Edit / Delete // 
    /// Beatmap Button
    /// </summary>
    internal class TestCaseGameModeSettingPage : TestCase
    {
        public override string Description => @"testing game setting page";

        public override void Reset()
        {
            base.Reset();

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
