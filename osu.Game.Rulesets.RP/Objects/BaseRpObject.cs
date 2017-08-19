// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System;
using System.ComponentModel;
using osu.Game.Rulesets.Objects;
using osu.Game.Rulesets.RP.Objects.Attribute;
using osu.Game.Rulesets.RP.Objects.Interface;

namespace osu.Game.Rulesets.RP.Objects
{
    /// <summary>
    ///     all RpObject should inherit it
    /// </summary>
    public abstract class BaseRpObject : HitObject, IHasBPM, IHasVelocity
    {
        //BPM
        public virtual double BPM { get; set; }

        //before startTime
        public float PreemptTime = 1500;

        //List attributer
        public BindingList<BaseRpObjectAttribute> ListAttrobutes = new BindingList<BaseRpObjectAttribute>();

        //Object type
        public virtual ObjectType ObjectType => ObjectType.Undefined;

        //Velocity
        public double Velocity { get; set; }

        //Construct
        protected BaseRpObject(double startTime)
        {
            StartTime = startTime;
            InitialDefaultValue();
        }

        /// <summary>
        ///     初始化預設物件
        /// </summary>
        protected virtual void InitialDefaultValue()
        {
            Velocity = 1;
            BPM = 180;
        }
    }

    //ObjectType
    [Flags]
    public enum ObjectType
    {
        Undefined = 1,
        HitObject = 2,
        Hit = 16,
        Hold = 32,
        ContainerGroup = 4,
        ContainerLine = 8,
        ContainerHold = 64,
        NewCombo = 128
    }

    //Convert
    [Flags]
    public enum Convert
    {
        Original,
        Convert
    }

    //Coop
    [Flags]
    public enum Coop
    {
        LeftOnly,
        RightOnly,
        Both
    }
}
