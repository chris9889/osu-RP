using System.Collections.Generic;
using osu.Game.Modes.RP.Beatmaps.OtherBeatmap.Parameter;
using osu.Game.Modes.RP.Objects;
using osu.Game.Modes.RP.Objects.type;

namespace osu.Game.Modes.RP.Beatmaps.OtherBeatmap.ContainerGegenerator.Coop
{
    internal class CoopDecider
    {
        private readonly int _coopNumber = 10;

        /// <summary>
        ///     DecideCoop
        /// </summary>
        /// <param name="single"></param>
        internal void DecideCoop(ConvertParameter single)
        {
            var layoutNumber = 0;
            //Get the number of layoutNumber;
            foreach (var sligleContainer in single.ContainerConvertParameter.ListObjectContainer)
                layoutNumber = layoutNumber + sligleContainer.ContainerLayerList.Count;

            //Get how many number of the HitObject
            var refCount = single.ListRefrenceObject.Count;

            //decide use coop or not
            if (refCount < _coopNumber)
                GenerateCoop(single);
            else
                GenerateNonCoop(single);
        }

        /// <summary>
        ///     all the layout will have non-coop
        /// </summary>
        private void GenerateNonCoop(ConvertParameter single)
        {
            foreach (var sligleContainer in single.ContainerConvertParameter.ListObjectContainer)
            foreach (var layout in sligleContainer.ContainerLayerList)
                layout.Coop = RpBaseHitObjectType.Coop.Both;
        }

        /// <summary>
        ///     Depend on how many layout and decide the coop
        /// </summary>
        private void GenerateCoop(ConvertParameter single)
        {
            var listLayout = new List<RpContainerLayout>();
            foreach (var sligleContainer in single.ContainerConvertParameter.ListObjectContainer)
                listLayout.AddRange(sligleContainer.ContainerLayerList);

            var additionRandomValue = GetRandomValue(single);
            for (var i = 0; i < listLayout.Count; i++)
                if ((i + additionRandomValue) % 2 == 0)
                    listLayout[i].Coop = RpBaseHitObjectType.Coop.LeftOnly;
                else
                    listLayout[i].Coop = RpBaseHitObjectType.Coop.RightOnly;
        }

        /// <summary>
        ///     generate readom value by something
        /// </summary>
        /// <returns></returns>
        private int GetRandomValue(ConvertParameter single)
        {
            return single.ListRefrenceObject.Count + single.ContainerConvertParameter.ListObjectContainer.Count + 1;
        }
    }
}
