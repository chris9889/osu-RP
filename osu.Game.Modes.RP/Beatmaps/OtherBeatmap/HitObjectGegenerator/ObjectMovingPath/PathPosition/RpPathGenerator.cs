using osu.Game.Modes.RP.Beatmaps.OtherBeatmap.HitObjectGegenerator.Parameter;

namespace osu.Game.Modes.RP.Beatmaps.OtherBeatmap.HitObjectGegenerator.ObjectMovingPath.PathPosition
{
    /// <summary>
    ///     產生RP路徑
    /// </summary>
    internal class RpPathGenerator
    {
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
            singleRpBaseHitObject.ListBaseHitObject[0].Curve.GenrtateMiddlePath();
        }
    }
}
