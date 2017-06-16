using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using osu.Framework.Allocation;
using osu.Framework.Configuration;
using osu.Framework.Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Platform;
using osu.Framework.Screens;
using osu.Framework.Testing.Drawables;
using OpenTK;
using OpenTK.Graphics;
using osu.Framework.Testing;
using osu.Desktop.VisualTests.Ruleset.RP.Tests;


namespace osu.Desktop.VisualTests.Ruleset.RP
{
    /// <summary>
    /// this test browser can sorted by class category
    /// </summary>
    public class RpTestBrowser : Screen
    {
        
        public CategoryTestCase CurrentTest { get; private set; }

        private FillFlowContainer<TestCaseCategoryButton> leftFlowContainer;
        private FillFlowContainer<TestCaseButton> secondaryFlowContainer;

        private Container testContentContainer;
        private Container compilingNotice;

        //change it into dictionary
        public readonly Dictionary<String,CategoryTestCase> Tests = new Dictionary<String,CategoryTestCase>();

        private ConfigManager<TestBrowserSetting> config;

        private DynamicClassCompiler<CategoryTestCase> backgroundCompiler;

        public RpTestBrowser()
        {
            //we want to build the lists here because we're interested in the assembly we were *created* on.
            Assembly asm = Assembly.GetCallingAssembly();
            //get all class that is inherit from CategoryTestCase
            foreach (Type type in asm.GetLoadableTypes().Where(t => t.IsSubclassOf(typeof(CategoryTestCase)) && !t.IsAbstract))
            {
                CategoryTestCase singleTestCase = (CategoryTestCase)Activator.CreateInstance(type);
                //if this class is need to test
                if(singleTestCase.AddToTest)
                {
                    //Category it
                    Tests.Add(singleTestCase.Category,singleTestCase);
                }
                   
            }

            //Tests.Sort((a, b) => string.Compare(a.Name, b.Name, StringComparison.Ordinal));
        }

        [BackgroundDependencyLoader]
        private void load(Storage storage)
        {
            config = new TestBrowserConfig(storage);

            Children = new Drawable[]
            {
                //Main category
                new Container
                {
                    RelativeSizeAxes = Axes.Y,
                    Size = new Vector2(200, 1),
                    Children = new Drawable[]
                    {
                        new Box
                        {
                            Colour = Color4.DimGray,
                            RelativeSizeAxes = Axes.Both
                        },
                        new ScrollContainer
                        {
                            RelativeSizeAxes = Axes.Both,
                            ScrollbarOverlapsContent = false,
                            Children = new[]
                            {
                                //main category
                                leftFlowContainer = new FillFlowContainer<TestCaseCategoryButton>
                                {
                                    Padding = new MarginPadding(3),
                                    Direction = FillDirection.Vertical,
                                    Spacing = new Vector2(0, 5),
                                    AutoSizeAxes = Axes.Y,
                                    RelativeSizeAxes = Axes.X,
                                },
                            }
                        }
                    }
                },
                //Same category list
                new Container
                {
                    RelativeSizeAxes = Axes.Y,
                    Size = new Vector2(240, 1),
                    Position=new Vector2(205,1),
                    Children = new Drawable[]
                    {
                        new Box
                        {
                            Colour=new Color4(142, 101, 142,150),
                            RelativeSizeAxes = Axes.Both
                        },
                        new ScrollContainer
                        {
                            RelativeSizeAxes = Axes.Both,
                            ScrollbarOverlapsContent = false,
                            Children = new[]
                            {
                                //sub category
                                secondaryFlowContainer = new FillFlowContainer<TestCaseButton>
                                {
                                    Colour=new Color4(255, 255, 255,255),
                                    Padding = new MarginPadding(3),
                                    Direction = FillDirection.Vertical,
                                    Spacing = new Vector2(0, 5),
                                    AutoSizeAxes = Axes.Y,
                                    RelativeSizeAxes = Axes.X,
                                }
                            }
                        }
                    }
                },
                //TestSpace
                testContentContainer = new Container
                {
                    RelativeSizeAxes = Axes.Both,
                    Padding = new MarginPadding { Left = 450 },
                    Children = new Drawable[]
                    {
                        compilingNotice = new Container
                        {
                            Alpha = 0,
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre,
                            Masking = true,
                            Depth = float.MinValue,
                            CornerRadius = 5,
                            AutoSizeAxes = Axes.Both,
                            Children = new Drawable[]
                            {
                                new Box
                                {
                                    RelativeSizeAxes = Axes.Both,
                                    Colour = Color4.Black,
                                },
                                new SpriteText
                                {
                                    TextSize = 30,
                                    Text = @"Compiling new version..."
                                }
                            },
                        }
                    }
                }
            };

            //Background
            backgroundCompiler = new DynamicClassCompiler<CategoryTestCase>()
            {
                CompilationStarted = compileStarted,
                CompilationFinished = compileFinished,
                WatchDirectory = @"Tests",
            };

            //update category
            UpdateCategory();

            //TODO : get first category's name
            UpdateCategoryItem("");


            try
            {
                backgroundCompiler.Start();
            }
            catch
            {
                //it's okay for this to fail for now.
            }
        }

