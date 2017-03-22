// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE
using System;
using System.Collections.Generic;
using osu.Game.Modes.RP.Beatmaps.OtherBeatmap.Parameter;
using osu.Game.Modes.RP.Objects;

namespace osu.Game.Modes.RP.Beatmaps.OtherBeatmap.HitObjectGegenerator.Position
{
    public class PositionGenerator
    {
        internal void ProcessPosition(ComvertParameter single)
        {
            //同一群組內的物件位置
            foreach (List<BaseHitObject> singleTupleHitObjects in single.ListBaseHitObject)
            {
                for (int i = 0; i < singleTupleHitObjects.Count; i++)
                {
                    singleTupleHitObjects[i].ContainerIndex = 0;
                    singleTupleHitObjects[i].LayoutIndex = 0;
                }
            }
        }
    }
}