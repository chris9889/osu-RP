// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Game.Rulesets.RP.Objects.Drawables.Template.CommonInterface;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Template.RpContainer
{
    public class EditableRpContainerLineGroupTemplate : RpContainerLineGroupTemplate, IContainerEditableTemplate
    {
        public EditableRpContainerLineGroupTemplate(RpContainerLineGroup rpObject)
            : base(rpObject)
        {
        }
    }
}
