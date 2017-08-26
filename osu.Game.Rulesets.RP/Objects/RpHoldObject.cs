// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Game.Rulesets.Objects.Types;
using osu.Game.Rulesets.RP.Input;

namespace osu.Game.Rulesets.RP.Objects
{
    /// <summary>
    ///     RP������
    /// </summary>
    public class RpHoldObject : RpHitObject, IHasEndTime
    {
        //end time
        public double EndTime { get; set; }

        //Duration
        public double Duration => EndTime - StartTime;

        //ObjectType
        public override ObjectType ObjectType => ObjectType.Hold;

        //Constructor
        public RpHoldObject(RpContainerLine parent, double startTime)
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
