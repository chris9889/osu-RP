using osu.Desktop.VisualTests.Tools;

namespace osu.Desktop.VisualTests.Tests.TestingTool
{
    /// <summary>
    /// Test case's unit test
    /// </summary>
    public class TestCaseTestUnitTestTool : CategoryTestCase
    {
        public override string Description => @"Test UnitTest tool's test case(?";
        
        //category
        public override string Category => TestCaseCategory.TestCase.ToString();

        //TestCaseName
        public override string TestName => @"TestUnitTestTool";

        //reset
        public override void Reset()
        {
            base.Reset();

            // Have to construct this here, rather than in the constructor, because
            // we depend on some dependencies to be loaded within OsuGameBase.load().
            //Add testBrowser to view 
            Add(new RpTestBrowser());
        }

    }
}
