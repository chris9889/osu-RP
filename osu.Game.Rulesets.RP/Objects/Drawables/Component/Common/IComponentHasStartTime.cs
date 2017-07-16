using System;

namespace osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Component.Common
{
    //the component that has start times
    public interface IComponentHasStartTime
    {
        //Set the start Time, and if modified, call this
        void SetStartTime(Double startTime);
    }
}
