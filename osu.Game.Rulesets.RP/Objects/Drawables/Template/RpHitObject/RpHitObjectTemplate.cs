// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Game.Rulesets.RP.Objects.Drawables.Template.RpHitObject.Component.ApproachPiece;
using osu.Game.Rulesets.RP.Objects.Drawables.Template.RpHitObject.Component.Common;
using osu.Game.Rulesets.RP.Objects.Drawables.Template.RpHitObject.Component.StillPiece;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Template.RpHitObject
{
    /// <summary>
    ///     打擊的模板
    /// </summary>
    public class RpHitObjectTemplate : BaseRpHitableObjectTemplate
    {
        public new Objects.RpHitObject RpObject
        {
            get { return (Objects.RpHitObject)base.RpObject; }
        }

        public RpHitObjectTemplate(Objects.RpHitObject rpObject)
            : base(rpObject)
        {
        }

        //initial all component template will use
        protected override void ConstructComponent()
        {
            LoadEffect = new LoadEffect(RpObject);
            ApproachPicec = new ApproachCircle(RpObject);
            StillPicec = new StillHit(RpObject);

            Components.Add(LoadEffect);
            Components.Add(ApproachPicec);
            Components.Add(StillPicec);
        }
    }
}
