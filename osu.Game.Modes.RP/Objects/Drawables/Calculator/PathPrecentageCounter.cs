namespace osu.Game.Modes.RP.Objects.Drawables.Calculator
{
    /// <summary>
    /// 用來計算目前在曲線裡面的百分比
    /// </summary>
    class PathPrecentageCounter
    {
        BaseRpObject _baseHitObject;

        public double SpeedMultiple = 1.5f;

        public PathPrecentageCounter(BaseRpObject baseHitObject)
        {
            _baseHitObject = baseHitObject;
        }

        /// <summary>
        /// 用來計算目前百分比
        /// 越接近目標(時間越大) 百分比越小
        /// 這邊是丟入到頂點所需要的剩餘時間
        /// </summary>
        /// <returns></returns>
        public double CalculatePrecentage(double remainToIndexPointerTime)
        {
            double precentage = 0;
            double totalLehgth = _baseHitObject.Curve.PathLength;
            precentage = (_baseHitObject.Velocity * remainToIndexPointerTime) / totalLehgth * SpeedMultiple;
            return precentage;
        }
    }
}
