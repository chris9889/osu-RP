﻿using osu.Framework.Graphics.Containers;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables;

namespace osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.Judgement.HitExplosion.HitEffectTemplate
{
    /// <summary>
    ///     打擊特效
    /// </summary>
    internal class BaseHitEffectTemplate : Container
    {
        /// <summary>
        ///     目前結果
        /// </summary>
        protected RpScoreResult RPScoreResult = RpScoreResult.Sad;

        //開始特效
        public virtual void StartEffect()
        {
        }
    }
}
