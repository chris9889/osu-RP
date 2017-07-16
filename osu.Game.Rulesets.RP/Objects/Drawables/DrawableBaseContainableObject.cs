using System;
using System.Collections.Generic;
using System.Linq;
using osu.Game.Rulesets.RP.Objects;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Template.RpContainer;

namespace osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables
{
    /// <summary>
    /// Base object that can acceppt another object drag onto it
    /// </summary>
    public class DrawableBaseContainableObject<T> : DrawableBaseRpObject where T : DrawableBaseRpObject
    {
        public new RpContainableTemplate<T> Template
        {
            get { return (RpContainableTemplate<T>)base.Template; }
            set { base.Template = value; }
        }

        public DrawableBaseContainableObject(BaseRpObject hitObject): base(hitObject)
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
        
    }
}
