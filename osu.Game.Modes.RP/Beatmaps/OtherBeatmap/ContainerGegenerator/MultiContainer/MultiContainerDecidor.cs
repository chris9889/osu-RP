// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE
using System;
using osu.Game.Modes.RP.Beatmaps.OtherBeatmap.ContainerGegenerator.Parameter;
using osu.Game.Modes.RP.Beatmaps.OtherBeatmap.Parameter;

namespace osu.Game.Modes.RP.Beatmaps.OtherBeatmap.ContainerGegenerator.MultiContainer
{
    public class MultiContainerDecidor
    {


        public containerConvertParameter GetParameter(ComvertParameter parameter)
        {
            containerConvertParameter output=new containerConvertParameter();
            output.ContainerNumber = ContainerNumber(parameter);
            output.LayoutNumber = LayoutNumber(output,parameter);
            return output;
        }

        int ContainerNumber(ComvertParameter parameter)
        {
            int refHitObjectNum = parameter.ListRefrenceObject.Count;
            int reruenContainerNumber = 1;
            //如果裡面物件越少，Container越多
            if (refHitObjectNum / 2  < parameter.Difficulty )
            {
                reruenContainerNumber = 2;
            }
            else if (refHitObjectNum  < parameter.Difficulty)
            {
                reruenContainerNumber = 3;
            }

            return reruenContainerNumber;
        }

        int LayoutNumber(containerConvertParameter output,ComvertParameter parameter)
        {
            int containerNumber = output.ContainerNumber;

            return containerNumber;
        }
    }
}