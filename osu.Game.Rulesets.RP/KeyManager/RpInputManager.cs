﻿// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using osu.Framework.Input;
using osu.Framework.Input.Bindings;
using osu.Game.Rulesets.UI;
using OpenTK.Input;
using KeyboardState = osu.Framework.Input.KeyboardState;
using MouseState = osu.Framework.Input.MouseState;

namespace osu.Game.Rulesets.RP.Input
{
    public class RpInputManager : RulesetInputManager<RpAction>
    {
        public RpInputManager(RulesetInfo ruleset)
            : base(ruleset, 0, SimultaneousBindingMode.Unique)
        {
        }

        /// <summary>
        /// if some 
        /// </summary>
        /// <param name="state"></param>
        protected override void TransformState(InputState state)
        {
            base.TransformState(state);

            var mouse = state.Mouse as MouseState;
            var keyboard = state.Keyboard as KeyboardState;

            return;

            //TODO : Not really sure what it means
            if (mouse != null && keyboard != null)
            {
                if (mouse.IsPressed(MouseButton.Left))
                    keyboard.Keys = keyboard.Keys.Concat(new[] { Key.LastKey + 1 });
                if (mouse.IsPressed(MouseButton.Right))
                    keyboard.Keys = keyboard.Keys.Concat(new[] { Key.LastKey + 2 });
            }
        }
    }

    /// <summary>
    /// 所有案件配置
    /// </summary>
    public enum RpAction
    {
        [Description("Left _up")] Left_Up,
        [Description("Left _down")] Left_Down,
        [Description("Left _Left")] Left_Left,
        [Description("Left _Right")] Left_Right,
        [Description("Left _press")] Left_Press,


        [Description("Right _up")] Right_Up,
        [Description("Right _down")] Right_Down,
        [Description("Right _Left")] Right_Left,
        [Description("Right _Right")] Right_Right,
        [Description("Right _press")] Right_Press,
    }

    public class KeyBindingConfig
    {
        public IEnumerable<KeyBinding> GetAllDefaultBinding()
        {
            yield return new KeyBinding(InputKey.E, RpAction.Left_Up);
            yield return new KeyBinding(InputKey.D, RpAction.Left_Down);
            yield return new KeyBinding(InputKey.S, RpAction.Left_Left);
            yield return new KeyBinding(InputKey.F, RpAction.Left_Right);
            yield return new KeyBinding(InputKey.A, RpAction.Left_Press);

            yield return new KeyBinding(InputKey.I, RpAction.Right_Up);
            yield return new KeyBinding(InputKey.K, RpAction.Right_Down);
            yield return new KeyBinding(InputKey.J, RpAction.Right_Left);
            yield return new KeyBinding(InputKey.L, RpAction.Right_Right);
            yield return new KeyBinding(InputKey.Comma, RpAction.Right_Press);
        }
    }
}
