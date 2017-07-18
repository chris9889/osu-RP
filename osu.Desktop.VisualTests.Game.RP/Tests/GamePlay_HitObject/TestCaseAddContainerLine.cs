using System.Collections.Generic;
using osu.Desktop.VisualTests.TestsScript.Beatmaps.HitObject;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables;
using OpenTK;

namespace osu.Desktop.VisualTests.Tests.GamePlay_HitObject
{
    /// <summary>
    /// test container add layout
    /// </summary>
    public class TestCaseAddContainerLine : CategoryTestCase
    {
        public override string Category => TestCaseCategory.GamePlay_HitObject.ToString();

        public override string TestName => @"ContainerAddLayer";
        
        public override string Description => @"ContainerAddLayer";

        private RpHitObjectCreatorScript hitObjectCreatorScript;
        private DrawableRpContainerLineGroup containerLineGroup;

        private List<DrawableRpContainerLine> listDrawableRpContainerLine=new List<DrawableRpContainerLine>();

        public TestCaseAddContainerLine()
        {
            hitObjectCreatorScript = new RpHitObjectCreatorScript();
            containerLineGroup=new DrawableRpContainerLineGroup(hitObjectCreatorScript.CreateRpContainerLineGroup(new Vector2(),0,10000));

            AddStep("Add ContainerLine", addLine);
            AddStep("Delete ContainerLine", deleteLine);
        }


        private void addLine()
        {
            DrawableRpContainerLine newContainerLine= new DrawableRpContainerLine(hitObjectCreatorScript.CreateRpContainerLine(new Vector2(), 0, 10000));
            listDrawableRpContainerLine.Add(newContainerLine);

            //List<Drawable> listAdd=new List<Drawable>();
            //listAdd.Add(newContainerLine);
            containerLineGroup.Add(newContainerLine);
        }

        private void deleteLine()
        {
            //TODO : get Last From list
        }

    }
}
