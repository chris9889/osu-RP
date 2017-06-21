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

        //show the space that can 
        protected override bool OnMouseMove(InputState state)
        {
            return base.OnMouseMove(state);
        }

        /// <summary>
        /// Detect of anything Drag on the Mouse
        /// Or open a space on the editor for detect
        /// </summary>
        /// <param name="state"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        protected override bool OnMouseUp(InputState state, MouseUpEventArgs args)
        {
            return base.OnMouseUp(state, args);
        }

        /// <summary>
        /// show adding space
        /// </summary>
        /// <param name="dragObject"></param>
        public virtual void ShowAddSpace(DrawableBaseRpObject dragObject)
        {

        }

        /// <summary>
        /// Add Object on ContainableObject
        /// </summary>
        /// <param name="dragObject"></param>
        public virtual void Add(DrawableBaseRpObject dragObject)
        {

        }

        /// <summary>
        /// show removing space
        /// </summary>
        /// <param name="dragObject"></param>
        public virtual void ShowRemoveSpace(DrawableBaseRpObject dragObject)
        {

        }

        /// <summary>
        /// remove Object from ContainableObject
        /// </summary>
        /// <param name="dragObject"></param>
        public virtual void Remove(DrawableBaseRpObject dragObject)
        {

        }
    }
}
