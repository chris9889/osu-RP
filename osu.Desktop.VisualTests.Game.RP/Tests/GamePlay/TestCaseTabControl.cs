// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

namespace osu.Desktop.VisualTests.Ruleset.RP.Tests.GamePlay
{
    /// <summary>
    /// may be use in the editor 
    /// or not,i'm not sure
    /// </summary>
    public class TestCaseTabControl : CategoryTestCase
    {
        public override string Description => @"Filter for song select";

        public override string Category => TestCaseCategory.GamePlay.ToString();

        public override string TestName => @"Tab Control";


        public override void Reset()
        {
            base.Reset();

            OsuSpriteText text;
            OsuTabControl<GroupMode> filter;
            Add(filter = new OsuTabControl<GroupMode>
            {
                Margin = new MarginPadding(4),
                Size = new Vector2(229, 24),
                AutoSort = true
            });
            Add(text = new OsuSpriteText
            {
                Text = "None",
                Margin = new MarginPadding(4),
                Position = new Vector2(275, 5)
            });

            filter.PinItem(GroupMode.All);
            filter.PinItem(GroupMode.RecentlyPlayed);

            filter.Current.ValueChanged += newFilter =>
            {
                text.Text = "Currently Selected: " + newFilter.ToString();
            };
        }
    }
}
