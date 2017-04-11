using System;
namespace osu.Game.Modes.RP
{
    //the component that has start times
    public interface IComponentHasStartTime
    {
        //Set the start Time, and if modified, call this
        void SetStartTime(Double startTime);
    }
}
