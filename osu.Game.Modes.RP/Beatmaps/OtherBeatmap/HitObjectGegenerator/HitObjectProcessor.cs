using System.Collections.Generic;
using osu.Game.Modes.RP.Beatmaps.OtherBeatmap.HitObjectGegenerator.Generator;
using osu.Game.Modes.RP.Beatmaps.OtherBeatmap.HitObjectGegenerator.Position;
using osu.Game.Modes.RP.Beatmaps.OtherBeatmap.HitObjectGegenerator.PostProcess;
using osu.Game.Modes.RP.Beatmaps.OtherBeatmap.HitObjectGegenerator.PreAnalyse;
using osu.Game.Modes.RP.Beatmaps.OtherBeatmap.HitObjectGegenerator.Type;
using osu.Game.Modes.RP.Beatmaps.OtherBeatmap.Parameter;

namespace osu.Game.Modes.RP.Beatmaps.OtherBeatmap.HitObjectGegenerator
{
    public class HitObjectProcessor
    {
        private readonly PreAnalyseHitObject preAnalyseHitObject = new PreAnalyseHitObject();

        private readonly HitObjectGenerator hitObjectGenerator = new HitObjectGenerator();

        private readonly TypeCalculator typeCalculator = new TypeCalculator();

        private readonly PositionGenerator positionGenerator = new PositionGenerator();

        HitObjectPostProcessor hitObjectPostProcessor=new HitObjectPostProcessor();

        public List<ComvertParameter> Convert(List<ComvertParameter> output)
        {
            foreach (var single in output)
            {
                //preAnaylse
                single.HitObjectConvertParameter = preAnalyseHitObject.Analyse(single);
                //single multi, it will generator real ob object
                single.HitObjectConvertParameter.ListSingleHitObjectConvertParameter = hitObjectGenerator.GeneratorListHitObject(single);
                //type generator
                typeCalculator.ProcessType(single);
                //position genertator : will decide which container and layout whould allocate
                positionGenerator.ProcessPosition(single);
                //return
                hitObjectPostProcessor.PostProcess(single);
            }
            return output;
        }
    }
}
