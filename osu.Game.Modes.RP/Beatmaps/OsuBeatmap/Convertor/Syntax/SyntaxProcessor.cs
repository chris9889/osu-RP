// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System;
using System.Collections.Generic;
using osu.Game.Beatmaps;
using osu.Game.Modes.Osu.Objects;
using osu.Game.Modes.RP.Beatmaps.OsuBeatmap.Parameter;
using OpenTK;

namespace osu.Game.Modes.RP.Beatmaps.OsuBeatmap.Convertor.Syntax
{
    /// <summary>
    ///     語法轉換器
    /// </summary>
    internal class SyntaxProcessor
    {
        private readonly List<HitObjectConvertParameter> _listConvertParameter;

        private Beatmap _songBeatmap;

        /// <summary>
        /// </summary>
        /// <param name="beatmap"></param>
        /// <param name="input"></param>
        public SyntaxProcessor(Beatmap beatmap, List<HitObjectConvertParameter> input)
        {
            _songBeatmap = beatmap;
            _listConvertParameter = input;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public List<HitObjectConvertParameter> GetListHitObject()
        {
            var output = new List<HitObjectConvertParameter>();
            foreach (var single in _listConvertParameter)
                output.Add(single);
            return output;
        }

        /// <summary>
        ///     增加一定數量的Ciontainer 進來
        /// </summary>
        public List<ContainerConvertParameter> GetListContainer()
        {
            var listContainer = new List<ContainerConvertParameter>();

            var random = new Random();

            double time = 0;
            //目前就先暫時做到300秒的
            for (var i = 0; i < 100; i++)
            {
                var parameter = new ContainerConvertParameter();
                parameter.OsuHitObject = new Slider();

                parameter.OsuHitObject.StartTime = time;
                time = time + 2000;
                parameter.PassParameter.EndTime = time;

                //先設定隨機
                var randomValue = (float)random.NextDouble() * 400 + 40;

                //
                parameter.OsuHitObject.Position = new Vector2(0, randomValue);

                listContainer.Add(parameter);
            }
            return listContainer;
        }

        /// <summary>
        ///     分析物件要不要Multi
        /// </summary>
        private void AnaylseMulti()
        {
        }
    }
}
