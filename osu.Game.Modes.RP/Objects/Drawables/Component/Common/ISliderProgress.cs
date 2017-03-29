namespace osu.Game.Modes.RP.Objects.Drawables.Component.Common
{
    /// <summary>
    ///     定義物件是屬於 ISliderProgress 類型
    ///     簡單來說是物件在軌跡上面的進度
    /// </summary>
    public interface ISliderProgress
    {
        void UpdateProgress(double startProgress = 0, double endProgress = 1);
    }
}
