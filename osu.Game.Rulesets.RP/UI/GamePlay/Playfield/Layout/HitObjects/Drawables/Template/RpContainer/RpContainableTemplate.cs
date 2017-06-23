using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using osu.Game.Rulesets.RP.Objects;

namespace osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Template.RpContainer
{
    public class RpContainableTemplate : RpDrawBaseObjectTemplate
    {
        public RpContainableTemplate(BaseRpObject hitObject): base(hitObject)
        {
        }

        /// <summary>
        /// show adding space
        /// </summary>
        /// <param name="dragObject"></param>
        public virtual void ShowAddSpace(List<DrawableBaseRpObject> dragObject)
        {

        }

        /// <summary>
        /// Add Object on ContainableObject
        /// </summary>
        /// <param name="dragObject"></param>
        public virtual void Add(List<DrawableBaseRpObject> dragObject)
        {

        }

        /// <summary>
        /// show removing space
        /// </summary>
        /// <param name="dragObject"></param>
        public virtual void ShowRemoveSpace(List<DrawableBaseRpObject> dragObject)
        {

        }

        /// <summary>
        /// remove Object from ContainableObject
        /// </summary>
        /// <param name="dragObject"></param>
        public virtual void Remove(List<DrawableBaseRpObject> dragObject)
        {

        }
    }
}
