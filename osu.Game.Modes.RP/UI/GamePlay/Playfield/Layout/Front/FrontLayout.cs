using System.Collections.Generic;

namespace osu.Game.Modes.RP.UI.GamePlay.Playfield.Layout.Front
{
    /// <summary>
    /// 放置顯示在打擊物件之前的東西
    /// 例如DecisionLine
    /// </summary>
    class FrontLayout : BaseGamePlayLayout
    {
        /// <summary>
        /// 判定線，由
        /// </summary>
        public List<DecisionLine.DecisionLine> _decisionLine;

        public FrontLayout()
        {
            /*
           Children = new[]
           {

               _decisionLine = new DecisionLine.DecisionLine()
               {
                   Anchor = Anchor.Centre,
                   Origin = Anchor.Centre,
                   Alpha = 1
               }
               
            };
            */
        }

        /// <summary>
        /// 自動更新物件
        /// </summary>
        protected override void Update()
        {
            //_decisionLine.Position = PositionManager.GetPointerPosition(Time.Current)-new OpenTK.Vector2(400,300);
        }
    }
}
