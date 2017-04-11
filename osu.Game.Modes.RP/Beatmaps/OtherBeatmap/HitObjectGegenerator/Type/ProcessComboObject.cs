// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Game.Modes.RP.Beatmaps.OtherBeatmap.HitObjectGegenerator.Parameter;
using osu.Game.Modes.RP.Beatmaps.OtherBeatmap.Parameter;
using osu.Game.Modes.RP.Objects.type;

namespace osu.Game.Modes.RP.Beatmaps.OtherBeatmap.HitObjectGegenerator.Type
{
    /// <summary>
    ///     處理combo時的狀態
    /// </summary>
    internal class ProcessComboObject
    {
        public bool FisrtConbo;
        private ConvertParameter _singleSlideParameter;

        private bool convert;

        //上一個群組的物件
        private SingleHitObjectConvertParameter _lastHitObjectTuple;

        internal void Process(SingleHitObjectConvertParameter singleTuple, int nowIndex)
        {
            //上一個群組的物件
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
                case RpBaseHitObjectType.Shape.Up:
                    convert = false;
                    break;
                case RpBaseHitObjectType.Shape.Down:
                    convert = true;
                    break;
                case RpBaseHitObjectType.Shape.Left: //因為左邊真的有夠難打，乾脆不要讓它出現好了
                    //_lastHitObjectTuple.ListBaseHitObject[0].Shape = RpBaseHitObjectType.Shape.Right;
                    convert = false;
                    break;
                case RpBaseHitObjectType.Shape.Right:
                    convert = true;
                    break;
            }
        }

        /// <summary>
        ///     Up>>Left>>Down>>Right
        /// </summary>
        /// <param name="nowShape"></param>
        /// <returns></returns>
        private RpBaseHitObjectType.Shape FindNext(RpBaseHitObjectType.Shape nowShape)
        {
            switch (nowShape)
            {
                case RpBaseHitObjectType.Shape.Up:
                    return RpBaseHitObjectType.Shape.Left;
                case RpBaseHitObjectType.Shape.Left:
                    return RpBaseHitObjectType.Shape.Down;
                case RpBaseHitObjectType.Shape.Down:
                    return RpBaseHitObjectType.Shape.Right;
                case RpBaseHitObjectType.Shape.Right:
                    return RpBaseHitObjectType.Shape.Up;
            }
            return RpBaseHitObjectType.Shape.Down;
        }

        private RpBaseHitObjectType.Shape FindPrevious(RpBaseHitObjectType.Shape nowShape)
        {
            switch (nowShape)
            {
                case RpBaseHitObjectType.Shape.Up:
                    return RpBaseHitObjectType.Shape.Right;
                case RpBaseHitObjectType.Shape.Left:
                    return RpBaseHitObjectType.Shape.Up;
                case RpBaseHitObjectType.Shape.Down:
                    return RpBaseHitObjectType.Shape.Left;
                case RpBaseHitObjectType.Shape.Right:
                    return RpBaseHitObjectType.Shape.Down;
            }
            return RpBaseHitObjectType.Shape.Down;
        }
    }
}
