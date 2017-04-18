using System;
using System.Collections.Generic;
using osu.Game.Beatmaps;
using osu.Game.Rulesets.Beatmaps;
using osu.Game.Rulesets.Objects;
using osu.Game.Rulesets.Objects.Types;
using osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap.ContainerGegenerator;
using osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap.HitObjectGegenerator;
using osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap.PostConvert;
using osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap.Slicing;
using osu.Game.Rulesets.RP.Objects;

namespace osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap
{
    /// <summary>
    ///     can convert any beatmap from any other beatmap
    /// </summary>
    public class BeatmapConvertor : BeatmapConverter<BaseRpObject>
    {
        //蛻・・ｽ・ｽ
        private readonly SliceProcessor sliceProcessor = new SliceProcessor();

        //蟒ｺ讒気ontainer
        private readonly ContainerProcessor containerProcessor = new ContainerProcessor();

        //蟒ｺ讒区遠謫顔黄莉ｶ
        private readonly HitObjectProcessor hitObjectProcessor = new HitObjectProcessor();

        //謚雁純謨ｸ霓牙屓RP迚ｩ莉ｶ
        private readonly PostConvertor postConvertor = new PostConvertor();


        protected override IEnumerable<Type> ValidConversionTypes { get; } = new[] { typeof(IHasEndTime) };

        
        /// <summary>
        /// this method does not in use
        /// </summary>
        /// <param name="original"></param>
        /// <param name="beatmap"></param>
        /// <returns></returns>
        protected override IEnumerable<BaseRpObject> ConvertHitObject(HitObject original, Beatmap beatmap)
        {
            IHasCurve curveData = original as IHasCurve;
            IHasEndTime endTimeData = original as IHasEndTime;
            IHasPosition positionData = original as IHasPosition;
            IHasCombo comboData = original as IHasCombo;

            /*
            if (curveData != null)
            {
                yield return new RpSlider
                {
                    StartTime = original.StartTime,
                    Samples = original.Samples,
                    CurveObject = curveData,
                    Position = positionData?.Position ?? Vector2.Zero,
                    NewCombo = comboData?.NewCombo ?? false
                };
            }
            else if (endTimeData != null)
            {
                yield return new Spinner
                {
                    StartTime = original.StartTime,
                    Samples = original.Samples,
                    EndTime = endTimeData.EndTime,

                    Position = positionData?.Position ?? OsuPlayfield.BASE_SIZE / 2,
                };
            }
            else
            {
                yield return new HitCircle
                {
                    StartTime = original.StartTime,
                    Samples = original.Samples,
                    Position = positionData?.Position ?? Vector2.Zero,
                    NewCombo = comboData?.NewCombo ?? false
                };
            }
           */
         
            yield return (BaseRpObject)original;
        }

        /// <summary>
        /// Performs the conversion of a Beatmap using this Beatmap Converter.
        /// </summary>
        /// <param name="original">The un-converted Beatmap.</param>
        /// <returns>The converted Beatmap.</returns>
        protected override Beatmap<BaseRpObject> ConvertBeatmap(Beatmap original)
        {
            return new Beatmap<BaseRpObject>(original)
            {
                HitObjects = convertHitObjects(original, original.BeatmapInfo?.StackLeniency ?? 0.7f),
            };
        }


        /// <summary>
        ///     陬｡髱｢荳滂ｿｽE逧・・ｽE譏ｯOsuHitObject
        ///     隕∬ｽ画鋤謌・RPHitObject
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private List<BaseRpObject> convertHitObjects(Beatmap originalBeatmap, float stackLeniency)
        {
            //蜈域滑listObject蛻・・ｽE萓・
            var listComvertParameter = sliceProcessor.GetListConvertParameter(originalBeatmap);
            //謨ｴ逅・・ｽEContainer
            listComvertParameter = containerProcessor.Convert(listComvertParameter);
            //謨ｴ逅・・ｽEHitObjects
            listComvertParameter = hitObjectProcessor.Convert(listComvertParameter);
            //霓牙屓蜴滓悽逧・・ｽ・ｽ莉ｶ
            return postConvertor.Convert(listComvertParameter);
        }
    }
}
