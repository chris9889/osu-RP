using System;
using osu.Framework.Graphics.Containers;
using osu.Game.Rulesets.RP.Objects.RpEffect;


namespace osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.CommonDwawablePiece
{
    /// <summary>
    /// this class will beat
    /// </summary>
    public class BpmEffectPiece<T> : HitEffectPiece<T> where T : Container
    {
        Double BPM;

        public BpmEffectPiece()
        {
            
        }

        public void SetBPM(double bpm)
        {
            BPM = bpm;

        }

        public override void GenerateHitEffect()
        {

            Effect.Loop = true;
        }

    }
}
