using osu.Framework.Graphics.Containers;

namespace osu.Game.Modes.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.HitEffectTemplate
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
