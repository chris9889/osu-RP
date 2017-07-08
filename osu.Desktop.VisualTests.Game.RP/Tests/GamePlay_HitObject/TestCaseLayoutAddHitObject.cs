using System.Collections.Generic;
using System.Linq;
using osu.Desktop.VisualTests.TestsScript.Beatmaps.DrawableHitObject;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Timing;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables;
using osu.Game.Rulesets.Taiko.UI;
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

        //clovk speed
        protected StopwatchClock RateAdjustClock => new StopwatchClock(true) { Rate = 0 };

        protected Container PlayfieldContainer;

        protected DrawableRpContainerLine ContainerLine;

        public double GetNowTime()
        {
            //根據list數量去算出下一個物件指定時間
            return ContainerLine.Template.ListContainObject.Count * 0.5;
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Reset()
        {
            base.Reset();

            //Create DrawableRpContainerLine
            createDrawableRpContainerLine();
            //Create DrawableRpHitObject step button
            AddStep("AddHitObject", addNewDrawableRpHitObject);
            //Create delate DrawableRpHitObject step button
            AddStep("DeleteHitObject", deleteDrawableRpHitObject);
        }


        void createDrawableRpContainerLine()
        {
            //create containerline
            ContainerLine = RpHitObjectCreator.CreateDrawableRpContainerLine(new Vector2(0, 300.0f), 0, 2000);
            //InitialPlayField
            PlayfieldContainer = new Container
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                RelativeSizeAxes = Axes.X,
                Height = 1000,
                Clock = new FramedClock(RateAdjustClock),
            };
            //AddObject
            PlayfieldContainer.Add(ContainerLine);
        }

        void addNewDrawableRpHitObject()
        {
            if(GetNowTime() > ContainerLine.HitObject.EndTime)
                return;

            DrawableRpHitObject hitObject = RpHitObjectCreator.CreateDrawableRpHitObject(new Vector2(), GetNowTime());
            ContainerLine.AddObject(hitObject);
        }

        void deleteDrawableRpHitObject()
        {
            int number = ContainerLine.Template.ListContainObject.Count;
            if(number<=0)
                return;

            DrawableBaseRpHitableObject targetRemoveObject = ContainerLine.Template.ListContainObject[number - 1];
            ContainerLine.Template.ListContainObject.Remove(targetRemoveObject);

        }
    }
}
