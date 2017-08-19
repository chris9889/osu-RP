// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Game.Rulesets.RP.Objects.Drawables.Template.RpHitObject.Component.ApproachPiece;
using osu.Game.Rulesets.RP.Objects.Drawables.Template.RpHitObject.Component.Common;
using osu.Game.Rulesets.RP.Objects.Drawables.Template.RpHitObject.Component.StillPiece;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Template.RpHitObject
{
    //all hitable object's template sohuld inherit this
    public abstract class BaseRpHitableObjectTemplate : BaseRpObjectTemplate
    {
        public new BaseRpHitableObject RpObject
        {
            get { return (BaseRpHitableObject)base.RpObject; }
        }

        //approach piece
        protected ComponentBaseMovePicec ApproachPicec { get; set; }

        //still piece
        protected ComponentBaseStillPiece StillPicec { get; set; }

        /// <summary>
        /// </summary>
        /// <param name="rpObjectt"></param>
        protected BaseRpHitableObjectTemplate(BaseRpHitableObject rpObject)
            : base(rpObject)
        {
        }

        //initial all component template will use
        protected override void ConstructComponent()
        {
            LoadEffect = new LoadEffect(RpObject);
            ApproachPicec = new ApproachCircle(RpObject);
            StillPicec = new ComponentBaseStillPiece(RpObject);

            Components.Add(LoadEffect);
            Components.Add(ApproachPicec);
            Components.Add(StillPicec);
        }

    }
}
