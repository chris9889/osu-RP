// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Game.Modes.RP.Beatmaps.OsuBeatmap.Parameter;
using osu.Game.Modes.RP.Objects;

namespace osu.Game.Modes.RP.Beatmaps.OsuBeatmap.Convertor.HitObject.Position.PathPosition
{
    /// <summary>
    ///     產生RP路徑
    /// </summary>
    internal class RpPathGenerator
    {
        /// <summary>
        ///     開始處理物件
        /// </summary>
        /// <param name="input"></param>
        public void Process(HitObjectConvertParameter input)
        {
            foreach (var single in input.ListConvertedParameter)
                ProcessSingeNote(single);
        }

        /// <summary>
        ///     處理單一個打擊物體
        /// </summary>
        private void ProcessSingeNote(BaseHitObject singleRPBaseHitObject)
        {
            //產生中間捕間的路徑
            singleRPBaseHitObject.Curve.GenrtateMiddlePath();
        }
    }
}
