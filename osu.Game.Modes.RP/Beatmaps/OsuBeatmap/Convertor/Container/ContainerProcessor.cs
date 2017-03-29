// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;
using osu.Game.Modes.RP.Beatmaps.OsuBeatmap.Convertor.Container.GenerateObject;
using osu.Game.Modes.RP.Beatmaps.OsuBeatmap.Convertor.Container.Position;
using osu.Game.Modes.RP.Beatmaps.OsuBeatmap.Parameter;

namespace osu.Game.Modes.RP.Beatmaps.OsuBeatmap.Convertor.Container
{
    internal class ContainerProcessor
    {
        /// <summary>
        ///     產生出實體物件
        /// </summary>
        private readonly ContainerGenerator _rpObjectGenerator = new ContainerGenerator();


        /// <summary>
        ///     位置生產器
        /// </summary>
        private readonly ContainerPositionGenerator _positionGenerator = new ContainerPositionGenerator();

        /// <summary>
        ///     主要轉換
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public List<ContainerConvertParameter> Convert(List<ContainerConvertParameter> input)
        {
            //產生出實體物件
            input = _rpObjectGenerator.Convert(input);
            //轉換座標，會接收到語意後做處理
            input = _positionGenerator.Convert(input);
            //回傳
            return input;
        }
    }
}
