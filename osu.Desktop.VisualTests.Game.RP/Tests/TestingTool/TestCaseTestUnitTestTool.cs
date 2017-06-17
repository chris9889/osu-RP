using System;
using osu.Desktop.VisualTests.Ruleset.RP;

namespace osu.Desktop.VisualTests.Tests
{
    /// <summary>
    /// Test case's unit test
    /// </summary>
    public class TestCaseTestUnitTestTool : CategoryTestCase
    {
        public override string Description => @"Test UnitTest tool's test case";
        
        //not sure if really need this
        public virtual string Category => TestCaseCategory.TestCase.ToString();

        //TestCaseName
        public virtual string TestName => @"TestUnitTestTool";

        public override void Reset()
        {
            base.Reset();

            // Have to construct this here, rather than in the constructor, because
            // we depend on some dependencies to be loaded within OsuGameBase.load().
            Add(new RpTestBrowser());
        }

    }
}
