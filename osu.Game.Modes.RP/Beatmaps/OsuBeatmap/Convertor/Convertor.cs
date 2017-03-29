// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;
using osu.Game.Beatmaps;
using osu.Game.Modes.RP.Beatmaps.OsuBeatmap.Convertor.Container;
using osu.Game.Modes.RP.Beatmaps.OsuBeatmap.Convertor.HitObject;
using osu.Game.Modes.RP.Beatmaps.OsuBeatmap.Convertor.Syntax;
using osu.Game.Modes.RP.Beatmaps.OsuBeatmap.Parameter;

namespace osu.Game.Modes.RP.Beatmaps.OsuBeatmap.Convertor
{
    /// <summary>
    ///     轉換器，參數做轉換，從osu排版變成RP的
    /// </summary>
    internal class Convertor
    {
        /// <summary>
        /// </summary>
        public Beatmap SongBeatmap;

        /// <summary>
        ///     語意轉換，會處理好基本物件型態後讓後面去做處理
        /// </summary>
        private SyntaxProcessor _syntaxProcessor; //= new SyntaxProcessor(SongBeatmap);

        /// <summary>
        ///     生產container
        /// </summary>
        private readonly ContainerProcessor _ContainerProcessor = new ContainerProcessor();

        /// <summary>
        ///     生產打擊物件
        /// </summary>
        private readonly HitObjectProcessor _hitObjectProcessor = new HitObjectProcessor();

        /// <summary>
        ///     主要轉換
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public List<ConvertParameter> Convert(List<HitObjectConvertParameter> input)
        {
            _syntaxProcessor = new SyntaxProcessor(SongBeatmap, input);

            var output = new List<ConvertParameter>();

            //container
            var listContainer = _syntaxProcessor.GetListContainer();
            //產生出實體物件
            _ContainerProcessor.Convert(listContainer);
            foreach (var single in listContainer)
                output.Add(single);

            //hitObject
            var listHitObject = _syntaxProcessor.GetListHitObject();
            //產生出實體物件
            _hitObjectProcessor.Convert(listHitObject);

            foreach (var single in listHitObject)
                output.Add(single);


            //回傳
            return output;
        }
    }
}
