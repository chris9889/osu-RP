using osu.Game.Rulesets.Replays;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using osu.Framework.Graphics;
using osu.Game.Beatmaps;
using osu.Game.Rulesets.Objects.Types;
using osu.Game.Rulesets.RP.BeatmapReplay;
using osu.Game.Rulesets.RP.KeyManager;
using osu.Game.Rulesets.RP.Objects;
using osu.Game.Rulesets.RP.Objects.Drawables.Play;
using osu.Game.Users;
using OpenTK.Input;

namespace osu.Game.Rulesets.RP.Replays
{
    public class RpAutoGenerator : AutoGenerator<BaseRpObject>
    {
        public bool DelayedMovements; // ModManager.CheckActive(Mods.Relax2);


        protected Replay Replay;
        protected List<ReplayFrame> Frames => Replay.Frames;

        public RpAutoGenerator(Beatmap<BaseRpObject> beatmap)
            : base(beatmap)
        {
            Replay = new Replay
            {
                User = new User
                {
                    Username = @"Rp!Autoplay",
                }
            };
        }

        public override Replay Generate()
        {
            var buttonIndex = 0;

            var preferredEasing = DelayedMovements ? Easing.InOutCubic : Easing.Out;

            addFrameToReplay(new RpReplayFrame(-100000, Key.Unknown, 500, ReplayButtonState.None));
            addFrameToReplay(new RpReplayFrame(Beatmap.HitObjects[0].StartTime - 1500, Key.Unknown, 500, ReplayButtonState.None));
            addFrameToReplay(new RpReplayFrame(Beatmap.HitObjects[0].StartTime - 1000, Key.Unknown, 192, ReplayButtonState.None));

            // We are using ApplyModsToRate and not ApplyModsToTime to counteract the speed up / slow down from HalfTime / DoubleTime so that we remain at a constant framerate of 60 fps.
            var frameDelay = (float)applyModsToRate(1000.0 / 60.0);

            // Already superhuman, but still somewhat realistic
            var reactionTime = (int)applyModsToRate(100);

            var listHitObjects = new List<BaseRpHitableObject>();


            //Get all the Objects that can be hit
            foreach (var single in Beatmap.HitObjects)
                if (single is BaseRpHitableObject)
                    listHitObjects.Add((BaseRpHitableObject)single);

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
                    listPointTime.Add(h.StartTime + h.HitWindowFor(RpScoreResult.Cool));
                }
                else if (h is RpHoldObject)
                {
                    //add start and endPoint
                    listPointTime.Add(h.StartTime);
                    listPointTime.Add(h.StartTime + h.HitWindowFor(RpScoreResult.Cool));
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
                {
                    if (single is IHasEndTime)
                    {
                        if (time <= (single as IHasEndTime).EndTime)
                            listPressKey.Add(getKeyByHitObject(single));
                    }
                    else
                    {
                        if (time <= single.StartTime)
                            listPressKey.Add(getKeyByHitObject(single));
                    }
                }

                addFrameToReplay(new RpReplayFrame(time, listPressKey, 0, ReplayButtonState.None));
            }

            return Replay;
        }

        private void addFrameToReplay(RpReplayFrame frame) => Frames.Add(frame);
        private double applyModsToTime(double v) => v;
        private double applyModsToRate(double v) => v;

        /// <summary>
        ///     取得時間點上的所有打擊物件
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BaseRpHitableObject> GetListPressHitObjectByTime(List<BaseRpHitableObject> listHitObjects, double time)
        {
            foreach (var container in listHitObjects)
            {
                int offset = 10;
                if (container is IHasEndTime)
                {
                    if (container.StartTime <= time && ((IHasEndTime)container).EndTime >= time)
                        yield return container;
                }
                else if (container.StartTime == time)
                    yield return container;
            }
        }

        /// <summary>
        ///     Get List Key
        /// </summary>
        /// <returns></returns>
        private Key getKeyByHitObject(BaseRpHitableObject hitObject)
        {
            var listCompareKeys = RpKeyManager.GetListKey(hitObject);

            return listCompareKeys[0];
        }
    }
}
