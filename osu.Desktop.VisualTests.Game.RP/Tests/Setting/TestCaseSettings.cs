// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using osu.Game.Overlays;

namespace osu.Desktop.VisualTests.Tests.Setting
{
    /// <summary>
    /// Just show the left bar setting view
    /// </summary>
    internal class TestCaseSettings : CategoryTestCase
    {
        public override string Description => @"Tests the settings overlay";

        public override string Category => TestCaseCategory.Setting.ToString();

        public override string TestName => @"Settings";

        private SettingsOverlay settings;

        public TestCaseSettings()
        {
            Children = new[] { settings = new SettingsOverlay() };
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();
            settings.ToggleVisibility();
        }
    }
}
