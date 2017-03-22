// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE
using System;
using System.Collections.Generic;
using osu.Game.Modes.RP.Beatmaps.OtherBeatmap.Parameter;
using osu.Game.Modes.RP.Objects;
using osu.Game.Modes.RP.Objects.type;

namespace osu.Game.Modes.RP.Beatmaps.OtherBeatmap.HitObjectGegenerator.Type
{

    public class TypeCalculator
    {

        public void ProcessType(ComvertParameter single)
        {
            foreach (List<BaseHitObject> singleTuple in single.ListBaseHitObject)
            {
                for (int i = 0; i < singleTuple.Count; i++)
                {
                    singleTuple[i].Shape= RpBaseHitObjectType.Shape.Circle;
                }
            }
        }
    }
}