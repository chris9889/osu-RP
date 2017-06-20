// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

namespace osu.Desktop.VisualTests.Ruleset.RP.Tests.Common
{
    /// <summary>
    /// test back button
    /// </summary>
    internal class TestCaseBackButton : CategoryTestCase
    {
        public override string Description => @"Mostly back button.";

        public override string Category => TestCaseCategory.Common.ToString();

        public override string TestName => @"BackButton";

        public override void Reset()
        {
            base.Reset();

            Add(new BackButton());
        }
    }
}
