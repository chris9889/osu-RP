using System;
using osu.Game.Rulesets.RP.Objects.RpEffect;

namespace osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Component.Common
{
    /// <summary>
    /// not sure this interface will be replace directly by EffectPiece class
    /// </summary>
    public interface IComponentAcceptEffect
    {
        /// <summary>
        /// if receive this effect 
        /// just pass RpEffect to the class that inherit EffectPiece
        /// </summary>
        /// <returns>The effect.</returns>
        /// <param name="effect">Effect.</param>
        void Effect(RpEffect effect);
    }
}
