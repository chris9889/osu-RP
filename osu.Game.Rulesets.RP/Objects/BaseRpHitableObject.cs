// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Game.Audio;
using osu.Game.Rulesets.RP.Objects.Drawables.Play;
using osu.Game.Rulesets.RP.Objects.Types;

namespace osu.Game.Rulesets.RP.Objects
{
    /// <summary>
    ///     all the hittable object will inherit it
    /// </summary>
    public abstract class BaseRpHitableObject : BaseRpObject, IHasParent<RpContainerLine>, IHasCoop
    {
        //parent object
        public RpContainerLine ParentObject { get; set; }

        //relative to parent object time
        public double RelativeToParentStartTime { get; set; }

        //StartTime = RelativeToParentStartTime + ParentObject.StartTime
        public override double StartTime //{ get; set; }
        {
            get
            {
                if (ParentObject == null)
                    return RelativeToParentStartTime;
                return ParentObject.StartTime + RelativeToParentStartTime;
            }
            set
            {
                if (ParentObject == null)
                {
                    RelativeToParentStartTime = value;
                }
                else
                {
                    RelativeToParentStartTime = value - ParentObject.StartTime;
                }
            }
        }

        //Hit50
        public double Hit50 = 200;

        //Hit100
        public double Hit100 = 180;

        //Hit300
        public double Hit300 = 160;

        //the index of container, will mapping on  HitRanderer
        public int RelativeContainerLineGroupIndex => ParentObject.ParentObject.ID;

        //the layout fo the index ,will mapping on HitRanderer
        public int RelativeContainerLineIndex => ParentObject.ID;

        //set the shape type
        public RpBaseHitObjectType.Shape Shape = RpBaseHitObjectType.Shape.Right;

        //normal or special
        public RpBaseObjectType.Special Special = RpBaseObjectType.Special.Normal;

        //if converted for osu!beatmap,set to auto
        public RpBaseObjectType.CurveGenerate CurveGenerate = RpBaseObjectType.CurveGenerate.Auto;

        //sligle or multi
        public RpBaseHitObjectType.Multi Multi = RpBaseHitObjectType.Multi.SingleClick;

        //co-op or not
        public RpBaseHitObjectType.Coop Coop => ParentObject.Coop;

        //if converted for osu!beatmap,set to Convert
        public RpBaseObjectType.Convert Convert = RpBaseObjectType.Convert.Original;

        public BaseRpHitableObject(RpContainerLine parent, double startTime)
            : base(startTime)
        {
            ParentObject = parent;
            //Need to readd in here
            StartTime = startTime;
            Samples.Add(
                new SampleInfo
                {
                    Bank = "whistle",
                    Name = "soft"
                }
            );
        }

        protected override void InitialDefaultValue()
        {
            base.InitialDefaultValue();
        }

        /// <summary>
        ///     討延遲時間用
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public double HitWindowFor(RpScoreResult result)
        {
            switch (result)
            {
                default:
                    return 300;
                case RpScoreResult.Safe:
                    return 150;
                case RpScoreResult.Fine:
                    return 80;
                case RpScoreResult.Cool:
                    return 30;
            }
        }

        public RpScoreResult ScoreResultForOffset(double offset)
        {
            if (offset < HitWindowFor(RpScoreResult.Cool))
                return RpScoreResult.Cool;
            if (offset < HitWindowFor(RpScoreResult.Fine))
                return RpScoreResult.Fine;
            if (offset < HitWindowFor(RpScoreResult.Safe))
                return RpScoreResult.Safe;
            return RpScoreResult.Sad;
        }
    }
}
