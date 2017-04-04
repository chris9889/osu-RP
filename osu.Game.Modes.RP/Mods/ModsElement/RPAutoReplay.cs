// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System;
using System.Collections.Generic;
using System.Linq;
using osu.Framework.Graphics;
using osu.Game.Beatmaps;
using osu.Game.Modes.Replays;
using osu.Game.Modes.RP.Objects;
using osu.Game.Modes.RP.Objects.type;
using OpenTK;
using OpenTK.Input;

namespace osu.Game.Modes.RP.Replay
{
    /// <summary>
    /// 這邊要把滑鼠的X軸當作按鍵使用
    /// </summary>
    public class RpAutoReplay : Replays.Replay
    {
        /// <summary>
        /// Beatmap
        /// </summary>
        private readonly Beatmap<BaseRpObject> beatmap;

        public RpAutoReplay(Beatmap<BaseRpObject> beatmap)
        {
            this.beatmap = beatmap;

            createAutoReplay();
        }

        private class ReplayFrameComparer : IComparer<ReplayFrame>
        {
            public int Compare(ReplayFrame f1, ReplayFrame f2)
            {
                return f1.Time.CompareTo(f2.Time);
            }
        }

        private static readonly IComparer<ReplayFrame> replay_frame_comparer = new ReplayFrameComparer();

        private int findInsertionIndex(ReplayFrame frame)
        {
            int index = Frames.BinarySearch(frame, replay_frame_comparer);

            if (index < 0)
            {
                index = ~index;
            }
            else
            {
                // Go to the first index which is actually bigger
                while (index < Frames.Count && frame.Time == Frames[index].Time)
                {
                    ++index;
                }
            }

            return index;
        }

        private void addFrameToReplay(RpReplayFrame frame) => Frames.Insert(findInsertionIndex(frame), frame);

        private static Vector2 circlePosition(double t, double radius) => new Vector2((float)(Math.Cos(t) * radius), (float)(Math.Sin(t) * radius));

        private double applyModsToTime(double v) => v;
        private double applyModsToRate(double v) => v;

        public bool DelayedMovements; // ModManager.CheckActive(Mods.Relax2);

        private void createAutoReplay()
        {
            int buttonIndex = 0;

            EasingTypes preferredEasing = DelayedMovements ? EasingTypes.InOutCubic : EasingTypes.Out;

            addFrameToReplay(new RpReplayFrame(-100000, Key.Unknown, 500, ReplayButtonState.None));
            addFrameToReplay(new RpReplayFrame(beatmap.HitObjects[0].StartTime - 1500, Key.Unknown, 500, ReplayButtonState.None));
            addFrameToReplay(new RpReplayFrame(beatmap.HitObjects[0].StartTime - 1000, Key.Unknown, 192, ReplayButtonState.None));

            // We are using ApplyModsToRate and not ApplyModsToTime to counteract the speed up / slow down from HalfTime / DoubleTime so that we remain at a constant framerate of 60 fps.
            float frameDelay = (float)applyModsToRate(1000.0 / 60.0);

            // Already superhuman, but still somewhat realistic
            int reactionTime = (int)applyModsToRate(100);

            List<BaseHitObject> listHitObjects=new List<BaseHitObject>();
            

            //Get all the Objects that can be hit
            foreach (BaseRpObject single in beatmap.HitObjects)
            {
                if(single is BaseHitObject)
                    listHitObjects.Add((BaseHitObject)single);
            }

            //OrderBy startTime
            listHitObjects.Sort((x, y) => x.StartTime.CompareTo(y.StartTime));

            //list of change keyState's time
            List<double> listPointTime = new List<double>();

            //Start processing
            for (int i = 0; i < listHitObjects.Count; i++)
            {
                BaseHitObject h = listHitObjects[i];

                if (h is RpHitObject)
                {
                    //add start and endPoint
                    listPointTime.Add(h.StartTime);
                    listPointTime.Add(h.EndTime + h.hit300);
                }
                else if (h is RpLongTailObject)
                { 
                    //add start and endPoint
                    listPointTime.Add(h.StartTime);
					listPointTime.Add(h.EndTime + h.hit300);
                }
            }

            //TODO : clean out the same point time and sort it
            listPointTime = listPointTime.Distinct().ToList();

            //to every listPointTime,calculate the 
            foreach (double time in listPointTime)
            {
                List<BaseHitObject> listOnPointTimeHitObject = GetListPressHitObjectByTime(listHitObjects,time).ToList();
                List<Key> listPressKey = new List<Key>();
                foreach (BaseHitObject single in listOnPointTimeHitObject)
                {
                    //if is on the hit time
                    if (time <= single.EndTime)
                        listPressKey.Add(getKeyByHitObject(single));
                }  
                addFrameToReplay(new RpReplayFrame(time, listPressKey, 0, ReplayButtonState.None));
            }

            //Player.currentScore.Replay = InputManager.ReplayScore.Replay;
            //Player.currentScore.PlayerName = "osu!RP";
        }

        /// <summary>
        ///     取得時間點上的所有打擊物件
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BaseHitObject> GetListPressHitObjectByTime(List<BaseHitObject> listHitObjects,double time)
		{
			foreach (var container in listHitObjects)
				if (container.StartTime <= time && container.EndTime >= time)
					yield return container;
		}

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Key getKeyByHitObject(BaseHitObject hitObject)
        {
            Key key=Key.Unknown;
            switch (hitObject.Shape)
            {
                 case RpBaseHitObjectType.Shape.Up:
                    return Key.E;
                case RpBaseHitObjectType.Shape.Down:
                    return Key.D;
                case RpBaseHitObjectType.Shape.Left:
                    return Key.S;
                case RpBaseHitObjectType.Shape.Right:
                    return Key.F;
                case RpBaseHitObjectType.Shape.ContainerPress:
                    return Key.A;
            }
            return key;
        }


        //public override ReplayInputHandler CreateInputHandler() => new RpLegacyReplayInputHandler(Frames);

        

       

    }
}
