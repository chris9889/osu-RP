// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Game.Rulesets.RP.Objects.Types;

namespace osu.Game.Rulesets.RP.Objects
{
    public class RpHitObject : BaseRpHitableObject
    {
        //ObjectType
        public override ObjectType ObjectType => ObjectType.Hit;

        //constructure
        public RpHitObject(RpContainerLine parent, double startTime)
            : base(parent, startTime)
        {
        }

        //InitialDefaultValue
        protected override void InitialDefaultValue()
        {
            base.InitialDefaultValue();
        }
    }
}
