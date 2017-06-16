using System;
using osu.Framework.Testing;

namespace osu.Desktop.VisualTests.Ruleset.RP.Tests
{
    /// <summary>
    /// inherit the TestCase and has more function
    /// </summary>
    public class CategoryTestCase : TestCase
    {
        //not sure if really need this
        public virtual string Category => @"undefinde";

        //TestCaseName
        public virtual string TestName => @"Test001";

        //if you want to add this test or not
        public virtual bool AddToTest => true;

        public CategoryTestCase()
        {
            
        }
    }
}
