namespace osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Component.Common
{
    /// <summary>
    ///     定義物件是屬於 ISliderProgress 類型
    ///     簡單來說是物件在軌跡上面的進度
    /// </summary>
    public interface IComponentSliderProgress
    {
        void UpdateProgress(double startProgress = 0, double endProgress = 1);
    }
}
