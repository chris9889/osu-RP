using osu.Game.Modes.Objects.Drawables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using osu.Game.Modes.Judgements;
using osu.Game.Modes.Objects;
using osu.Game.Modes.RP.Objects.Drawables.Component;
using osu.Game.Modes.RP.Objects.Drawables.Component.MultiLine;

namespace osu.Game.Modes.RP.Objects.Drawables
{
    /// <summary>
    /// 用來乘載一次觸發多個物件
    /// </summary>
    class DrawableMultiBaseHitObject : DrawableBaseHitObject
    {
        /// <summary>
        /// 存放所有顯示物件
        /// </summary>
        protected List<DrawableBaseHitObject> _listBaseHitObject=new List<DrawableBaseHitObject>();

        /// <summary>
        /// 用來繪製多重物件
        /// </summary>
        protected MultiLine _multiLine;

        /// <summary>
        /// 建構
        /// </summary>
        /// <param name="hitObject"></param>
        public DrawableMultiBaseHitObject(BaseHitObject hitObject) : base(hitObject)
        {

        }

        /// <summary>
        /// 把顯示物件增加進來
        /// </summary>
        /// <param name="hitObject"></param>
        public void AddObject(DrawableBaseHitObject drawableBaseHitObject)
        {
            _listBaseHitObject.Add(drawableBaseHitObject);
        }

        /// <summary>
        /// 更新
        /// </summary>
        protected override void Update()
        {
            DrawLine();
        }

        /// <summary>
        /// 把連接用的線畫上去
        /// </summary>
        protected void DrawLine()
        {

        }

        /// <summary>
        /// RP判斷
        /// </summary>
        /// <returns></returns>
        protected override RPJudgementInfo CreateJudgementInfo() => new RPJudgementInfo();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        protected override void UpdateState(ArmedState state)
        {
            
        }
    }
}
