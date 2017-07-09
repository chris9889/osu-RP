using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using osu.Game.Rulesets.RP.Objects;

namespace osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Template.RpContainer
{
    public class RpContainableTemplate<T> : RpDrawBaseObjectTemplate where T : DrawableBaseRpObject
    {

        /// <summary>
        ///     放置Layout物件皁E��方
        /// </summary>
        public BindingList<T> ListContainObject = new BindingList<T>();

        public RpContainableTemplate(BaseRpObject hitObject): base(hitObject)
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
            //if(!ListContainObject.Contains(dragObject))
                ListContainObject.Add(dragObject);
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
            ListContainObject.Remove(dragObject);
        }
    }
}
