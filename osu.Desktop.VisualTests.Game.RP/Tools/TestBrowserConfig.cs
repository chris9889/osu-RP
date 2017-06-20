namespace osu.Desktop.VisualTests.Ruleset.RP.Tools
{
    public class TestBrowserConfig : ConfigManager<TestBrowserSetting>
    {
        protected override string Filename => @"visualtests.cfg";

        public TestBrowserConfig(Storage storage) : base(storage)
        {
        }
    }

    public enum TestBrowserSetting
    {
        LastTest
    }
}
