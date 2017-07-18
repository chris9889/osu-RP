using System.ComponentModel;

namespace osu.Game.Modes.RP.Objects.Drawables
{
    /// <summary>
    /// 如果遇到combo的情況
    /// 用不到，但目前先不要移除
    /// </summary>
    public enum RPComboResult
    {
        [Description(@"")]
        None,
        [Description(@"Good")]
        Good,
        [Description(@"Amazing")]
        Perfect
    }
}