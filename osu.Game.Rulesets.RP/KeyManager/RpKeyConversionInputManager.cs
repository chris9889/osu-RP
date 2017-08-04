﻿// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Framework.Allocation;
using osu.Framework.Input;
using osu.Game.Configuration;
using osu.Game.Screens.Play;

namespace osu.Game.Rulesets.RP.KeyManager
{
   
    public class RpKeyConversionInputManager : KeyConversionInputManager
    {
        //use like if some press, set another keys as pressed
        //can be refrence usage by OsuKeyConversionInputManager.cs
        protected override void TransformState(InputState state)
        {
            base.TransformState(state);
        }
    }
}
