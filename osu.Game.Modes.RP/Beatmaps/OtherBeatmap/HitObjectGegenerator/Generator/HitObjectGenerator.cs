// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;
using osu.Framework.Audio.Sample;
using osu.Game.Beatmaps.Samples;
using osu.Game.Modes.RP.Beatmaps.OtherBeatmap.HitObjectGegenerator.Parameter;
using osu.Game.Modes.RP.Beatmaps.OtherBeatmap.Parameter;
using osu.Game.Modes.RP.Objects;
using OpenTK;

namespace osu.Game.Modes.RP.Beatmaps.OtherBeatmap.HitObjectGegenerator.Generator
{
    /// <summary>
    /// 
    /// </summary>
    public class HitObjectGenerator
    {
        public List<List<BaseHitObject>> GeneratorListHitObject(ComvertParameter single)
        {
            List<List<BaseHitObject>> list =new List<List<BaseHitObject>>();
            foreach (SingleHitObjectConvertParameter singleHitObject in single.HitObjectConvertParameter.ListSingleHitObjectConvertParameter)
            {
                List<BaseHitObject> singleHitObjects = new List<BaseHitObject>();
                for (int i = 0; i < singleHitObject.MultiNumber; i++)
                {
                    singleHitObjects.Add(GenerateRpHitObject(singleHitObject));
                }
                list.Add(singleHitObjects);
            }

            return list;
        }

        public RpHitObject GenerateRpHitObject(SingleHitObjectConvertParameter singleHitObject)
        {
            RpHitObject rpHitObject=new RpHitObject();
            //fake sample
            rpHitObject.Sample = new HitSampleInfo
            {
                Type = SampleType.None,
                Set = SampleSet.Soft,
            };
            //fake position
            rpHitObject.Position=new Vector2(100,100);

            rpHitObject.StartTime = singleHitObject.StartTime;
            return rpHitObject;
        }
    }
}