        /// <summary>
        /// Update Category
        /// </summary>
        private void UpdateCategory()
        {
            leftFlowContainer.Clear();
            //Add buttons for each TestCase.

            List<string> ListCategory = Tests.Keys.Distinct().ToList();


            leftFlowContainer.Add(ListCategory.Select(t => new TestCaseCategoryButton(t) { Action = () => UpdateCategoryItem(t) }));
        }

        /// <summary>
        /// if change to another category ,update this view
        /// </summary>
        /// <param name="selectedCategory">Selected category.</param>
        private void UpdateCategoryItem(string selectedCategory)
        {
            //TODO : impliment switch category
            secondaryFlowContainer.Clear();
            secondaryFlowContainer.Add(Tests.Select(t => new TestCaseButton(t.Value) { Action = () => LoadTest(t.Value) }));
        }


        private void compileStarted()
        {
            compilingNotice.Show();
            compilingNotice.FadeColour(Color4.White);
        }

        //compile the whole step of single test
        private void compileFinished(CategoryTestCase newVersion)
        {
            Schedule(() =>
            {
                compilingNotice.FadeOut(800, EasingTypes.InQuint);
                compilingNotice.FadeColour(newVersion == null ? Color4.Red : Color4.YellowGreen, 100);

                if (newVersion == null) return;

                //TODO : finish it
                //get the test that has
                //int i = Tests(t => t.GetType().Name == newVersion.GetType().Name);
                //Tests[i] = newVersion;
                //LoadTest(i);


            });
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();

            //get last record
            try
            {
                //LoadTest(Tests.(t => t.Name == config.Get<string>(TestBrowserSetting.LastTest)));
                if (CurrentTest == null)
                    foreach (KeyValuePair<String, CategoryTestCase> item in Tests)
                    {
                        if (item.Value.TestName == config.Get<string>(TestBrowserSetting.LastTest)) ;
                        LoadTest(item.Value);
                    }
                    
            }
            catch
            {
                
            }

            //if null ,use first testCase
            if (CurrentTest == null)
                LoadTest(Tests.First().Value);
        }

        protected override bool OnExiting(Screen next)
        {
            if (next == null)
                Game?.Exit();

            return base.OnExiting(next);
        }

        //load single test
        public void LoadTest(CategoryTestCase testCase = null, Action onCompletion = null)
        {
            //get first value
            if (testCase == null && Tests.Count > 0)
                testCase = Tests.First().Value;

            config.Set(TestBrowserSetting.LastTest, testCase?.Name);

            if (CurrentTest != null)
            {
                testContentContainer.Remove(CurrentTest);
                CurrentTest.Clear();

                var button = getButtonFor(CurrentTest);
                if (button != null) button.Current = false;

                CurrentTest = null;
            }

            if (testCase != null)
            {
                testContentContainer.Add(CurrentTest = testCase);
                testCase.Reset();
                testCase.RunAllSteps(onCompletion);

                var button = getButtonFor(CurrentTest);
                if (button != null) button.Current = true;
            }
        }

        private TestCaseButton getButtonFor(CategoryTestCase currentTest) => secondaryFlowContainer.Children.FirstOrDefault(b => b.TestCase.Name == currentTest.Name);
    }
}
