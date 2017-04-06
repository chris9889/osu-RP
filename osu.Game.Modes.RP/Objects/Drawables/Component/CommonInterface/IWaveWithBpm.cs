using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osu.Game.Modes.RP.Objects.Drawables.Component.CommonInterface
{
    /// <summary>
    /// the object can move with bpm
    /// </summary>
    public interface IWaveWithBpm
    {
        void Wave(WaveScale scale);
    }

    public enum WaveScale
    {
        Large,
        Medium,
        small
    }
}
