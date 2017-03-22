// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE
using System;
using System.Collections.Generic;
using osu.Game.Modes.RP.Beatmaps.OtherBeatmap.HitObjectGegenerator.Parameter;
using osu.Game.Modes.RP.Beatmaps.OtherBeatmap.Parameter;
using osu.Game.Modes.RP.Objects.type;

namespace osu.Game.Modes.RP.Beatmaps.OtherBeatmap.HitObjectGegenerator.Type
{
    /// <summary>
    /// 處理combo時的狀態
    /// </summary>
    public class ProcessComboObject
    {
        private ComvertParameter _singleSlideParameter;

        private bool convert = false;

        internal void Process(SingleHitObjectConvertParameter singleTuple,int nowIndex)
        {
            //上一個群組的物件
            SingleHitObjectConvertParameter lastHitObjectTuple= _singleSlideParameter.HitObjectConvertParameter.ListSingleHitObjectConvertParameter[nowIndex - 1];
            if (convert)
            {
                for (int i = 0; i < singleTuple.ListBaseHitObject.Count; i++)
                {
                    if (lastHitObjectTuple.ListBaseHitObject.Count > i)
                    {
                        singleTuple.ListBaseHitObject[i].Shape = FindNext(lastHitObjectTuple.ListBaseHitObject[i].Shape);
                    }
                }
                convert = false;
            }
            else
            {
                for (int i = 0; i < singleTuple.ListBaseHitObject.Count; i++)
                {
                    if (lastHitObjectTuple.ListBaseHitObject.Count > i)
                    {
                        singleTuple.ListBaseHitObject[i].Shape = FindNext(lastHitObjectTuple.ListBaseHitObject[i].Shape);
                    }
                }
                convert = true;
            }
            
        }

        internal void SetComvertParameter(ComvertParameter singleSlideParameter)
        {
            _singleSlideParameter = singleSlideParameter;
        }

        /// <summary>
        /// Up>>Left>>Down>>Right
        /// </summary>
        /// <param name="nowShape"></param>
        /// <returns></returns>
        RpBaseHitObjectType.Shape FindNext(RpBaseHitObjectType.Shape nowShape)
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

        RpBaseHitObjectType.Shape FindPrevious(RpBaseHitObjectType.Shape nowShape)
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