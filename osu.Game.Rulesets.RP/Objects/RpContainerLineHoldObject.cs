// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Game.Rulesets.Objects.Types;

namespace osu.Game.Rulesets.RP.Objects
{
    /// <summary>
    ///     可以往左邊�E是右邊長壓滑動
    /// </summary>
    public class RpContainerLineHoldObject : BaseRpHitableObject, IHasEndTime
    {
        //end time
        public double EndTime { get; set; }

        //Duration
        public double Duration => EndTime - StartTime;

        //ObjectType
        public override ObjectType ObjectType => ObjectType.ContainerHold;

        public RpContainerLineHoldObject(RpContainerLine parent, double startTime)
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
