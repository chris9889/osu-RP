using System.Collections.Generic;
using osu.Framework.Graphics;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables;

namespace osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.ContainerBackground
{
    /// <summary>
    ///     •‰Ó•ú’u”wŒi
    ///     DrawableContainer
    /// </summary>
    internal class ContainerBackgroundLayer : BaseGamePlayLayer
    {
        /// <summary>
        ///     Container
        /// </summary>
        private List<DrawableRpContainerLineGroup> _listContainer = new List<DrawableRpContainerLineGroup>();

        public List<DrawableRpContainerLineGroup> ContainerGroupList
        {
            get
            {
                return _listContainer;
            }
        }

        public ContainerBackgroundLayer()
        {
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;
        }

        /// <summary>
        ///     ú‰ÁContainer
        /// </summary>
        public void AddContainerLineGroup(DrawableRpContainerLineGroup drawableContainerGroup)
        {
            //ContainerGroup
            _listContainer.Add(drawableContainerGroup);
            Add(drawableContainerGroup);
            
            //ContainerLine
            foreach (var layout in drawableContainerGroup.HitObject.ContainerLayerList)
            {
                DrawableRpContainerLine layoutLine = new DrawableRpContainerLine(layout);
                drawableContainerGroup.Template.AddObject(layoutLine);
                //Add(layoutLine);
            }
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

        public IEnumerable<DrawableRpContainerLineGroup> GetContainerByContainerID(int groupID)
        {
            foreach (var container in _listContainer)
                if (container.HitObject.ID == groupID)
                {
                    yield return container;
                    break;
                }
        }
    }
}
