using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using osu.Desktop.VisualTests.Tests;
using osu.Framework.Allocation;
using osu.Framework.Configuration;
using osu.Framework.Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Platform;
using osu.Framework.Screens;
using osu.Framework.Testing;
using OpenTK;
using OpenTK.Graphics;

namespace osu.Desktop.VisualTests.Tools
{
    /// <summary>
    /// this test browser can sorted by class category
    /// </summary>
    public class RpTestBrowser : Screen
    {
        
        public CategoryTestCase CurrentTest { get; private set; }

        private FillFlowContainer<TestCaseCategoryButton> categoryFlowContainer;
        private FillFlowContainer<TestCaseButton> secondaryFlowContainer;

        private Container testContentContainer;
        private Container compilingNotice;

        //List category
        List<string> ListCategoryName = new List<string>();

        //change it into dictionary
        public readonly List<Type> Tests = new List<Type>();

        private ConfigManager<TestBrowserSetting> config;

        private DynamicClassCompiler backgroundCompiler;

        public RpTestBrowser()
        {
            //we want to build the lists here because we're interested in the assembly we were *created* on.
            Assembly asm = Assembly.GetCallingAssembly();
            //get all class that is inherit from CategoryTestCase
            foreach (Type type in asm.GetLoadableTypes().Where(t => t.IsSubclassOf(typeof(CategoryTestCase)) && !t.IsAbstract))
            {
                //CategoryTestCase singleTestCase = (CategoryTestCase)Activator.CreateInstance(type);
                //if this class is need to test
                //if(singleTestCase.AddToTest)
                //{
                //    //Category it
                //    Tests.Add(type);
                //}

                Tests.Add(type);
            }
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
                                categoryFlowContainer = new FillFlowContainer<TestCaseCategoryButton>
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
            backgroundCompiler = new DynamicClassCompiler()
            {
                CompilationStarted = compileStarted,
                CompilationFinished = compileFinished,
                WatchDirectory = @"Tests",
            };

            //update category
            initialCategory();

            //get first category's name and update TestCase
            updateCategoryItem(ListCategoryName.FirstOrDefault());


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
        private void initialCategory()
        {
            categoryFlowContainer.Clear();
            //Add buttons for each TestCase.

            ListCategoryName.Clear();

            foreach(Type single in Tests)
            {
                CategoryTestCase singleTestCase = (CategoryTestCase)Activator.CreateInstance(single);
                if (!ListCategoryName.Contains(singleTestCase.Category))
                    ListCategoryName.Add(singleTestCase.Category);
            }
            //Sort by string name
            ListCategoryName.Sort();
            categoryFlowContainer.Add(ListCategoryName.Select(t => new TestCaseCategoryButton(t) { Action = () => updateCategoryItem(t) }));
        }

        /// <summary>
        /// if change to another category ,update this view
        /// </summary>
        /// <param name="selectedCategory">Selected category.</param>
        private void updateCategoryItem(string selectedCategory)
        {
            //update selected category color
            secondaryFlowContainer.Clear();
            secondaryFlowContainer.Add(Tests.Where(t=>((CategoryTestCase)Activator.CreateInstance(t)).Category==selectedCategory).OrderBy(t=>t.Name).Select(t => new TestCaseButton(t) { Action = () => LoadTest(t) }));
        }


        private void compileStarted()
        {
            compilingNotice.Show();
            compilingNotice.FadeColour(Color4.White);
        }

        //compile the whole step of single test
        private void compileFinished(Type newVersion)
        {
            Schedule(() =>
            {
                compilingNotice.FadeOut(800, EasingTypes.InQuint);
                compilingNotice.FadeColour(newVersion == null ? Color4.Red : Color4.YellowGreen, 100);

                if (newVersion == null) return;

                //TODO : finish it
                //get the test that has
                int i = Tests.FindIndex(t => t.GetType().Name == newVersion.GetType().Name);
                Tests[i] = newVersion;
                LoadTest(Tests[i]);

            });
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();
            try
            {
                //get last record
                if (CurrentTest == null)
                    LoadTest(Tests.Find(t => t.Name == config.Get<string>(TestBrowserSetting.LastTest)));
            }
            catch
            {
                LoadTest(Tests.First());
            }
        }

        protected override bool OnExiting(Screen next)
        {
            if (next == null)
                Game?.Exit();

            return base.OnExiting(next);
        }

        //load single test
        public void LoadTest(Type testCase = null, Action onCompletion = null)
        {
            //get first value
            if (testCase == null && Tests.Count > 0)
                testCase = Tests.First();

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
                testContentContainer.Add(CurrentTest = (CategoryTestCase)Activator.CreateInstance(testCase));
                CurrentTest.OnLoadComplete = d => ((CategoryTestCase)d).RunAllSteps(onCompletion);
            }
            updateButtons();
        }

        private void updateButtons()
        {
            foreach (var b in categoryFlowContainer.Children)
                b.Current = b.CategoryName == CurrentTest.Category;
        }

        private TestCaseButton getButtonFor(CategoryTestCase currentTest) 
            => secondaryFlowContainer.Children.FirstOrDefault(b => ((CategoryTestCase)Activator.CreateInstance(b.TestType)).TestName == currentTest.Name);
    }
}
