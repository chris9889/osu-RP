// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System;
using System.Collections.Generic;
using System.Linq;
using osu.Framework.Graphics;
using osu.Game.Beatmaps;
using osu.Game.Rulesets.Replays;
using osu.Game.Rulesets.RP.BeatmapReplay;
using osu.Game.Rulesets.RP.KeyManager;
using osu.Game.Rulesets.RP.Objects;
using OpenTK;
using OpenTK.Input;

namespace osu.Game.Rulesets.RP.Mods.ModsElement
{
    /// <summary>
    ///     這邊要把滑鼠的X軸當作按鍵使用
    /// </summary>
    public class RpAutoReplay : osu.Game.Rulesets.Replays.Replay
    {
        public bool DelayedMovements; // ModManager.CheckActive(Mods.Relax2);

        /// <summary>
        ///     Beatmap
        /// </summary>
        private readonly Beatmap<BaseRpObject> beatmap;

        private static readonly IComparer<ReplayFrame> replay_frame_comparer = new ReplayFrameComparer();

        public RpAutoReplay(Beatmap<BaseRpObject> beatmap)
        {
            this.beatmap = beatmap;

            createAutoReplay();
        }

        /// <summary>
        ///     取得時間點上的所有打擊物件
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BaseRpHitObject> GetListPressHitObjectByTime(List<BaseRpHitObject> listHitObjects, double time)
        {
            foreach (var container in listHitObjects)
                if (container.StartTime <= time && container.EndTime >= time)
                    yield return container;
        }

        private static Vector2 circlePosition(double t, double radius) => new Vector2((float)(Math.Cos(t) * radius), (float)(Math.Sin(t) * radius));

        private int findInsertionIndex(ReplayFrame frame)
        {
            var index = Frames.BinarySearch(frame, replay_frame_comparer);

            if (index < 0)
                index = ~index;
            else
                while (index < Frames.Count && frame.Time == Frames[index].Time)
                    ++index;

            return index;
        }

        private void addFrameToReplay(RpReplayFrame frame) => Frames.Insert(findInsertionIndex(frame), frame);

        private double applyModsToTime(double v) => v;
        private double applyModsToRate(double v) => v;

        private void createAutoReplay()
        {
            var buttonIndex = 0;

            var preferredEasing = DelayedMovements ? EasingTypes.InOutCubic : EasingTypes.Out;

            addFrameToReplay(new RpReplayFrame(-100000, Key.Unknown, 500, ReplayButtonState.None));
            addFrameToReplay(new RpReplayFrame(beatmap.HitObjects[0].StartTime - 1500, Key.Unknown, 500, ReplayButtonState.None));
            addFrameToReplay(new RpReplayFrame(beatmap.HitObjects[0].StartTime - 1000, Key.Unknown, 192, ReplayButtonState.None));

            // We are using ApplyModsToRate and not ApplyModsToTime to counteract the speed up / slow down from HalfTime / DoubleTime so that we remain at a constant framerate of 60 fps.
            var frameDelay = (float)applyModsToRate(1000.0 / 60.0);

            // Already superhuman, but still somewhat realistic
            var reactionTime = (int)applyModsToRate(100);

            var listHitObjects = new List<BaseRpHitObject>();


            //Get all the Objects that can be hit
            foreach (var single in beatmap.HitObjects)
                if (single is BaseRpHitObject)
                    listHitObjects.Add((BaseRpHitObject)single);

            //OrderBy startTime
            listHitObjects.Sort((x, y) => x.StartTime.CompareTo(y.StartTime));

            //list of change keyState's time
            var listPointTime = new List<double>();

            //Start processing
            for (var i = 0; i < listHitObjects.Count; i++)
            {
                var h = listHitObjects[i];

                if (h is RpHitObject)
                {
                    //add start and endPoint
                    listPointTime.Add(h.StartTime);
                    listPointTime.Add(h.EndTime + h.hit300);
                }
                else if (h is RpSliderObject)
                {
                    //add start and endPoint
                    listPointTime.Add(h.StartTime);
                    listPointTime.Add(h.EndTime + h.hit300);
                }
            }

            //TODO : clean out the same point time and sort it
            listPointTime = listPointTime.Distinct().ToList();

            //to every listPointTime,calculate the 
            foreach (var time in listPointTime)
            {
                var listOnPointTimeHitObject = GetListPressHitObjectByTime(listHitObjects, time).ToList();
                var listPressKey = new List<Key>();
                foreach (var single in listOnPointTimeHitObject)
                    if (time <= single.EndTime)
                        listPressKey.Add(getKeyByHitObject(single));
                addFrameToReplay(new RpReplayFrame(time, listPressKey, 0, ReplayButtonState.None));
            }

            //Player.currentScore.Replay = InputManager.ReplayScore.Replay;
            //Player.currentScore.PlayerName = "osu!RP";
        }

        /// <summary>
        ///     Get List Key
        /// </summary>
        /// <returns></returns>
        private Key getKeyByHitObject(BaseRpHitObject hitObject)
        {
            var listCompareKeys = RpKeyManager.GetListKey(hitObject);

            return listCompareKeys[0];
        }

        private class ReplayFrameComparer : IComparer<ReplayFrame>
        {
            public int Compare(ReplayFrame f1, ReplayFrame f2)
            {
                return f1.Time.CompareTo(f2.Time);
            }
        }


        //public override ReplayInputHandler CreateInputHandler() => new RpLegacyReplayInputHandler(Frames);
    }
}
