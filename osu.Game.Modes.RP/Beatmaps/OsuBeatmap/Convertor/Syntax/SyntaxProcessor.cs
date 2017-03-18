using System;
using System.Collections.Generic;
using osu.Game.Beatmaps;
using osu.Game.Modes.Osu.Objects;
using osu.Game.Modes.RP.Beatmaps.OsuBeatmap.Parameter;

namespace osu.Game.Modes.RP.Beatmaps.OsuBeatmap.Convertor.Syntax
{
    /// <summary>
    /// 語法轉換器
    /// </summary>
    class SyntaxProcessor
    {
        
        List<HitObjectConvertParameter> _listConvertParameter;

        Beatmap _songBeatmap;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="beatmap"></param>
        /// <param name="input"></param>
        public SyntaxProcessor(Beatmap beatmap, List<HitObjectConvertParameter> input)
        {
            _songBeatmap = beatmap;
            _listConvertParameter = input;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<HitObjectConvertParameter> GetListHitObject()
        {
            List<HitObjectConvertParameter> output = new List<HitObjectConvertParameter>();
            foreach (HitObjectConvertParameter single in _listConvertParameter)
            {
                output.Add(single);
            }
            return output;
        }

        /// <summary>
        /// 增加一定數量的Ciontainer 進來
        /// </summary>
        public List<ContainerConvertParameter> GetListContainer()
        {
            List<ContainerConvertParameter> listContainer = new List<ContainerConvertParameter>();

            Random random = new Random();

            double time = 0;
            //目前就先暫時做到300秒的
            for (int i = 0; i < 100; i++)
            {
                ContainerConvertParameter parameter = new ContainerConvertParameter();
                parameter.OsuHitObject = new Slider();

                parameter.OsuHitObject.StartTime = time;
                time = time + 2000;
                parameter.PassParameter.EndTime = time;

                //先設定隨機
                float randomValue = (float)random.NextDouble() * 250 + 50;

                //
                parameter.OsuHitObject.Position = new OpenTK.Vector2(0, randomValue);

                listContainer.Add(parameter);
            }
            return listContainer;
        }

        /// <summary>
        /// 分析物件要不要Multi
        /// </summary>
        void AnaylseMulti()
        {

        }

        
    }
}
