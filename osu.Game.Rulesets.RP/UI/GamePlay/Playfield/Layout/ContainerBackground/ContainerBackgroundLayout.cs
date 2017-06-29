using System.Collections.Generic;
using osu.Framework.Graphics;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables;

namespace osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.ContainerBackground
{
    /// <summary>
    ///     •‰Ó•ú’u”wŒi
    ///     DrawableContainer
    /// </summary>
    internal class ContainerBackgroundLayout : BaseGamePlayLayout
    {
        /// <summary>
        ///     Container
        /// </summary>
        public List<DrawableRpContainerLineGroup> _listContainer = new List<DrawableRpContainerLineGroup>();

        public ContainerBackgroundLayout()
        {
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;
        }

        /// <summary>
        ///     ú‰ÁContainer
        /// </summary>
        public void AddContainer(DrawableRpContainerLineGroup drawableContainer)
        {
            _listContainer.Add(drawableContainer);
            Add(drawableContainer);
            //foreach (var layout in drawableContainer.RpHitObject.ContainerLayerList)
            //{
            //   // Add(new DrawableRpContainerLine(layout));
            //}
        }

        /// <summary>
        ///     ªŸŠÔæ“¾ŠÔêyã“IContainer
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DrawableRpContainerLineGroup> GetContainerByTime(double time)
        {
            foreach (var container in _listContainer)
                if (container.HitObject.StartTime <= time && container.HitObject.EndTime >= time)
                    yield return container;
        }
    }
}
