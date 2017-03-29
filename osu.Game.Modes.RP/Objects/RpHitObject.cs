//Copyright (c) 2007-2016 ppy Pty Ltd <contact@ppy.sh>.
//Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using osu.Game.Modes.RP.Objects.type;

namespace osu.Game.Modes.RP.Objects
{
    public class RpHitObject : BaseHitObject
    {
        /// <summary>
        ///     初始化預設物件
        /// </summary>
        public override void InitialDefaultValue()
        {
            base.InitialDefaultValue();
            ObjectType = RpBaseObjectType.ObjectType.Click;
        }
    }
}
