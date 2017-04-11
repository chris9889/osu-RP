using System.Collections.Generic;
using osu.Game.Modes.RP.Objects;
using osu.Game.Modes.RP.UI.GamePlay.Playfield.Layout.CommonDwawablePiece;

namespace osu.Game.Modes.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Component.Container
{
    /// <summary>
    ///     負責顯示RP 按壓 時黑色物件
    ///     時間點後會把物件藏起來
    ///     這個功能會等到 5 月後才會開始實作
    /// </summary>
    internal class ContainerLongPressDrawComponent : BaseContainerComponent, IChangeableContainerComponent
    {
        /// <summary>
        ///     目前現有物件
        /// </summary>
        public List<DrawableRpLongPress> ListPressObject = new List<DrawableRpLongPress>();

        /// <summary>
        ///     負責劃出矩形
        /// </summary>
        public List<RectanglePiece> Rectangle = new List<RectanglePiece>();

        /// <summary>
        /// </summary>
        /// <param name="hitObject"></param>
        public ContainerLongPressDrawComponent(RpContainer hitObject)
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
