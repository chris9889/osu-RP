using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.MathUtils;
using osu.Game.Rulesets.RP.Objects.Drawables.Template.Calculator;
using osu.Game.Rulesets.RP.Objects.Drawables.Template.Component;
using osu.Game.Rulesets.RP.Objects.Drawables.Template.Interface;
using OpenTK;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Template
{
    public class Template : Container
    {
        //Object that need to calculate each frame
        public List<IComponentBase> Components = new List<IComponentBase>();

        //calculate precentage by time
        protected PathPrecentageCounter PathPrecentageCounter;

        public Template(List<IComponentBase> components)
        {
            Components = components;
            //initial all component template will use
            InitialComponent();
            //adding all component into template
            InitialChild();
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
            Children = Components.Select(s => s as Container).ToArray();
        }

        //update on each frame
        public virtual void UpdateEachFrame(double startTime,double endTime,double currentTime)
        {
            //start progress
            var startProgress = PathPrecentageCounter.CalculatePrecentage(startTime - currentTime);
            //end progress
            var endProgress = PathPrecentageCounter.CalculatePrecentage(endTime - currentTime);

            //set range between 0 to 1
            startProgress = MathHelper.Clamp(startProgress, 0, 1);
            endProgress = MathHelper.Clamp(endProgress, 0, 1);
            
            //update all 
            foreach (IComponentUpdateEachFrame single in Components.Where(n => n is IComponentUpdateEachFrame))
            {
                single.UpdateProgress(startProgress, endProgress);
            }
        }

        //Fade in
        public virtual void FadeIn(double time = 0)
        {
            foreach (IComponentBase single in Components)
            {
                single.FadeIn(time);
            }
        }

        //fade out
        public virtual void FadeOut(double time = 0)
        {
            foreach (IComponentBase single in Components)
            {
                single.FadeOut(time);
            }
        }
    }
}
