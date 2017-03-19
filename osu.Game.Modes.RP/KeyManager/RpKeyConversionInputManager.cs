// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Framework.Allocation;
using osu.Framework.Input;
using osu.Game.Configuration;
using osu.Game.Screens.Play;

namespace osu.Game.Modes.RP.KeyManager
{
    public class RpKeyConversionInputManager : KeyConversionInputManager
    {


        [BackgroundDependencyLoader]
        private void load(OsuConfigManager config)
        {
           
        }

        protected override void TransformState(InputState state)
        {
            base.TransformState(state);
        }
    }
}