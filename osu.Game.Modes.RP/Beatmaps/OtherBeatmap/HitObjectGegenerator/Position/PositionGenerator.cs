// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE
using System;
using System.Collections.Generic;
using osu.Game.Modes.RP.Beatmaps.OtherBeatmap.HitObjectGegenerator.Parameter;
using osu.Game.Modes.RP.Beatmaps.OtherBeatmap.Parameter;
using osu.Game.Modes.RP.Objects;

namespace osu.Game.Modes.RP.Beatmaps.OtherBeatmap.HitObjectGegenerator.Position
{
    public class PositionGenerator
    {
        internal void ProcessPosition(ComvertParameter single)
        {
            //同一群組內的物件位置
            foreach (SingleHitObjectConvertParameter singleTupleHitObjects in single.HitObjectConvertParameter.ListSingleHitObjectConvertParameter)
            {
                if (single.ContainerConvertParameter.LayoutNumber==1) //如果layout只有一個就沒什麼好決定了
                {
                    singleTupleHitObjects.ListBaseHitObject[0].ContainerIndex = 0;
                    singleTupleHitObjects.ListBaseHitObject[0].LayoutIndex = 0;
                }
                else//兩個以上layout
                {
                    for (int i = 0; i < singleTupleHitObjects.ListBaseHitObject.Count; i++)
                    {
                        //目前在哪一個container 裡面的 哪個index裡面
                        int layoutindex = GetRandomValue(singleTupleHitObjects,i) % single.ContainerConvertParameter.LayoutNumber;

                        int remain = layoutindex;

                        //取得container位置和對應的layoutindex
                        for (int j = 0; j < single.ContainerConvertParameter.ContainerNumber; j++)
                        {
                            int layoutNumberinSingleContainer = single.ContainerConvertParameter.ListObjectContainer[i].ContainerLayerList.Count;
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
           
        }

        //產生亂數，數字不要重複優先
        int GetRandomValue(SingleHitObjectConvertParameter singleTupleHitObjects,int index)
        {
            //getTheTotal
            int totalHitObject = singleTupleHitObjects.ListBaseHitObject.Count;
            return (int)singleTupleHitObjects.StartTime+ index* (totalHitObject-1);
        }
    }
}