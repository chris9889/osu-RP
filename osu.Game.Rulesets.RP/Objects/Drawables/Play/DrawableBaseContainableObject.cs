﻿// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;
using osu.Game.Rulesets.RP.Objects.Drawables.Template.RpContainer;
using osu.Game.Rulesets.RP.Scoreing;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Play
{
    /// <summary>
    /// Base object that can acceppt another object drag onto it
    /// </summary>
    public abstract class DrawableBaseContainableObject<T> : DrawableBaseRpObject where T : DrawableBaseRpObject
    {
        //FadeInTime
        public override float FadeInTime => 300;

        //FadeOutTime
        public override float FadeOutTime => 300;

        public new BaseRpContainableTemplate<T> Template
        {
            get { return (BaseRpContainableTemplate<T>)base.Template; }
            set { base.Template = value; }
        }

        public DrawableBaseContainableObject(BaseRpObject hitObject)
            : base(hitObject)
        {
        }

        /// <summary>
        /// Add Object on ContainableObject
        /// </summary>
        /// <param name="dragObject"></param>
        public virtual void AddObject(T dragObject)
        {
            Template.AddObject(dragObject);
        }

        /// <summary>
        /// Add Object on ContainableObject
        /// </summary>
        /// <param name="dragObject"></param>
        public virtual void AddObject(List<T> dragObject)
        {
            //call the tesmplate add function
            Template.AddObject(dragObject);
        }

        /// <summary>
        /// remove Object from ContainableObject
        /// </summary>
        /// <param name="dragObject"></param>
        public virtual void RemoveObject(T dragObject)
        {
            //call the tesmplate remove function
            Template.RemoveObject(dragObject);
        }

        /// <summary>
        /// remove Object from ContainableObject
        /// </summary>
        /// <param name="dragObject"></param>
        public virtual void RemoveObject(List<T> dragObject)
        {
            //call the tesmplate remove function
            Template.RemoveObject(dragObject);
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        protected override RpJudgement CreateJudgement()
        {
            return new RpJudgement();
        }
    }
}
