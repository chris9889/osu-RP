using osu.Game.Modes.RP.Beatmaps.OtherBeatmap.HitObjectGegenerator.Parameter;
using OpenTK;

namespace osu.Game.Modes.RP.Beatmaps.OtherBeatmap.HitObjectGegenerator.ObjectMovingPath.EndPosition
{
    internal class EndPositionGenerator
    {
        /// <summary>
        ///     目前設定是同一群combo會從同一個方向出來
        /// </summary>
        private readonly Vector2 _direction = new Vector2(0, 1);

        /// <summary>
        ///     開始處理物件
        /// </summary>
        /// <param name="input"></param>
        public void Process(HitObjectConvertParameter input)
        {
            foreach (var single in input.ListSingleHitObjectConvertParameter)
                processSingeNote(single);
        }

        /// <summary>
        ///     處理單一個打擊物體
        /// </summary>
        private void processSingeNote(SingleHitObjectConvertParameter singleRpBaseHitObject)
        {
            //產生中間捕間的路徑
            singleRpBaseHitObject.ListBaseHitObject[0].Curve.AntoGenerateEndPosition(_direction);
        }
    }
}
