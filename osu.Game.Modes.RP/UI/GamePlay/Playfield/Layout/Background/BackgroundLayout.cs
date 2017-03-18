using System.Collections.Generic;
using osu.Framework.Graphics;
using osu.Game.Modes.RP.Objects;
using osu.Game.Modes.RP.Objects.Drawables;

namespace osu.Game.Modes.RP.UI.GamePlay.Playfield.Layout.Background
{
    /// <summary>
    /// 負責放置背景
    /// DrawableContainer
    /// </summary>
    class BackgroundLayout : BaseGamePlayLayout
    {
        /// <summary>
        /// Container
        /// </summary>
        public List<DrawableContainer> _listContainer = new List<DrawableContainer>();

        public BackgroundLayout()
        {
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;
        }

        /// <summary>
        /// 增加Container
        /// </summary>
        public void AddContainer(DrawableContainer drawableContainer)
        {
            _listContainer.Add(drawableContainer);
            Add(drawableContainer);
        }

        /// <summary>
        /// 根據時間取得時間點上的Container
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DrawableContainer> GetContainerByTime(double time)
        {
            foreach (DrawableContainer container in _listContainer)
            {
                if (container.HitObject.StartTime <= time && container.HitObject.EndTime >= time)
                    yield return container;
            }
        }
    }
}
