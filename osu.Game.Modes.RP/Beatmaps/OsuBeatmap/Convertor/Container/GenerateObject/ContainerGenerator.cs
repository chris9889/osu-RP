// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;
using osu.Game.Modes.RP.Beatmaps.OsuBeatmap.Parameter;
using osu.Game.Modes.RP.Objects;
using osu.Game.Modes.RP.Objects.MovingPath;
using osu.Game.Modes.RP.Objects.type;
using OpenTK;

namespace osu.Game.Modes.RP.Beatmaps.OsuBeatmap.Convertor.Container.GenerateObject
{
    internal class ContainerGenerator
    {
        /// <summary>
        ///     主要轉換
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public List<ContainerConvertParameter> Convert(List<ContainerConvertParameter> input)
        {
            for (var i = 0; i < input.Count; i++)
                input[i] = ConvertSingle(input[i]);
            return input;
        }

        /// <summary>
        ///     建立單一時間點的所有物件
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private ContainerConvertParameter ConvertSingle(ContainerConvertParameter input)
        {
            for (var i = 0; i < 1; i++)
                input.ListConvertedParameter.Add(GenerateHitObject(input));
            return input;
        }

        private ObjectContainer GenerateHitObject(ContainerConvertParameter input)
        {
            var output = new ObjectContainer(input.OsuHitObject.StartTime);

            output.Sample = input.OsuHitObject.Sample;
            //output.NewCombo = input.OsuHitObject.NewCombo;
            output.ContainerEndTime = input.PassParameter.EndTime;

            output.Curve = new SliderCurve
            {
                ControlPoints = new List<Vector2>(),
                Length = 0,
                CurveType = RpBaseObjectType.CurveTypes.Bezier
            };
            output.Position = input.OsuHitObject.Position;
            //output.Position = new Vector2(100, 100);

            return output;
        }
    }
}
