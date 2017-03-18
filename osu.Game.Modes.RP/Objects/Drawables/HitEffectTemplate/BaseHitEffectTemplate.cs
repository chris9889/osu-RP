using osu.Framework.Graphics.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osu.Game.Modes.RP.Objects.Drawables.HitEffectTemplate
{
    /// <summary>
    /// 打擊特效
    /// </summary>
    class BaseHitEffectTemplate : Container
    {
        /// <summary>
        /// 目前結果
        /// </summary>
        protected RPScoreResult RPScoreResult = RPScoreResult.Sad;

        public BaseHitEffectTemplate()
        {

        }

        //開始特效
        public virtual void StartEffect()
        {

        }
    }
}
