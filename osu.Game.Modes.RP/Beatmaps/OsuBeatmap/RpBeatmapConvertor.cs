// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;
using System.Linq;
using osu.Game.Beatmaps;
using osu.Game.Modes.Objects;
using osu.Game.Modes.Objects.Types;
using osu.Game.Modes.Osu.Objects;
using osu.Game.Modes.RP.Beatmaps.OsuBeatmap.OsuToParameter;
using osu.Game.Modes.RP.Beatmaps.OsuBeatmap.Parameter;
using osu.Game.Modes.RP.Beatmaps.OsuBeatmap.ParameterToRP;
using osu.Game.Modes.RP.Objects;
using OpenTK;

namespace osu.Game.Modes.RP.Beatmaps.OsuBeatmap
{
    /// <summary>
    ///     Osu譜面轉成物件
    /// </summary>
    public class RpBeatmapConvertor : IBeatmapConverter<BaseRpObject>
    {
        /// <summary>
        ///     osu 物件轉成參數
        /// </summary>
        private readonly OsuToParameterConvertor _parameterComvertor = new OsuToParameterConvertor();

        /// <summary>
        ///     參數轉換成RP物件
        /// </summary>
        private readonly ParameterToRpConvertor _rpObjectComvertor = new ParameterToRpConvertor();

        /// <summary>
        ///     中間參數轉換器
        /// </summary>
        private readonly Convertor.Convertor _convertor = new Convertor.Convertor();

        /// <summary>
        /// </summary>
        private List<ConvertParameter> _listParameter = new List<ConvertParameter>();


        Beatmap<BaseRpObject> IBeatmapConverter<BaseRpObject>.Convert(Beatmap original)
        {
            return new Beatmap<BaseRpObject>(original)
            {
                HitObjects = convertHitObjects(original, original.BeatmapInfo?.StackLeniency ?? 0.7f)
            };
        }

        /// <summary>
        ///     裡面丟入的都是OsuHitObject
        ///     要轉換成 RPHitObject
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private List<BaseRpObject> convertHitObjects(Beatmap originaBeatmap, float stackLeniency)
        {
            _rpObjectComvertor.SongBeatmap = originaBeatmap;
            _convertor.SongBeatmap = originaBeatmap;
            _convertor.SongBeatmap = originaBeatmap;


            var osuHitObjects = originaBeatmap.HitObjects.Select(convertHitObject).ToList();

            var output = new List<BaseRpObject>();

            var listHitObject = new List<HitObjectConvertParameter>();

            //先轉換成參數
            listHitObject = _parameterComvertor.Convert(osuHitObjects);

            //參數處理
            _listParameter = _convertor.Convert(listHitObject);
            //轉回RP物件
            output = _rpObjectComvertor.Convert(_listParameter);
            //return

            return output;
        }


        private OsuHitObject convertHitObject(HitObject original)
        {
            var curveData = original as IHasCurve;
            var endTimeData = original as IHasEndTime;
            var positionData = original as IHasPosition;
            var comboData = original as IHasCombo;

            if (curveData != null)
                return new Slider
                {
                    StartTime = original.StartTime,
                    Sample = original.Sample,
                    CurveObject = curveData,
                    Position = positionData?.Position ?? Vector2.Zero,
                    NewCombo = comboData?.NewCombo ?? false
                };

            if (endTimeData != null)
                return new Spinner
                {
                    StartTime = original.StartTime,
                    Sample = original.Sample,
                    Position = new Vector2(512, 384) / 2,
                    EndTime = endTimeData.EndTime
                };

            return new HitCircle
            {
                StartTime = original.StartTime,
                Sample = original.Sample,
                Position = positionData?.Position ?? Vector2.Zero,
                NewCombo = comboData?.NewCombo ?? false
            };
        }
    }
}
