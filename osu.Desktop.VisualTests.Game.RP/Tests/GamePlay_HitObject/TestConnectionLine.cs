using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using osu.Desktop.VisualTests.Tests.GamePlay_PlayField;
using osu.Framework.Timing;

namespace osu.Desktop.VisualTests.Tests.GamePlay_HitObject
{
    internal class TestConnectionLine : TestCaseRpPlayField
    {
        public override string Description => "TestConnectionLine";

        public override string Category => TestCaseCategory.GamePlay_HitObject.ToString();

        public override string TestName => @"TestConnectionLine";

        //時間是暫停的
        protected override StopwatchClock RateAdjustClock => new StopwatchClock(true) { Rate = 0 };

        public TestConnectionLine()
        {
            //Create PlayField
            CreatePlayField();
            //create HitableObject ,time is at 0,Object is dragable
            //AddStep("CreateHitObject", addHitJudgement);
        }

        
    }

    
}
