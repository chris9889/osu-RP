// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap.HitObjectGegenerator.Parameter;
using osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap.Parameter;
using osu.Game.Rulesets.RP.Objects;

namespace osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap.HitObjectGegenerator.Type
{
    /// <summary>
    ///     陌慕炊combo譎ら噪迢諷・
    /// </summary>
    internal class ProcessComboObject
    {
        public bool FisrtConbo;
        private ConvertParameter _singleSlideParameter;

        private bool convert;

        //荳贋ｸ蛟狗ｾ､邨・噪迚ｩ莉ｶ
        private SingleHitObjectConvertParameter _lastHitObjectTuple;

        internal void Process(SingleHitObjectConvertParameter singleTuple, int nowIndex)
        {
            //荳贋ｸ蛟狗ｾ､邨・噪迚ｩ莉ｶ
            _lastHitObjectTuple = _singleSlideParameter.HitObjectConvertParameter.ListSingleHitObjectConvertParameter[nowIndex - 1];

            if (FisrtConbo)
            {
                OptimizeBetterHitExperiance();
                FisrtConbo = false;
            }

            if (convert)
            {
                for (var i = 0; i < singleTuple.ListBaseHitObject.Count; i++)
                    if (_lastHitObjectTuple.ListBaseHitObject.Count > i)
                        singleTuple.ListBaseHitObject[i].Shape = FindNext(_lastHitObjectTuple.ListBaseHitObject[i].Shape);
                convert = false;
            }
            else
            {
                for (var i = 0; i < singleTuple.ListBaseHitObject.Count; i++)
                    if (_lastHitObjectTuple.ListBaseHitObject.Count > i)
                        singleTuple.ListBaseHitObject[i].Shape = FindPrevious(_lastHitObjectTuple.ListBaseHitObject[i].Shape);
                convert = true;
            }
        }

        internal void SetConvertParameter(ConvertParameter singleSlideParameter)
        {
            _singleSlideParameter = singleSlideParameter;
        }

        /// <summary>
        ///     if first combo Object comes to up down left right
        ///     it will assign the priority that is better to hit
        /// </summary>
        private void OptimizeBetterHitExperiance()
        {
            switch (_lastHitObjectTuple.ListBaseHitObject[0].Shape)
            {
                case Shape.Up:
                    convert = false;
                    break;
                case Shape.Down:
                    convert = true;
                    break;
                case Shape.Left: //蝗轤ｺ蟾ｦ驍顔悄逧・怏螟髮｣謇難ｼ御ｹｾ閼・ｸ崎ｦ∬ｮ灘ｮ・・迴ｾ螂ｽ莠・
                    //_lastHitObjectTuple.ListBaseHitObject[0].Shape = Shape.Right;
                    convert = false;
                    break;
                case Shape.Right:
                    convert = true;
                    break;
            }
        }

        /// <summary>
        ///     Up>>Left>>Down>>Right
        /// </summary>
        /// <param name="nowShape"></param>
        /// <returns></returns>
        private Shape FindNext(Shape nowShape)
        {
            switch (nowShape)
            {
                case Shape.Up:
                    return Shape.Left;
                case Shape.Left:
                    return Shape.Down;
                case Shape.Down:
                    return Shape.Right;
                case Shape.Right:
                    return Shape.Up;
            }
            return Shape.Down;
        }

        private Shape FindPrevious(Shape nowShape)
        {
            switch (nowShape)
            {
                case Shape.Up:
                    return Shape.Right;
                case Shape.Left:
                    return Shape.Up;
                case Shape.Down:
                    return Shape.Left;
                case Shape.Right:
                    return Shape.Down;
            }
            return Shape.Down;
        }
    }
}
