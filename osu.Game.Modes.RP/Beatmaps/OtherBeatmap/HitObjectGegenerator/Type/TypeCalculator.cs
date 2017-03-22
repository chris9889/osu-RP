// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE
using System;
using System.Collections.Generic;
using osu.Game.Modes.RP.Beatmaps.OtherBeatmap.HitObjectGegenerator.Parameter;
using osu.Game.Modes.RP.Beatmaps.OtherBeatmap.Parameter;
using osu.Game.Modes.RP.Objects;
using osu.Game.Modes.RP.Objects.type;

namespace osu.Game.Modes.RP.Beatmaps.OtherBeatmap.HitObjectGegenerator.Type
{

    public class TypeCalculator
    {
        //計算隨機
        private ProcessObjectTypeRandom ProcessObjectTypeRandom = new ProcessObjectTypeRandom();

        private ProcessComboObject ProcessComboObject = new ProcessComboObject();

        //單一一段的物件
        private ComvertParameter _singleSlideParameter;

        public void ProcessType(ComvertParameter single)
        {
            _singleSlideParameter = single;
            ProcessObjectTypeRandom.SetComvertParameter(_singleSlideParameter);
            ProcessComboObject.SetComvertParameter(_singleSlideParameter);
            int tupleCount = _singleSlideParameter.HitObjectConvertParameter.ListSingleHitObjectConvertParameter.Count;
            for (int i = 0; i < tupleCount; i++)
            {
                if (single.HitObjectConvertParameter.ListSingleHitObjectConvertParameter[i].isCombo)
                {
                    AssignComboTupleShapes(single.HitObjectConvertParameter.ListSingleHitObjectConvertParameter[i], i);//Combo
                }
                else
                {
                    AssignNormalTupleShapes(single.HitObjectConvertParameter.ListSingleHitObjectConvertParameter[i]);//Normal
                }
            }
        }

        //指定一般
        public void AssignNormalTupleShapes(SingleHitObjectConvertParameter singleTuple)
        {
            ProcessObjectTypeRandom.Process(singleTuple);
        }

        //指定Combo
        public void AssignComboTupleShapes(SingleHitObjectConvertParameter singleTuple,int index)
        {
            if (index != 0)
            {
                ProcessComboObject.Process(singleTuple, index);
            }
            else
            {
                AssignNormalTupleShapes(singleTuple);
            }
        }

    }
}