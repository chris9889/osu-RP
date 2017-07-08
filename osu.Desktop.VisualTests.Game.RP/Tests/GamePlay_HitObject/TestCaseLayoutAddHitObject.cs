using System.Collections.Generic;
using osu.Desktop.VisualTests.TestsScript.Beatmaps.DrawableHitObject;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables;
using OpenTK;

namespace osu.Desktop.VisualTests.Tests.GamePlay_HitObject
{
    /// <summary>
    /// Test case layout add hit object.
    /// </summary>
    public class TestCaseLayoutAddHitObject : CategoryTestCase
    {
        public override string Category => TestCaseCategory.GamePlay_HitObject.ToString();

        public override string TestName => @"Layout Add RpHitObject";

        public override string Description => @"Testing Layout Add RpHitObject";

        //create object script
        protected RpDrawableHitObjectCreatorScript RpHitObjectCreator = new RpDrawableHitObjectCreatorScript();
        
        //listObject
        protected List<DrawableRpHitObject> ListHitObject=new List<DrawableRpHitObject>();

        protected DrawableRpContainerLine ContainerLine;

        public double GetNowTime()
        {
            //根據list數量去算出下一個物件指定時間
            return ListHitObject.Count * 0.5;
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Reset()
        {
            //TODO : Create DrawableRpContainerLine
            createDrawableRpContainerLine();
            //Create DrawableRpHitObject step button
            AddStep("AddHitObject", addNewDrawableRpHitObject);
            //Create delate DrawableRpHitObject step button
            AddStep("DeleteHitObject", deleteDrawableRpHitObject);
        }


        void createDrawableRpContainerLine()
        {
            ContainerLine = RpHitObjectCreator.CreateDrawableRpContainerLine(new Vector2(0, 300.0f), 0, 2000);
            Add(ContainerLine);
        }

        void addNewDrawableRpHitObject()
        {
            DrawableRpHitObject hitObject = RpHitObjectCreator.CreateDrawableRpHitObject(new Vector2(), GetNowTime());
            ListHitObject.Add(hitObject);
        }

        void deleteDrawableRpHitObject()
        {
            DrawableRpHitObject targetRemoveObject = ContainerLine.Template
        }
    }
}
