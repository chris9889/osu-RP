// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;
using osu.Game.Modes.RP.Beatmaps.OsuBeatmap.Convertor.HitObject.GenerateObject;
using osu.Game.Modes.RP.Beatmaps.OsuBeatmap.Convertor.HitObject.Position;
using osu.Game.Modes.RP.Beatmaps.OsuBeatmap.Convertor.HitObject.Type;
using osu.Game.Modes.RP.Beatmaps.OsuBeatmap.Parameter;

namespace osu.Game.Modes.RP.Beatmaps.OsuBeatmap.Convertor.HitObject
{
    internal class HitObjectProcessor
    {
        /// <summary>
        ///     產生出實體物件
        /// </summary>
        private readonly RpObjectGenerator _rpObjectGenerator = new RpObjectGenerator();

        /// <summary>
        ///     類型生產器
        /// </summary>
        private readonly ObjectTypeGenerator _typeGenerator = new ObjectTypeGenerator();

        /// <summary>
        ///     位置生產器
        /// </summary>
        private readonly ObjectPositionGenerator _positionGenerator = new ObjectPositionGenerator();

        /// <summary>
        ///     主要轉換
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public List<HitObjectConvertParameter> Convert(List<HitObjectConvertParameter> input)
        {
            //產生出實體物件
            input = _rpObjectGenerator.Convert(input);
            //先轉換類型，會接收到語意後做處理
            input = _typeGenerator.Convert(input);
            //轉換座標，會接收到語意後做處理
            input = _positionGenerator.Convert(input);
            //回傳
            return input;
        }
    }
}
