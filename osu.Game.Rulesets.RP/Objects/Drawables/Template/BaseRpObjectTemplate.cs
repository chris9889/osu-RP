// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;
using System.Linq;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.MathUtils;
using osu.Game.Rulesets.RP.Objects.Drawables.Template.Calculator;
using osu.Game.Rulesets.RP.Objects.Drawables.Template.Component;
using osu.Game.Rulesets.RP.Objects.Drawables.Template.Component.Common;
using osu.Game.Rulesets.RP.Objects.Drawables.Template.RpHitObject.Component.Common;
using OpenTK;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Template
{
    /// <summary>
    ///     基本樣板
    ///     會控制物件要擺放位置
    /// </summary>
    public abstract class BaseRpObjectTemplate : Container
    {
        //RpObject
        protected BaseRpObject RpObject;

        //Delay time
        public double DelayTime => 0;

        //Object that need to calculate each frame
        protected List<BaseComponent> Components = new List<BaseComponent>();

        //calculate precentage by time
        protected PathPrecentageCounter PathPrecentageCounter;

        //Load effect
        protected LoadEffect LoadEffect;

        public BaseRpObjectTemplate(BaseRpObject rpObject)
        {
            RpObject = rpObject;
            PathPrecentageCounter = new PathPrecentageCounter(rpObject);

            Children = new Drawable[]
            {
                new Box(),
            };

            //construct
            ConstructComponent();
            //initial all component template will use
            InitialComponent();
            //adding all component into template
            InitialChild();
        }

        //initial all component template will use
        protected virtual void ConstructComponent()
        {
            LoadEffect = new LoadEffect(RpObject);
            Components.Add(LoadEffect);
        }

        //initial all component template will use
        protected virtual void InitialComponent()
        {
            foreach (var single in Components)
            {
                single.Initial();
            }
        }

        //adding all component into template
        protected virtual void InitialChild()
        {
            Children = Components.ToArray();
        }

        //update on each frame
        public virtual void UpdateTemplate(double currentTime)
        {
            updateProgress(currentTime);
        }

        //Fade in
        public virtual void FadeIn(double time = 0)
        {
            foreach (BaseComponent single in Components)
            {
                single.FadeIn(time);
            }
        }

        //fade out
        public virtual void FadeOut(double time = 0)
        {
            foreach (BaseComponent single in Components)
            {
                single.FadeOut(time);
            }
        }

        //update progress
        private void updateProgress(double currentTime)
        {
            //start progress
            var startProgress = PathPrecentageCounter.CalculatePrecentage(RpObject.StartTime - currentTime + DelayTime);
            //end progress
            var endProgress = PathPrecentageCounter.CalculatePrecentage(RpObject.StartTime - currentTime + DelayTime);

            //影響程度
            var CurveEasingTypesPrecentage = 0;

            //修正
            startProgress = MathHelper.Clamp(startProgress, 0, 1);
            endProgress = MathHelper.Clamp(endProgress, 0, 1);
            //fix precentage by EasingTypes
            startProgress = Interpolation.ApplyEasing(Easing.None, startProgress, 0, 1, 1) * CurveEasingTypesPrecentage + startProgress * (1 - CurveEasingTypesPrecentage);
            endProgress = Interpolation.ApplyEasing(Easing.None, endProgress, 0, 1, 1) * CurveEasingTypesPrecentage + endProgress * (1 - CurveEasingTypesPrecentage);

            //update all 
            foreach (IComponentUpdateEachFrame single in Components.Where(n => n is IComponentUpdateEachFrame))
            {
                single.UpdateProgress(startProgress, endProgress);
            }
        }
    }
}
