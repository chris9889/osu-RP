using System.Collections.Generic;
namespace osu.Game.Modes.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Component.CommonInterface
{
    /// <summary>
    ///     the object can move with bpm
    /// </summary>
    public interface IComponentWavable
    {
        //wave with BPM and set the scale?
        void Wave(WaveScale scale);

        //reginst all the wave time
        void ListWabeTime(List<double> listTime);

        //if hitObject hitted call this
        void OnHitObject();

        void OnHitSlider();

        //if releast the slider ,call this
        void OnStopHitSlider();


    }

    public enum WaveScale
    {
        Large,
        Medium,
        small
    }
}
