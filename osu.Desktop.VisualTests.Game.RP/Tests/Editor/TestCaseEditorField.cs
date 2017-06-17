using System;
using osu.Framework.Testing;


namespace osu.Desktop.VisualTests.Tests
{
    /// <summary>
    /// show the edit field
    /// </summary>
    public class TestCaseEditorField : CategoryTestCase
    {
        public override string Description => @"Test Editor Field";
        
        public override string Category => TestCaseCategory.Editor.ToString();

        public override string TestName => @"Breadcrumbs";

        public TestCaseEditorField()
        {
        }
    }
}
