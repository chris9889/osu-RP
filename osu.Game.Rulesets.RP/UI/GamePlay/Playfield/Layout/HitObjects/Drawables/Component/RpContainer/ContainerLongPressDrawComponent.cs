using System.Collections.Generic;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.CommonDwawablePiece;

namespace osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Component.RpContainer
{
    /// <summary>
    ///     負責顯示RP 按壁E時黑色物件
    ///     時間點後會把物件藏起侁E
    ///     這個功能朁E��到 5 月後才朁E��始實佁E
    /// </summary>
    internal class ContainerLongPressDrawComponent : BaseContainerComponent, IChangeableContainerComponent
    {
        /// <summary>
        ///     目前現有物件
        /// </summary>
        public List<DrawableRpLongPress> ListPressObject = new List<DrawableRpLongPress>();

        /// <summary>
        ///     負責劁E�E矩形
        /// </summary>
        public List<RectanglePiece> Rectangle = new List<RectanglePiece>();

        /// <summary>
        /// </summary>
        /// <param name="hitObject"></param>
        public ContainerLongPressDrawComponent(Objects.RpContainer hitObject)
            : base(hitObject)
        {
            Children = Rectangle;
        }

        /// <summary>
        ///     增加物件
        /// </summary>
        public void Add(DrawableRpLongPress drawableHitObject)
        {
            ListPressObject.Add(drawableHitObject);
        }

        /// <summary>
        ///     修改物件高度
        /// </summary>
        /// <param name="newHeight"></param>
        public void ChangeHeight(float newHeight)
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="layerCount"></param>
        protected override void InitialObject(int layerCount = 1)
        {
        }

        /// <summary>
        /// </summary>
        protected override void InitialChild()
        {
            Children = Rectangle;
        }
    }
}
