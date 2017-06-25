using osu.Framework.Testing;

namespace osu.Desktop.VisualTests.Tests
{
    /// <summary>
    /// inherit the TestCase and has more function
    /// </summary>
    public abstract class CategoryTestCase : TestCase
    {
        //not sure if really need this
        public abstract string Category { get; }//Category

        //TestCaseName
        public abstract string TestName { get; }//test001

        //if you want to add this test or not
        public virtual bool AddToTest => true;

        public CategoryTestCase()
        {
            
        }
    }
}
