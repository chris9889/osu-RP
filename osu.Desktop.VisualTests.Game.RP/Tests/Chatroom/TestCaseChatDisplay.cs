// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using osu.Framework.Testing;
using osu.Framework.Graphics.Containers;
using osu.Game.Overlays;

namespace osu.Desktop.VisualTests.Tests
{
    /// <summary>
    /// not sure if will let each gameMode use the special chatroom
    /// </summary>
    internal class TestCaseChatDisplay : CategoryTestCase
    {
        public override string Description => @"Testing chat api and overlay";

        public override string Category => TestCaseCategory.Chatroom.ToString();

        public override string TestName => @"ChatDisplay";
      
        public override void Reset()
        {
            base.Reset();

            Add(new ChatOverlay
            {
                State = Visibility.Visible
            });
        }
    }
}
