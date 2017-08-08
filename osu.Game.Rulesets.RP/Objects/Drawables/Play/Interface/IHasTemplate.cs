using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using osu.Game.Rulesets.RP.Objects.Drawables.Template;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Play.Interface
{
    public interface IHasTemplate<T> where T : BaseRpObjectTemplate
    {
        T Template { get; }
    }
}
