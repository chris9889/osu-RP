// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;
using System.ComponentModel;
using osu.Game.Rulesets.RP.Objects.Drawables.Play;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Template.RpContainer
{
    public class BaseRpContainableTemplate<T> : BaseRpObjectTemplate where T : DrawableBaseRpObject
    {
        /// <summary>
        ///     放置Layout物件皁E��方
        /// </summary>
        public BindingList<T> ListContainObject = new BindingList<T>();

        public BaseRpContainableTemplate(BaseRpObject rpObject)
            : base(rpObject)
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
            if (ListContainObject.Contains(dragObject))
                ListContainObject.Remove(dragObject);
        }
    }
}
