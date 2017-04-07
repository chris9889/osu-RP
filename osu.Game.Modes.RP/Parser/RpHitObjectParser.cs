//Copyright (c) 2007-2016 ppy Pty Ltd <contact@ppy.sh>.
//Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System;
using System.Collections.Generic;
using System.Globalization;
using osu.Game.Audio;
using osu.Game.Modes.Objects;
using osu.Game.Modes.RP.Objects;
using OpenTK;
using static osu.Game.Modes.RP.Objects.type.RpBaseObjectType;
using SliderCurve = osu.Game.Modes.RP.Objects.MovingPath.SliderCurve;

namespace osu.Game.Modes.RP.Parser
{
    public class RpHitObjectParser : HitObjectParser
    {
        /// <summary>
        ///     如果是RP專用譜面，就會用者這個轉換器
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public override HitObject Parse(string text)
        {
            var split = text.Split(',');
            var type = (ObjectType)int.Parse(split[3]);
            var combo = type.HasFlag(ObjectType.NewCombo);
            type &= (ObjectType)0xF;
            type &= ~ObjectType.NewCombo;
            BaseHitObject result;
            switch (type)
            {
                case ObjectType.Click:
                    result = new RpHitObject();
                    break;
                case ObjectType.LongTail:
                    var s = new RpLongTailObject();

                    var curveType = CurveTypes.Catmull;
                    var repeatCount = 0;
                    double length = 0;
                    var points = new List<Vector2>();

                    points.Add(new Vector2(int.Parse(split[0]), int.Parse(split[1])));

                    var pointsplit = split[5].Split('|');
                    for (var i = 0; i < pointsplit.Length; i++)
                    {
                        if (pointsplit[i].Length == 1)
                        {
                            switch (pointsplit[i])
                            {
                                case @"C":
                                    curveType = CurveTypes.Catmull;
                                    break;
                                case @"B":
                                    curveType = CurveTypes.Bezier;
                                    break;
                                case @"L":
                                    curveType = CurveTypes.Linear;
                                    break;
                                case @"P":
                                    curveType = CurveTypes.PerfectCurve;
                                    break;
                            }
                            continue;
                        }

                        var temp = pointsplit[i].Split(':');
                        var v = new Vector2(
                            (int)Convert.ToDouble(temp[0], CultureInfo.InvariantCulture),
                            (int)Convert.ToDouble(temp[1], CultureInfo.InvariantCulture)
                        );
                        points.Add(v);
                    }

                    repeatCount = Convert.ToInt32(split[6], CultureInfo.InvariantCulture);

                    if (repeatCount > 9000)
                        throw new ArgumentOutOfRangeException("wacky man");

                    if (split.Length > 7)
                        length = Convert.ToDouble(split[7], CultureInfo.InvariantCulture);

                    //s.RepeatCount = repeatCount;

                    //建立裡面的所有座標
                    s.Curve = new SliderCurve
                    {
                        ControlPoints = points,
                        Length = length,
                        CurveType = curveType
                    };

                    s.Curve.Calculate();

                    result = s;
                    break;
                case ObjectType.ContainerPress:
                    result = new RpContainerPress();
                    break;
                default:
                    //throw new InvalidOperationException($@"Unknown hit object type {type}");
                    return null;
            }
            result.Position = new Vector2(int.Parse(split[0]), int.Parse(split[1]));
            result.StartTime = double.Parse(split[2]);
            result.Samples.Add(
                  new SampleInfo
                  {
                      Bank = "whistle",
                      Name = "soft"
                  }
                );
            //result.NewCombo = combo;
            // TODO: "addition" field
            return result;
        }
    }
}
