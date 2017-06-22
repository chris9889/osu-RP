// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using osu.Framework.Graphics;
using osu.Game.Graphics.UserInterface;
using osu.Game.Screens.Play;
using osu.Game.Screens.Play.ReplaySettings;

namespace osu.Desktop.VisualTests.Tests.Common
{
    /// <summary>
    /// show the verious UI item
    /// it can be add and sorted in the bottom
    /// </summary>
    internal class TestCaseUiContainer : CategoryTestCase
    {
        public override string Description => @"Settings visible in replay/auto";

        public override string Category => TestCaseCategory.Common.ToString();

        public override string TestName => @"UIContainer";

        private ExampleContainer container;

        public override void Reset()
        {
            base.Reset();

            Add(new ReplaySettingsOverlay()
            {
                Anchor = Anchor.TopRight,
                Origin = Anchor.TopRight,
            });

            Add(container = new ExampleContainer());

            AddStep(@"Add button", () => container.Add(new OsuButton
            {
                RelativeSizeAxes = Axes.X,
                Text = @"Button",
            }));

            AddStep(@"Add checkbox", () => container.Add(new ReplayCheckbox
            {
                LabelText = "Checkbox",
            }));

            AddStep(@"Add textbox", () => container.Add(new FocusedTextBox
            {
                RelativeSizeAxes = Axes.X,
                Height = 30,
                PlaceholderText = "Textbox",
                HoldFocus = false,
            }));
        }

        private class ExampleContainer : ReplayGroup
        {
            protected override string Title => @"example";
        }
    }
}
