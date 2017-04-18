using System.Collections.Generic;
using osu.Framework.Graphics;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables;

namespace osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.ContainerBackground
{
    /// <summary>
    ///     負責放置背景
    ///     DrawableContainer
    /// </summary>
    internal class ContainerBackgroundLayout : BaseGamePlayLayout
    {
        /// <summary>
        ///     Container
        /// </summary>
        public List<DrawableRpContainer> _listContainer = new List<DrawableRpContainer>();

        public ContainerBackgroundLayout()
        {
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;
        }

        /// <summary>
        ///     增加Container
        /// </summary>
        public void AddContainer(DrawableRpContainer drawableContainer)
        {
            _listContainer.Add(drawableContainer);
            Add(drawableContainer);
        }

        /// <summary>
        ///     根據時間取得時間點上的Container
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DrawableRpContainer> GetContainerByTime(double time)
        {
            foreach (var container in _listContainer)
                if (container.HitObject.StartTime <= time && container.HitObject.EndTime >= time)
                    yield return container;
        }
    }
}
