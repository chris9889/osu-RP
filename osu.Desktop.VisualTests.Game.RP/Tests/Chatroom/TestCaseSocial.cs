// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using osu.Game.Overlays;
using osu.Game.Users;

namespace osu.Desktop.VisualTests.Tests.Chatroom
{
    /// <summary>
    /// list of player
    /// </summary>
    public class TestCaseSocial : CategoryTestCase
    {
        public override string Description => @"social browser overlay";

<<<<<<< HEAD:osu.Desktop.VisualTests.Game.RP/Tests/Chatroom/TestCaseSocial.cs
        public override string Category => TestCaseCategory.Chatroom.ToString();

        public override string TestName => @"ChatDisplay";

        public override void Reset()
=======
        public TestCaseSocial()
>>>>>>> 9928d9225a9c2842f37670181649310108423b09:osu.Desktop.VisualTests/Tests/TestCaseSocial.cs
        {
            SocialOverlay s = new SocialOverlay
            {
                Users = new[]
                {
                    new User
                    {
                        Username = @"flyte",
                        Id = 3103765,
                        Country = new Country { FlagName = @"JP" },
                        CoverUrl = @"https://osu.ppy.sh/images/headers/profile-covers/c1.jpg",
                    },
                    new User
                    {
                        Username = @"Cookiezi",
                        Id = 124493,
                        Country = new Country { FlagName = @"KR" },
                        CoverUrl = @"https://osu.ppy.sh/images/headers/profile-covers/c2.jpg",
                    },
                    new User
                    {
                        Username = @"Angelsim",
                        Id = 1777162,
                        Country = new Country { FlagName = @"KR" },
                        CoverUrl = @"https://osu.ppy.sh/images/headers/profile-covers/c3.jpg",
                    },
                    new User
                    {
                        Username = @"Rafis",
                        Id = 2558286,
                        Country = new Country { FlagName = @"PL" },
                        CoverUrl = @"https://osu.ppy.sh/images/headers/profile-covers/c4.jpg",
                    },
                    new User
                    {
                        Username = @"hvick225",
                        Id = 50265,
                        Country = new Country { FlagName = @"TW" },
                        CoverUrl = @"https://osu.ppy.sh/images/headers/profile-covers/c5.jpg",
                    },
                    new User
                    {
                        Username = @"peppy",
                        Id = 2,
                        Country = new Country { FlagName = @"AU" },
                        CoverUrl = @"https://osu.ppy.sh/images/headers/profile-covers/c6.jpg"
                    },
                    new User
                    {
                        Username = @"filsdelama",
                        Id = 2831793,
                        Country = new Country { FlagName = @"FR" },
                        CoverUrl = @"https://osu.ppy.sh/images/headers/profile-covers/c7.jpg"
                    },
                    new User
                    {
                        Username = @"_index",
                        Id = 652457,
                        Country = new Country { FlagName = @"RU" },
                        CoverUrl = @"https://osu.ppy.sh/images/headers/profile-covers/c8.jpg"
                    },
                },
            };
            Add(s);

            AddStep(@"toggle", s.ToggleVisibility);
        }
    }
}
