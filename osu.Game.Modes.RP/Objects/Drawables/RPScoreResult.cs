using System.ComponentModel;

namespace osu.Game.Modes.RP.Objects.Drawables
{
    /// <summary>
    /// 一般打擊
    /// </summary>
    public enum RPScoreResult
    {
        [Description(@"Sad")]
        Sad,
        [Description(@"Safe")]
        Safe,
        [Description(@"Fine")]
        Fine,
        [Description(@"Cool")]
        Cool,
        [Description(@"Slider")]
        Slider,
    }
}