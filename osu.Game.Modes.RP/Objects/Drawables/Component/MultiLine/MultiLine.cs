using System.Collections.Generic;
using osu.Framework.Graphics;
using osu.Game.Modes.RP.Objects.Drawables.Component.HitObject;
using osu.Game.Modes.RP.Objects.Drawables.Component.HitObject.Common;
using OpenTK;

namespace osu.Game.Modes.RP.Objects.Drawables.Component.MultiLine
{
    /// <summary>
    /// 用來畫多個物件的連接線使用
    /// </summary>
    class MultiLine : BaseComponent
    {
        //會根據物件順序畫出來
        private List<BaseHitObject> _listHitObject;

        private SliderBody _sliderBody;
        /// <summary>
        /// 
        /// </summary>
        public MultiLine(List<BaseHitObject> listHitObject)
        {
            _listHitObject = listHitObject;
            Children = new Drawable[]
            {
                //Slider身體
                _sliderBody = new SliderBody(listHitObject[0])
                {
                    Position = new Vector2(0,0),
                    PathWidth = listHitObject[0].Scale * 15,
                },
            };

        }

        /// <summary>
        /// 把所有線段畫出來
        /// </summary>
        public void UpdateDrawLine()
        {
            List<Vector2> vector = new List<Vector2>();
            foreach (BaseHitObject baseObject in _listHitObject)
            {

            }

        }
    }
}
