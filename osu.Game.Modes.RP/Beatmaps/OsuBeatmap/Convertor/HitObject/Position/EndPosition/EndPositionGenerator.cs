using osu.Game.Modes.RP.Beatmaps.OsuBeatmap.Parameter;
using osu.Game.Modes.RP.Objects;
using OpenTK;

namespace osu.Game.Modes.RP.Beatmaps.OsuBeatmap.Convertor.HitObject.Position.EndPosition
{
    class EndPositionGenerator
    {

        public EndPositionGenerator()
        {

        }

        /// <summary>
        /// 目前設定是同一群combo會從同一個方向出來
        /// </summary>
        Vector2 _direction=new Vector2(0,1);

        /// <summary>
        /// 開始處理物件
        /// </summary>
        /// <param name="input"></param>
        public void Process(HitObjectConvertParameter input)
        {
            foreach (BaseHitObject single in input.ListConvertedParameter)
            {
                ProcessSingeNote(single);
            }
        }

        /// <summary>
        /// 處理單一個打擊物體
        /// </summary>
        void ProcessSingeNote(BaseHitObject singleRPBaseHitObject)
        {
            //產生中間捕間的路徑
            singleRPBaseHitObject.Curve.AntoGenerateEndPosition(_direction);
        }
    }
}
