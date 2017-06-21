//Copyright (c) 2007-2016 ppy Pty Ltd <contact@ppy.sh>.
//Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using osu.Game.Rulesets.RP.Objects.type;

namespace osu.Game.Rulesets.RP.Objects
{
    public class RpHitObject : BaseRpHitableObject
    {
        /// <summary>
        ///     èâénâªóaê›ï®åè
        /// </summary>
        public override void InitialDefaultValue()
        {
            base.InitialDefaultValue();
            ObjectType = RpBaseObjectType.ObjectType.Click;
        }
    }
}
