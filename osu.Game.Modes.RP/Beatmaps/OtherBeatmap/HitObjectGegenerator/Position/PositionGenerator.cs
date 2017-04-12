// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Game.Modes.RP.Beatmaps.OtherBeatmap.HitObjectGegenerator.Parameter;
using osu.Game.Modes.RP.Beatmaps.OtherBeatmap.Parameter;

namespace osu.Game.Modes.RP.Beatmaps.OtherBeatmap.HitObjectGegenerator.Position
{
    public class PositionGenerator
    {
        internal void ProcessPosition(ConvertParameter single)
        {
            //蜷御ｸ鄒､邨・・逧・黄莉ｶ菴咲ｽｮ
            foreach (var singleTupleHitObjects in single.HitObjectConvertParameter.ListSingleHitObjectConvertParameter)
                if (single.ContainerConvertParameter.LayoutNumber == 1) //螯よ棡layout蜿ｪ譛我ｸ蛟句ｰｱ豐剃ｻ鮗ｼ螂ｽ豎ｺ螳壻ｺ・
                {
                    singleTupleHitObjects.ListBaseHitObject[0].ContainerIndex = 0;
                    singleTupleHitObjects.ListBaseHitObject[0].LayoutIndex = 0;
                }
                else //蜈ｩ蛟倶ｻ･荳獲ayout
                {
                    for (var i = 0; i < singleTupleHitObjects.ListBaseHitObject.Count; i++)
                    {
                        //逶ｮ蜑榊惠蜩ｪ荳蛟議ontainer 陬｡髱｢逧・蜩ｪ蛟喫ndex陬｡髱｢
                        var layoutindex = GetRandomValue(singleTupleHitObjects, i) % single.ContainerConvertParameter.LayoutNumber;

                        var remain = layoutindex;

                        //蜿門ｾ幼ontainer菴咲ｽｮ蜥悟ｰ肴㊨逧・ayoutindex
                        for (var j = 0; j < single.ContainerConvertParameter.ContainerNumber; j++)
                        {
                            var layoutNumberinSingleContainer = single.ContainerConvertParameter.ListObjectContainer[i].ContainerLayerList.Count;
                            if (remain < layoutNumberinSingleContainer)
                            {
                                singleTupleHitObjects.ListBaseHitObject[i].ContainerIndex = j;
                                singleTupleHitObjects.ListBaseHitObject[i].LayoutIndex = remain;
                            }
                            remain = remain - j;
                        }
                    }
                }
        }

        //逕｢逕滉ｺよ丙・梧丙蟄嶺ｸ崎ｦ・㍾隍・━蜈・
        private int GetRandomValue(SingleHitObjectConvertParameter singleTupleHitObjects, int index)
        {
            //getTheTotal
            var totalHitObject = singleTupleHitObjects.ListBaseHitObject.Count;
            return (int)singleTupleHitObjects.StartTime + index * (totalHitObject - 1);
        }
    }
}
