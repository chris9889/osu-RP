// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System;
using osu.Desktop.VisualTests.Ruleset.RP;
using osu.Framework.Desktop;
using osu.Framework.Platform;

namespace osu.Desktop.VisualTests
{
    public static class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            bool benchmark = args.Length > 0 && args[0] == @"-benchmark";

            using (GameHost host = Host.GetSuitableHost(@"osu"))
            {
                if (benchmark)
                    host.Run(new AutomatedVisualTestGame());
                else
                    host.Run(new RpVisualTestGame());
            }

            //Todo : GamePlay
            //          Field ..V
            //          ContainerAddLayoutNumber...V
            //          layout...V
            //          object...V
            //          longPress...V
            //          beatmap convertor...V

            //TODO : Seledt
            //          showGameMode...V

            //TODO : Setting
            //          show setting page...V

            //
        }
    }
}
