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
        protected BaseMovePicec ApproachPicec { get; set; }

        //still piece
        protected BaseStillPiece StillPicec { get; set; }

        /// <summary>
        /// </summary>
        /// <param name="rpObjectt"></param>
        protected BaseRpHitableObjectTemplate(BaseRpObject rpObject)
            : base(rpObject)
        {
        }

        //initial all component template will use
        protected override void ConstructComponent()
        {
            LoadEffect = new LoadEffect(RpObject);
            ApproachPicec = new ApproachCircle(RpObject);
            StillPicec = new BaseStillPiece(RpObject);

            Components.Add(LoadEffect);
            Components.Add(ApproachPicec);
            Components.Add(StillPicec);
        }

        //adding all component into template
        protected override void InitialChild()
        {
            Children = Components.ToArray();
        }
    }
}
