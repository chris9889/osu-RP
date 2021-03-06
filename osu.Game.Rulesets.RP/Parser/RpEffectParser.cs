﻿using System;
using System.Collections.Generic;
using System.Globalization;
using osu.Game.Audio;
using osu.Game.Rulesets.Objects;
using osu.Game.Rulesets.RP.Objects;
using osu.Game.Rulesets.RP.Objects.type;
using OpenTK;
using SliderCurve = osu.Game.Rulesets.RP.Objects.MovingPath.SliderCurve;
   
namespace osu.Game.Rulesets.RP.Parser
{
    /// <summary>
    /// the class that use to convert effect string to RpEffect
    /// this Parser may be use in skin
    /// </summary>
    public class RpEffectParser : HitObjectParser
    {
        public RpEffectParser()
        {
        }

        /// <summary>
        ///     convert string to RpEffect
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public override HitObject Parse(string text)
        {
            var split = text.Split(',');
            var type = (RpBaseObjectType.ObjectType)int.Parse(split[3]);
            var combo = type.HasFlag(RpBaseObjectType.ObjectType.NewCombo);
            type &= (RpBaseObjectType.ObjectType)0xF;
            type &= ~RpBaseObjectType.ObjectType.NewCombo;
            BaseRpHitableObject result;
            switch (type)
            {
                case RpBaseObjectType.ObjectType.Click:
                    result = new RpHitObject();
                    break;
                case RpBaseObjectType.ObjectType.LongTail:
                    var s = new RpHoldObject();

                    var curveType = RpBaseObjectType.CurveTypes.Catmull;
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
                                    curveType = RpBaseObjectType.CurveTypes.Catmull;
                                    break;
                                case @"B":
                                    curveType = RpBaseObjectType.CurveTypes.Bezier;
                                    break;
                                case @"L":
                                    curveType = RpBaseObjectType.CurveTypes.Linear;
                                    break;
                                case @"P":
                                    curveType = RpBaseObjectType.CurveTypes.PerfectCurve;
                                    break;
                            }
                            continue;
                        }

                        var temp = pointsplit[i].Split(':');
                        var v = new Vector2(
                            (int)System.Convert.ToDouble(temp[0], CultureInfo.InvariantCulture),
                            (int)System.Convert.ToDouble(temp[1], CultureInfo.InvariantCulture)
                        );
                        points.Add(v);
                    }

                    repeatCount = System.Convert.ToInt32(split[6], CultureInfo.InvariantCulture);

                    if (repeatCount > 9000)
                        throw new ArgumentOutOfRangeException("wacky man");

                    if (split.Length > 7)
                        length = System.Convert.ToDouble(split[7], CultureInfo.InvariantCulture);

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
                case RpBaseObjectType.ObjectType.ContainerPress:
                    result = new RpContainerLineHoldObject();
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
