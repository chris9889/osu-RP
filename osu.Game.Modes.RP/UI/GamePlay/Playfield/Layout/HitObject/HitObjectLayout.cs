using System.Collections.Generic;
using System.Linq;
using osu.Game.Modes.RP.Objects;
using osu.Game.Modes.RP.Objects.Drawables;
using osu.Game.Modes.RP.Objects.Drawables.Template.Container;
using osu.Game.Modes.RP.UI.GamePlay.Playfield.Layout.Background;

namespace osu.Game.Modes.RP.UI.GamePlay.Playfield.Layout.HitObject
{
    /// <summary>
    /// 放置打擊物件的layout
    /// </summary>
    class HitObjectLayout : BaseGamePlayLayout 
    {
        /// <summary>
        /// 
        /// </summary>
        public BackgroundLayout _backgroundLayout;

        /// <summary>
        /// 那些找不到Container 的物件
        /// </summary>
        public List<DrawableBaseRpObject> _listMissingObject = new List<DrawableBaseRpObject>();

        /// <summary>
        /// 曾加速度
        /// </summary>
        /// <param name="drawObject"></param>
        public void AddDrawObject(DrawableBaseRpObject drawObject)
        {
            DrawableBaseHitObject drawableHitObject = drawObject as DrawableBaseHitObject;
            AddDrawableBaseHitObject(drawableHitObject);
        }

        /// <summary>
        /// 增加物件進來
        /// </summary>
        /// <param name="drawableHitObject"></param>
        public void AddDrawableBaseHitObject(DrawableBaseHitObject drawableHitObject)
        {
            try
            {
                int containerIndex = drawableHitObject.HitObject.ContainerIndex;
                int layoutIndex = drawableHitObject.HitObject.LayoutIndex;

                //如果是背景按壓物件
                if (drawableHitObject is DrawableRpLongPress)
                {
                    _backgroundLayout.GetContainerByTime(drawableHitObject.HitObject.StartTime).ElementAt<DrawableContainer>(containerIndex).ContainerTemplate.AddObject(drawableHitObject as DrawableRpLongPress);
                }
                else
                {
                    _backgroundLayout.GetContainerByTime(drawableHitObject.HitObject.StartTime).ElementAt<DrawableContainer>(containerIndex).ContainerTemplate.ListLayoutTemplate[layoutIndex].AddObject(drawableHitObject);
                }
            }
            catch
            {
                _listMissingObject.Add(drawableHitObject);
            }
        }

        /// <summary>
        /// 取得時間點上的所有打擊物件
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DrawableBaseRpObject> GetHitObjectByTime(double time)
        {
            IEnumerable<DrawableContainer> listContainer = _backgroundLayout.GetContainerByTime(time);
            if (listContainer.Count<DrawableContainer>() > 0)
            {
                foreach (DrawableContainer container in listContainer)
                {
                    //Hold
                    foreach (DrawableRpLongPress singleHold in container.ContainerTemplate.ContainerLongPressDrawComponent.ListPressObject)
                    {
                        if (singleHold.HitObject.StartTime <= time && singleHold.HitObject.EndTime >= time)
                            yield return container;
                    }
                    //HitObject
                    foreach (ContainerLayoutTemplate layoutTemplate in container.ContainerTemplate.ListLayoutTemplate)
                    {
                        foreach (DrawableRpLongPress hitObject in layoutTemplate.ListHitObject)
                        {
                            if (hitObject.HitObject.StartTime <= time && hitObject.HitObject.EndTime >= time)
                                yield return container;
                        }
                    }
                }
            }
        }
    }
}
