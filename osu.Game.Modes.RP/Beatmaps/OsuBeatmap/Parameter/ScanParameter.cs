using OpenTK;

namespace osu.Game.Modes.RP.Beatmaps.OsuBeatmap.Parameter
{
    /// <summary>
    /// 掃描參數
    /// </summary>
    class ScanParameter
    {
        public int NewComboScannerResult;//3 0 0 10 0 0 0 0 0 0 0 0

        public Vector2 PrePositionDiffScannerResult;//前面座標差距

        public Vector2 PostPositionDiffScannerResult;//後面座標差距

        public double BeatPreDiffScannerResult;//和前方差距時間

        public int ComboGroup;//目前是第幾個combo 群組
    }
}
