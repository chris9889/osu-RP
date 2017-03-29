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
        private readonly PreAnalyseHitObject PreAnalyseHitObject = new PreAnalyseHitObject();

        private readonly HitObjectGenerator HitObjectGenerator = new HitObjectGenerator();

        private readonly TypeCalculator TypeCalculator = new TypeCalculator();

        private readonly PositionGenerator PositionGenerator = new PositionGenerator();

        public List<ComvertParameter> Convert(List<ComvertParameter> output)
        {
            foreach (var single in output)
            {
                //preAnaylse
                single.HitObjectConvertParameter = PreAnalyseHitObject.Analyse(single);
                //single multi, it will generator real ob object
                single.HitObjectConvertParameter.ListSingleHitObjectConvertParameter = HitObjectGenerator.GeneratorListHitObject(single);
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
