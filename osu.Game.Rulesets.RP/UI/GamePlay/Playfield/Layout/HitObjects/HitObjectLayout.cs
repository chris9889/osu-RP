﻿using System.Collections.Generic;
using System.Linq;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.ContainerBackground;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables;

namespace osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects
{
    /// <summary>
    ///     放置打擊物件的layout
    /// </summary>
    internal class HitObjectLayout : BaseGamePlayLayout
    {
        /// <summary>
        /// </summary>
        public ContainerBackgroundLayout ContainerBackgroundLayout;

        /// <summary>
        ///     那些找不到Container 的物件
        /// </summary>
        public List<DrawableBaseRpObject> _listMissingObject = new List<DrawableBaseRpObject>();

        /// <summary>
        ///     曾加速度
        /// </summary>
        /// <param name="drawObject"></param>
        public void AddDrawObject(DrawableBaseRpObject drawObject)
        {
            var drawableHitObject = drawObject as DrawableBaseRpHitableObject;
            AddDrawableBaseHitObject(drawableHitObject);
        }

        /// <summary>
        ///     增加物件進來
        /// </summary>
        /// <param name="drawableHitObject"></param>
        public void AddDrawableBaseHitObject(DrawableBaseRpHitableObject drawableHitObject)
        {
            try
            {
                var containerIndex = drawableHitObject.HitObject.ContainerIndex;
                var layoutIndex = drawableHitObject.HitObject.LayoutIndex;

                //如果是背景按壓物件
                if (drawableHitObject is DrawableRpContainerLineHoldObject)
                    ContainerBackgroundLayout.GetContainerByTime(drawableHitObject.HitObject.StartTime).ElementAt(containerIndex).RpContainerLineGroupTemplate.AddObject(drawableHitObject as DrawableRpContainerLineHoldObject);
                else
                    ContainerBackgroundLayout.GetContainerByTime(drawableHitObject.HitObject.StartTime).ElementAt(containerIndex).RpContainerLineGroupTemplate.ListContainObject[layoutIndex].AddObject(drawableHitObject);
            }
            catch
            {
                _listMissingObject.Add(drawableHitObject);
            }
        }

        /// <summary>
        ///     取得時間點上的所有打擊物件
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DrawableBaseRpObject> GetHitObjectByTime(double time)
        {
            var listContainer = ContainerBackgroundLayout.GetContainerByTime(time);
            if (listContainer.Count() > 0)
                foreach (var container in listContainer)
                {
                    //Hold
                    foreach (var singleHold in container.RpContainerLineGroupTemplate.ContainerLongPressDrawComponent.ListPressObject)
                        if (singleHold.HitObject.StartTime <= time && singleHold.HitObject.EndTime >= time)
                            yield return container;
                    //HitObject
                    foreach (var layoutTemplate in container.RpContainerLineGroupTemplate.ListContainObject)
                    foreach (DrawableRpContainerLineHoldObject hitObject in layoutTemplate.RpContainerLineTemplate.ListContainObject)
                        if (hitObject.HitObject.StartTime <= time && hitObject.HitObject.EndTime >= time)
                            yield return container;
                }
        }
    }
}
