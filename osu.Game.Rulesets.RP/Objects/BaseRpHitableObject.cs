﻿// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System;
using System.Collections.Generic;
using osu.Game.Audio;
using osu.Game.Rulesets.RP.Input;
using osu.Game.Rulesets.RP.Objects.Drawables.Play;
using osu.Game.Rulesets.RP.Objects.Interface;

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

        //the index of container, will mapping on  HitRanderer
        public int RelativeContainerLineGroupIndex => ParentObject.ParentObject.ID;

        //the layout fo the index ,will mapping on HitRanderer
        public int RelativeContainerLineIndex => ParentObject.ID;

        //set the shape type
        public Shape Shape = Shape.Unknown;

        //can be trigger by what key 
        public abstract bool CanHitBy(RpAction action);

        //get list compare keys
        public abstract List<RpAction> GetListCompareKeys();

        //normal or special
        public Special Special = Special.Normal;

        //sligle or multi
        public RpMultiHit RpMultiHit = RpMultiHit.SingleClick;

        //co-op or not
        public Coop Coop => ParentObject.Coop;

        //if converted for osu!beatmap,set to Convert
        public Convert Convert = Convert.Original;

        public BaseRpHitableObject(RpContainerLine parent, double startTime)
            : base(startTime)
        {
            ParentObject = parent;
            //Need to readd in here
            StartTime = startTime;
            Samples.Add(
                new SampleInfo
                {
                    Bank = "soft",
                    Name = "hitwhistle"
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
                    return 200;
                case RpScoreResult.Fine:
                    return 180;
                case RpScoreResult.Cool:
                    return 160;
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

    //Special
    [Flags]
    public enum Special
    {
        Normal = 0,
        Gold = 1
    }

    //Shape
    [Flags]
    public enum Shape
    {
        Unknown=0, //Unknown
        Hit = 1,//Hit
        Hold = 2, //Hold
        ContainerPress = 4 //containerPress
    }

    //RpMultiHit , not impliment yet
    [Flags]
    public enum RpMultiHit
    {
        SingleClick,
        Multi
    }
}
