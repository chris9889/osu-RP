//Copyright (c) 2007-2016 ppy Pty Ltd <contact@ppy.sh>.
//Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using osu.Game.Beatmaps.Samples;
using osu.Game.Modes.Objects;
using OpenTK;
using osu.Game.Modes.RP.Objects;
using osu.Game.Modes.RP.Objects.MovingPath;
using static osu.Game.Modes.RP.Objects.BaseHitObject;
using osu.Game.Modes.RP.Objects.type;
using static osu.Game.Modes.RP.Objects.type.RpBaseHitObjectType;
using static osu.Game.Modes.RP.Objects.type.RpBaseObjectType;

namespace osu.Game.Modes.RP.Parser
{
    public class RpHitObjectParser : HitObjectParser
    {
        /// <summary>
        /// 如果是RP專用譜面，就會用者這個轉換器
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public override HitObject Parse(string text)
        {
            string[] split = text.Split(',');
            var type = (RpBaseHitObjectType.ObjectType)int.Parse(split[3]);
            bool combo = type.HasFlag(RpBaseHitObjectType.ObjectType.NewCombo);
            type &= (RpBaseHitObjectType.ObjectType)0xF;
            type &= ~RpBaseHitObjectType.ObjectType.NewCombo;
            BaseHitObject result;
            switch (type)
            {
                case RpBaseHitObjectType.ObjectType.Click:
                    result = new RpHitObject();
                    break;
                case RpBaseHitObjectType.ObjectType.LongTail:
                    RpLongTailObject s = new RpLongTailObject();

                    CurveTypes curveType = CurveTypes.Catmull;
                    int repeatCount = 0;
                    double length = 0;
                    List<Vector2> points = new List<Vector2>();

                    points.Add(new Vector2(int.Parse(split[0]), int.Parse(split[1])));

                    string[] pointsplit = split[5].Split('|');
                    for (int i = 0; i < pointsplit.Length; i++)
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

                        string[] temp = pointsplit[i].Split(':');
                        Vector2 v = new Vector2(
                            (int)System.Convert.ToDouble(temp[0], CultureInfo.InvariantCulture),
                            (int)System.Convert.ToDouble(temp[1], CultureInfo.InvariantCulture)
                        );
                        points.Add(v);
                    }

                    repeatCount = System.Convert.ToInt32(split[6], CultureInfo.InvariantCulture);

                    if (repeatCount > 9000)
                    {
                        throw new ArgumentOutOfRangeException("wacky man");
                    }

                    if (split.Length > 7)
                        length = System.Convert.ToDouble(split[7], CultureInfo.InvariantCulture);

                    //s.RepeatCount = repeatCount;

                    //建立裡面的所有座標
                    s.Curve = new Objects.MovingPath.SliderCurve
                    {
                        ControlPoints = points,
                        Length = length,
                        CurveType = curveType
                    };

                    s.Curve.Calculate();

                    result = s;
                    break;
                case RpBaseHitObjectType.ObjectType.ContainerPress:
                    result = new RpContainerPress();
                    break;
                default:
                    //throw new InvalidOperationException($@"Unknown hit object type {type}");
                    return null;
            }
            result.Position = new Vector2(int.Parse(split[0]), int.Parse(split[1]));
            result.StartTime = double.Parse(split[2]);
            result.Sample = new HitSampleInfo {
                Type = (SampleType)int.Parse(split[4]),
                Set = SampleSet.Soft,
            };
            //result.NewCombo = combo;
            // TODO: "addition" field
            return result;
        }
    }
}
