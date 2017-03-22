using System.Collections.Generic;
using osu.Game.Modes.RP.Beatmaps.OtherBeatmap.HitObjectGegenerator.Generator;
using osu.Game.Modes.RP.Beatmaps.OtherBeatmap.HitObjectGegenerator.Position;
using osu.Game.Modes.RP.Beatmaps.OtherBeatmap.HitObjectGegenerator.PreAnalyse;
using osu.Game.Modes.RP.Beatmaps.OtherBeatmap.HitObjectGegenerator.Type;
using osu.Game.Modes.RP.Beatmaps.OtherBeatmap.Parameter;

namespace osu.Game.Modes.RP.Beatmaps.OtherBeatmap.HitObjectGegenerator
{
    public class HitObjectProcessor
    {

        PreAnalyseHitObject PreAnalyseHitObject = new PreAnalyseHitObject();

        HitObjectGenerator HitObjectGenerator=new HitObjectGenerator();

        TypeCalculator TypeCalculator = new TypeCalculator();

        PositionGenerator PositionGenerator=new PositionGenerator();

        public List<ComvertParameter> Convert(List<ComvertParameter> output)
        {
            foreach (ComvertParameter single in output)
            {
                //preAnaylse
                single.HitObjectConvertParameter = PreAnalyseHitObject.Analyse(single);
                //single multi, it will generator real ob object
                single.ListBaseHitObject = HitObjectGenerator.GeneratorListHitObject(single);
                //type generator
                TypeCalculator.ProcessType(single);
                //position genertator : will decide which container and layout whould allocate
                PositionGenerator.ProcessPosition(single);
                //return
            }
            return output;
        }
    }
}
