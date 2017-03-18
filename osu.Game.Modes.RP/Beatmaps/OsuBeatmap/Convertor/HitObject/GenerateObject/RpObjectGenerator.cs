using System.Collections.Generic;
using osu.Game.Modes.Osu.Objects;
using osu.Game.Modes.RP.Beatmaps.OsuBeatmap.Parameter;
using osu.Game.Modes.RP.Objects;
using osu.Game.Modes.RP.Objects.type;
using OpenTK;

namespace osu.Game.Modes.RP.Beatmaps.OsuBeatmap.Convertor.HitObject.GenerateObject
{
    /// <summary>
    /// 產生出對應物件
    /// </summary>
    class RpObjectGenerator
    {
        /// <summary>
        /// 處理所有物件
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public List<HitObjectConvertParameter> Convert(List<HitObjectConvertParameter> input)
        {
            for(int i=0;i< input.Count;i++)
            {
                ConvertSingle(input[i]);
            }
            return input;
        }

        /// <summary>
        /// 建立單一時間點的所有物件
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private HitObjectConvertParameter ConvertSingle(HitObjectConvertParameter input)
        {
            /*
            for (int i = 0; i < 1; i++)
            {
                if (input.PassParameter.HitObjectType == RPBaseObjectType.HitObjectType.Click)
                {
                    input.ListConvertedParameter.Add(GenerateHitObject(input));
                }
                else if (input.PassParameter.HitObjectType == RPBaseObjectType.HitObjectType.LongHold)
                {
                    input.ListConvertedParameter.Add(GenerateLongTailObject(input));
                }
                else if (input.PassParameter.HitObjectType == RPBaseObjectType.HitObjectType.Slider)
                {
                    input.ListConvertedParameter.Add(GenerateRPHold(input));
                }
                else
                {

                }
            }
            */

            input.ListConvertedParameter.Add(GenerateHitObject(input));

            return input;
        }

        private RpHitObject GenerateHitObject(ConvertParameter input)
        {
            RpHitObject output = new RpHitObject();
            output = GenerateRPBaseHitObject(input, output);

            return output;
        }

        private RpHold GenerateRPHold(ConvertParameter input)
        {
            RpHold output = new RpHold();
            output = GenerateRPBaseHitObject(input, output);

            return output;
        }

        private RpContainerPress GenerateLeftRightSlider(ConvertParameter input)
        {
            RpContainerPress output = new RpContainerPress();
            output = GenerateRPBaseHitObject(input, output);
            
            return output;
        }

        private RpLongTailObject GenerateLongTailObject(ConvertParameter input)
        {
            RpLongTailObject output = new RpLongTailObject();
            output = GenerateRPBaseHitObject(input, output);

            output.Curve.Length = ((Slider)(input.OsuHitObject)).Distance;
            
            return output;
        }


        /// <summary>
        /// 這裡會把基本參數設定好
        /// </summary>
        /// <returns></returns>
        private T GenerateRPBaseHitObject<T>(ConvertParameter input, T baseHitObject) where T :BaseHitObject
        {

            baseHitObject.StartTime = input.OsuHitObject.StartTime;
            
            baseHitObject.Sample = input.OsuHitObject.Sample;
            //baseHitObject.NewCombo= input.OsuHitObject.NewCombo;

            
            baseHitObject.Curve = new Objects.MovingPath.SliderCurve()
            {
                ControlPoints = CreateFakeListPosition(input.OsuHitObject.Position),
                Length = 0,
                CurveType = RpBaseHitObjectType.CurveTypes.Bezier
            };

            baseHitObject.Position = input.OsuHitObject.Position;
            //baseHitObject.Position = new Vector2(0, 0);

            return baseHitObject;
        }

        private List<Vector2> CreateFakeListPosition(Vector2 startPosition)
        {
            List<Vector2> output = new List<Vector2>();
            //output.Add(startPosition);
            //output.Add(startPosition + new Vector2(250, 170));
            //output.Add(startPosition + new Vector2(200, 190));
            //output.Add(startPosition + new Vector2(500, 380));

            return output;
        }
    }
}
