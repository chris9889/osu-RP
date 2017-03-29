// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Game.Modes.RP.Beatmaps.OtherBeatmap.HitObjectGegenerator.Parameter;
using osu.Game.Modes.RP.Beatmaps.OtherBeatmap.Parameter;
using osu.Game.Modes.RP.Objects.type;

namespace osu.Game.Modes.RP.Beatmaps.OtherBeatmap.HitObjectGegenerator.Type
{
    public class ProcessObjectTypeRandom
    {
        //單一一段的物件
        private ComvertParameter _singleSlideParameter;


        internal void SetComvertParameter(ComvertParameter singleSlideParameter)
        {
            _singleSlideParameter = singleSlideParameter;
        }


        internal void Process(SingleHitObjectConvertParameter singleTuple)
        {
            for (var i = 0; i < singleTuple.ListBaseHitObject.Count; i++)
                singleTuple.ListBaseHitObject[i].Shape = CalRandomShape(singleTuple, i);
        }

        /// <summary>
        ///     計算隨機形狀
        /// </summary>
        /// <returns></returns>
        private RpBaseHitObjectType.Shape CalRandomShape(SingleHitObjectConvertParameter singleTuple, int index)
        {
            var randNum = CalRandNumber(singleTuple, index);
            switch (randNum % 4)
            {
                case 0:
                    return RpBaseHitObjectType.Shape.Up;
                case 1:
                    return RpBaseHitObjectType.Shape.Left;
                case 2:
                    return RpBaseHitObjectType.Shape.Down;
                case 3:
                    return RpBaseHitObjectType.Shape.Right;
            }
            return RpBaseHitObjectType.Shape.Down;
        }

        /// <summary>
        ///     產生隨機參數
        /// </summary>
        /// <returns></returns>
        private int CalRandNumber(SingleHitObjectConvertParameter singleTuple, int index)
        {
            var addNumber = 0;
            if (index == 1) //第二個物件
                addNumber = 2;
            if (index == 2) //第三個物件
                addNumber = 1;
            if (index == 2) //第四個物件
                addNumber = 3;

            return singleTuple.MultiNumber + (int)singleTuple.StartTime + singleTuple.ListBaseHitObject.Count + addNumber;

            //BPM，為了避免BPM 200 的譜特別簡單
            var periodTime = (int)(60 / (double)(int)_singleSlideParameter.SliceConvertParameter.BPM) * 1000;
            //
            return singleTuple.MultiNumber + (int)singleTuple.StartTime % periodTime + singleTuple.ListBaseHitObject.Count;
        }

        /// <summary>
        ///     產生隨機參數
        ///     目前先保存下來
        /// </summary>
        /// <returns></returns>
        private int OLD_CalRandNumber(SingleHitObjectConvertParameter singleTuple)
        {
            return singleTuple.MultiNumber + (int)singleTuple.StartTime + singleTuple.ListBaseHitObject.Count;
        }
    }
}
