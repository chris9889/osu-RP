﻿using System.Collections.Generic;
using System.Linq;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.ContainerBackground;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables;

namespace osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects
{
    /// <summary>
    ///     
    /// </summary>
    public class HitObjectLayer : BaseGamePlayLayer
    {
        /// <summary>
        /// </summary>
        public ContainerBackgroundLayer ContainerBackgroundLayer;

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

            var containerIndex = drawableHitObject.HitObject.ContainerIndex;
            var layoutIndex = drawableHitObject.HitObject.LayoutIndex;

            //如果是背景按壓物件
            //if (drawableHitObject is DrawableRpContainerLineHoldObject)
            //     ContainerBackgroundLayer.GetContainerByTime(((DrawableBaseRpObject)drawableHitObject).HitObject.StartTime).ElementAt(containerIndex).Template.AddObject(drawableHitObject as DrawableRpContainerLineHoldObject);
            //else
            //    ContainerBackgroundLayer.GetContainerByTime(((DrawableBaseRpObject)drawableHitObject).HitObject.StartTime).ElementAt(containerIndex).Template.ListContainObject[layoutIndex].AddObject(drawableHitObject);

            double time = ((DrawableBaseRpObject)drawableHitObject).HitObject.StartTime;
            DrawableRpContainerLineGroup lineGroup = ContainerBackgroundLayer.GetContainerByTime(time).ElementAt(containerIndex);
            DrawableRpContainerLine line = lineGroup.Template.ListContainObject[layoutIndex];
            line.AddObject(drawableHitObject);

            try
            {
              
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
            var listContainer = ContainerBackgroundLayer.GetContainerByTime(time);
            if (listContainer.Any())
                foreach (var container in listContainer)
                {
                    //Hold
                    foreach (var singleHold in container.Template.ContainerLongPressDrawComponent.ListPressObject)
                        if (((DrawableBaseRpObject)singleHold).HitObject.StartTime <= time && ((DrawableBaseRpObject)singleHold).HitObject.EndTime >= time)
                            yield return container;
                    //RpHitObject
                    foreach (var layoutTemplate in container.Template.ListContainObject)
                    foreach (DrawableRpContainerLineHoldObject hitObject in layoutTemplate.Template.ListContainObject)
                        if (((DrawableBaseRpObject)hitObject).HitObject.StartTime <= time && ((DrawableBaseRpObject)hitObject).HitObject.EndTime >= time)
                            yield return container;
                }
        }
    }
}