//Copyright (c) 2007-2016 ppy Pty Ltd <contact@ppy.sh>.
//Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using osu.Game.Modes.RP.Objects.type;

namespace osu.Game.Modes.RP.Objects
{
    /// <summary>
    ///     RP長物件
    /// </summary>
    public class RpLongTailObject : BaseHitObject
    {
        /// <summary>
        ///     結束時間
        /// </summary>
        public double EndTime => StartTime + Curve.Length / Velocity;

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
