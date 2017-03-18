using System.Collections.Generic;
using osu.Game.Modes.RP.Beatmaps.OsuBeatmap.Parameter;
using osu.Game.Modes.RP.Objects;
using osu.Game.Modes.RP.Objects.type;

namespace osu.Game.Modes.RP.Beatmaps.OsuBeatmap.Convertor.Container.GenerateObject
{
    class ContainerGenerator
    {
        /// <summary>
        /// 主要轉換
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public List<ContainerConvertParameter> Convert(List<ContainerConvertParameter> input)
        {
            for (int i = 0; i < input.Count; i++)
            {
                input[i] = ConvertSingle(input[i]);
            }
            return input;
        }

        /// <summary>
        /// 建立單一時間點的所有物件
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private ContainerConvertParameter ConvertSingle(ContainerConvertParameter input)
        {
            for (int i = 0; i < 1; i++)
            {
                input.ListConvertedParameter.Add(GenerateHitObject(input));
            }
            return input;
        }

        private ObjectContainer GenerateHitObject(ContainerConvertParameter input)
        {
            ObjectContainer output = new ObjectContainer(input.OsuHitObject.StartTime);

            output.Sample = input.OsuHitObject.Sample;
            //output.NewCombo = input.OsuHitObject.NewCombo;
            output.ContainerEndTime = input.PassParameter.EndTime;

            output.Curve = new Objects.MovingPath.SliderCurve()
            {
                ControlPoints = new List<OpenTK.Vector2>(),
                Length = 0,
                CurveType = RpBaseHitObjectType.CurveTypes.Bezier
            };
            output.Position = input.OsuHitObject.Position;
            //output.Position = new Vector2(100, 100);

            return output;
        }
    }
}
