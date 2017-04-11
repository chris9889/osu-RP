// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Game.Modes.RP.Beatmaps.OtherBeatmap.HitObjectGegenerator.Parameter;
using osu.Game.Modes.RP.Beatmaps.OtherBeatmap.Parameter;

namespace osu.Game.Modes.RP.Beatmaps.OtherBeatmap.HitObjectGegenerator.Type
{
    public class TypeCalculator
    {
        //計算隨機
        private readonly ProcessObjectTypeRandom _processObjectTypeRandom = new ProcessObjectTypeRandom();

        //Calculate combo
        private readonly ProcessComboObject _processComboObject = new ProcessComboObject();

        //單一一段的物件
        private ConvertParameter _singleSlideParameter;

        public void ProcessType(ConvertParameter single)
        {
            _singleSlideParameter = single;
            _processObjectTypeRandom.SetConvertParameter(_singleSlideParameter);
            _processComboObject.SetConvertParameter(_singleSlideParameter);
            var tupleCount = _singleSlideParameter.HitObjectConvertParameter.ListSingleHitObjectConvertParameter.Count;
            for (var i = 0; i < tupleCount; i++)
                if (single.HitObjectConvertParameter.ListSingleHitObjectConvertParameter[i].IsCombo)
                    AssignComboTupleShapes(single.HitObjectConvertParameter.ListSingleHitObjectConvertParameter[i], i); //Combo
                else
                    AssignNormalTupleShapes(single.HitObjectConvertParameter.ListSingleHitObjectConvertParameter[i]); //Normal
        }

        //指定一般
        public void AssignNormalTupleShapes(SingleHitObjectConvertParameter singleTuple)
        {
            _processObjectTypeRandom.Process(singleTuple);
            _processComboObject.FisrtConbo = true;
        }

        //指定Combo
        public void AssignComboTupleShapes(SingleHitObjectConvertParameter singleTuple, int index)
        {
            if (index != 0)
                _processComboObject.Process(singleTuple, index);
            else
                AssignNormalTupleShapes(singleTuple);
        }
    }
}
