using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using osu.Framework.Input;
using osu.Game.Rulesets.RP.Objects;

namespace osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables
{
    /// <summary>
    /// Base object that can acceppt another object drag onto it
    /// </summary>
    public class DrawableBaseContainableObject : DrawableBaseRpObject
    {
        public virtual List<DrawableBaseRpObject> ListAcceptableObject => null;

        public DrawableBaseContainableObject(BaseRpObject hitObject): base(hitObject)
        {

        }

        /// <summary>
        /// Add Object on ContainableObject
        /// </summary>
        /// <param name="dragObject"></param>
        public virtual void Add(List<DrawableBaseRpObject> dragObject)
        {
            //call the tesmplate add function
        }

        /// <summary>
        /// remove Object from ContainableObject
        /// </summary>
        /// <param name="dragObject"></param>
        public virtual void Remove(List<DrawableBaseRpObject> dragObject)
        {
            //call the tesmplate remove function
        }
    }
}
