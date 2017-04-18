// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap.ContainerGegenerator.Parameter;
using osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap.Parameter;

namespace osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap.ContainerGegenerator.MultiContainer
{
    public class MultiContainerDecidor
    {
        public containerConvertParameter GetParameter(ConvertParameter parameter)
        {
            var output = new containerConvertParameter();
            output.ContainerNumber = ContainerNumber(parameter);
            output.LayoutNumber = LayoutNumber(output, parameter);
            return output;
        }

        private int ContainerNumber(ConvertParameter parameter)
        {
            var refHitObjectNum = parameter.ListRefrenceObject.Count;
            var reruenContainerNumber = 1;
            //î@â ó°ñ ï®åèâzè≠ÅCContainerâzëΩ
            if (refHitObjectNum / 2 < parameter.Difficulty)
                reruenContainerNumber = 2;
            else if (refHitObjectNum < parameter.Difficulty)
                reruenContainerNumber = 3;

            return reruenContainerNumber;
        }

        private int LayoutNumber(containerConvertParameter output, ConvertParameter parameter)
        {
            var containerNumber = output.ContainerNumber;

            return containerNumber;
        }
    }
}
