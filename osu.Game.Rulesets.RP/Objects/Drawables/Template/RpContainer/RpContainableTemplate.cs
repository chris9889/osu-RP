using System;
using System.Collections.Generic;
using System.ComponentModel;

using OpenTK;

namespace osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Template.RpContainer
{


    /// <summary>
    /// T : target contained object
    /// Q : who contained this object (Drawable)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="Q"></typeparam>
    public class RpContainableTemplate<T> : RpDrawBaseObjectTemplate where T : DrawableBaseRpObject
    {
        public new DrawableBaseContainableObject<T> DrawablehitObject
        {
            get { return (DrawableBaseContainableObject<T>)base.DrawablehitObject; }
        }

        /// <summary>
        ///     放置Layout物件皁E��方
        /// </summary>
        public BindingList<T> ListContainObject = new BindingList<T>();



        public RpContainableTemplate(DrawableBaseContainableObject<T> drawablehitObject): base(drawablehitObject)
        {

        }

        /// <summary>
        /// show adding space
        /// </summary>
        /// <param name="dragObject"></param>
        public virtual void ShowAddSpace(List<T> dragObject)
        {

        }


        /// <summary>
        /// show removing space
        /// </summary>
        /// <param name="dragObject"></param>
        public virtual void ShowRemoveSpace(List<T> dragObject)
        {

        }

        /// <summary>
        /// Add Object on ContainableObject
        /// </summary>
        /// <param name="dragObject"></param>
        public virtual void AddObject(List<T> dragObject)
        {
            foreach (T single in dragObject)
            {
                AddObject(single);
            }
        }


        public virtual void AddObject(T dragObject)
        {
            if (!ListContainObject.Contains(dragObject))
            {
                ListContainObject.Add(dragObject);
                //dragObject.ContainedObject = this.DrawablehitObject;
            }
            

        }

        /// <summary>
        /// remove Object from ContainableObject
        /// </summary>
        /// <param name="dragObject"></param>
        public virtual void RemoveObject(List<T> dragObject)
        {
            foreach (T single in dragObject)
            {
                RemoveObject(single);
            }
        }

        public virtual void RemoveObject(T dragObject)
        {
            if (IsContain(dragObject))
                ListContainObject.Remove(dragObject);
        }

        public virtual Vector2 GetTargetObjectPosition(T dragObject)
        {
            return new Vector2(1,1);
        }

        public virtual float GetTargetObjectScale(T dragObject)
        {
            return 1;
        }

        public virtual bool IsContain(T dragObject)
        {
            return ListContainObject.Contains(dragObject);
        }
    }
}
