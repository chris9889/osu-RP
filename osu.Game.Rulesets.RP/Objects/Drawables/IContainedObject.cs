using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables;

namespace osu.Game.Rulesets.RP.Objects.Drawables
{
    /// <summary>
    /// 
    /// </summary>
    public interface IContainedDrawableObject<T> where T : DrawableBaseRpObject
    {
        T ContainedObject { get; set; }
    }
}
