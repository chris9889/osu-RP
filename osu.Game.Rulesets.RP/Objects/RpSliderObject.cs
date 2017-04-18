//Copyright (c) 2007-2016 ppy Pty Ltd <contact@ppy.sh>.
//Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System;
using osu.Game.Rulesets.Objects.Types;
using osu.Game.Rulesets.RP.Objects.type;

namespace osu.Game.Rulesets.RP.Objects
{
    /// <summary>
    ///     RP長物件
    /// </summary>
    public class RpSliderObject : BaseRpHitObject, IHasEndTime
    {
        public bool isHold
        {
            get
            {
                if (StartHoldingTime >= EndTime)
                    return true;
                return false;
            }
            set
            {
                if (value == true)
                    StartHoldingTime = EndTime;
            }

        }
        /// <summary>
        /// the time that starting holding
        /// </summary>
        public double StartHoldingTime;

        /// <summary>
        ///     結束時間
        /// </summary>
        public double EndTime => StartTime + Curve.Length / Velocity;


        public void SetEndTime(Double time)
        {
            //EndTime = time;
        }

        /// <summary>
        ///     初始化預設物件
        /// </summary>
        public override void InitialDefaultValue()
        {
            base.InitialDefaultValue();
            ObjectType = RpBaseObjectType.ObjectType.LongTail;
        }
    }
}
