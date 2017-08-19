// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Framework.Graphics;
using osu.Game.Rulesets.RP.Objects.Drawables.Template.RpHitObject.Component.ApproachPiece;
using osu.Game.Rulesets.RP.Objects.Drawables.Template.RpHitObject.Component.StillPiece;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Template.RpHitObject
{
    //RpContainerLineHoldObjectTemplate
    public class RpContainerLineHoldObjectTemplate : BaseRpHitableObjectTemplate
    {
        public RpContainerLineHoldObjectTemplate(RpContainerLineHoldObject rpObject)
            : base(rpObject)
        {
        }

        //initial all component template will use
        protected override void ConstructComponent()
        {
            ApproachPicec = new ApproachCircle(RpObject);
            StillPicec = new StillContainerLineHold(RpObject);

            ApproachPicec.Initial();
            StillPicec.Initial();

            Components.Add(ApproachPicec);
            Components.Add(StillPicec);
        }

        //adding all component into template
        protected override void InitialChild()
        {
            Children = new Drawable[]
            {
                LoadEffect,
                ApproachPicec,
                StillPicec
            };
        }
    }
}
