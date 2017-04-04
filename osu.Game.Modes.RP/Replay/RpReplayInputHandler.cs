// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;
using osu.Framework.Input;
using osu.Game.Modes.Replays;

namespace osu.Game.Modes.RP.Replay
{
    /// <summary>
    /// RP 專用譜面紀錄系統
    /// </summary>
    public class RpReplayInputHandler : FramedReplayInputHandler
    {

        public RpReplayInputHandler(Replays.Replay replay) : base(replay)
        {

        }

        /// <summary>
        /// 只有鍵盤
        /// </summary>
        /// <returns></returns>
        public override List<InputState> GetPendingStates()
        {
            //get the RpReplayFrame
            var correntFrame = (RpReplayFrame)CurrentFrame;
            return new List<InputState>
                {
                    new InputState
                    {
                        //get keys from frame
                        Keyboard = new ReplayKeyboardState(correntFrame.ListPressKeys)
                    }
                };
        }
    }
}