using System;
using osu.Framework.Graphics.Containers;
using osu.Game.Rulesets.RP.Objects.RpEffect;

namespace osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.CommonDwawablePiece
{
    public class HitEffectPiece<T> : EffectPiece<T> where T : Container
    {
        
        /// <summary>
        /// InitialHitEffectPiece
        /// </summary>
        public HitEffectPiece()
        {
            GenerateHitEffect();
        }

        /// <summary>
        /// Generate Hit Effect
        /// </summary>
        public virtual void GenerateHitEffect()
        {
            
        }

        /// <summary>
        /// if call this method 
        /// will generate HitEffect and Play it
        /// </summary>
        public void Hit()
        {
            SetEffect(Effect);
        }
    }
}
