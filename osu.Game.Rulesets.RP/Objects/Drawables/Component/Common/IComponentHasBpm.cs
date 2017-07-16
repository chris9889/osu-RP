using System;

namespace osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Component.Common
{
    public interface IComponentHasBpm
    {
        //change the bpm
        void ChangeBPM(Double newBpm);
    }
}
