using System;
using System.Security.Cryptography.X509Certificates;
using osu.Game.Modes.Objects;
using osu.Game.Modes.RP.Beatmaps.OtherBeatmap.HitObjectGegenerator.Parameter;
using osu.Game.Modes.RP.Beatmaps.OtherBeatmap.Parameter;

namespace osu.Game.Modes.RP.Beatmaps.OtherBeatmap.HitObjectGegenerator.PreAnalyse
{
    /// <summary>
    /// to gudge that is a comboing object;
    /// </summary>
    public class AnaylseCombo
    {
        private const double DELTA_COMBO_TIME = 150;

        private double _lastHitObjectTime = 0;

        public bool IsCombo(ComvertParameter single, int i)
        {
            bool result = false;
            if (single.ListRefrenceObject[i].StartTime - _lastHitObjectTime < DELTA_COMBO_TIME)
            {
                result = true;
            }
            else
            {
                result = false;
            }
            _lastHitObjectTime = single.ListRefrenceObject[i].StartTime;
            return result;
        }
    }
}
