using osu.Game.Modes.RP.Beatmaps.OsuBeatmap.Parameter;
using osu.Game.Modes.RP.Objects;

namespace osu.Game.Modes.RP.Beatmaps.OtherBeatmap.HitObjectGegenerator.ObjectMovingPath.PathPosition
{
    /// <summary>
    /// 產生RP路徑
    /// </summary>
    class RpPathGenerator
    {
       
        /// <summary>
        /// 建構
        /// </summary>
        public RpPathGenerator()
        {

        }

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
            singleRPBaseHitObject.Curve.GenrtateMiddlePath();
        }

    }
}
