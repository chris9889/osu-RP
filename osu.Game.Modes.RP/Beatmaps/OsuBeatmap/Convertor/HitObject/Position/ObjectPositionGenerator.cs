using System.Collections.Generic;
using osu.Game.Modes.RP.Beatmaps.OsuBeatmap.Convertor.HitObject.Position.EndPosition;
using osu.Game.Modes.RP.Beatmaps.OsuBeatmap.Convertor.HitObject.Position.PathPosition;
using osu.Game.Modes.RP.Beatmaps.OsuBeatmap.Convertor.HitObject.Position.StartPosition;
using osu.Game.Modes.RP.Beatmaps.OsuBeatmap.Parameter;

namespace osu.Game.Modes.RP.Beatmaps.OsuBeatmap.Convertor.HitObject.Position
{
    class ObjectPositionGenerator
    {
        StartPositionGenerator _startPositionGenerator=new StartPositionGenerator();

        EndPositionGenerator _endPositionGenerator=new EndPositionGenerator();

        RpPathGenerator _rpPathGenerator=new RpPathGenerator();

        /// <summary>
        /// 轉換座標
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        internal List<HitObjectConvertParameter> Convert(List<HitObjectConvertParameter> input)
        {
            foreach (HitObjectConvertParameter single in input)
            {
                ProcessSingleItem(single);
            }
            return input;
        }

        /// <summary>
        /// 轉換單一物件
        /// </summary>
        /// <param name="input"></param>
        void ProcessSingleItem(HitObjectConvertParameter input)
        {
            //all auto
            if (input.ListConvertedParameter[0].CurveGenerate == Objects.type.RpBaseHitObjectType.CurveGenerate.Auto)
            {
                _startPositionGenerator.Process(input);
            }

            //auto create stop position
            if (input.ListConvertedParameter[0].CurveGenerate >= Objects.type.RpBaseHitObjectType.CurveGenerate.Manual_Start_End_Position)
            {
                _endPositionGenerator.Process(input);
            }

            //create path
            if (input.ListConvertedParameter[0].CurveGenerate >= Objects.type.RpBaseHitObjectType.CurveGenerate.Manual_StartPosition)
            {
                _rpPathGenerator.Process(input);
            }
        }
    }
}
