using System;
using System.Collections.Generic;
using osu.Game.Beatmaps;
using osu.Game.Modes.RP.Beatmaps.OtherBeatmap.Parameter;
using osu.Game.Modes.RP.Beatmaps.OtherBeatmap.Slicing.Parameter;
using osu.Game.Modes.RP.Beatmaps.OtherBeatmap.Slicing.TimeSliceCalculator;

namespace osu.Game.Modes.RP.Beatmaps.OtherBeatmap.Slicing
{
    public class SliceProcessor
    {

        private Beatmap _originalBeatmap;

        /// <summary>
        /// 回傳時間範圍內的index
        /// </summary>
        TimeSlicingCalculator _timeSlicingCalculator=new TimeSlicingCalculator();

        /// <summary>
        /// 回傳切割結果
        /// </summary>
        /// <returns>The list comvert parameter.</returns>
        public List<ComvertParameter> GetListComvertParameter(Beatmap originalBeatmap)
        {
            List<ComvertParameter> list=new List<ComvertParameter>();
            _originalBeatmap = originalBeatmap;
            _timeSlicingCalculator.SetBeatmap(_originalBeatmap);

            int nowSlidingIndex = 0;

            //collect ComvertParameter and return list<ComvertParameter>
            while (nowSlidingIndex < originalBeatmap.HitObjects.Count)
            {
                //calculate by BPM to devide by TimeSliceCalculator
                int endindex = _timeSlicingCalculator.SlicingFrom(nowSlidingIndex);
                //follow the tiem to slice the beatmap and get the startTime and endTime
                list.Add(SlicingSingle(nowSlidingIndex, endindex));
                nowSlidingIndex = endindex + 1;
            }

            return list;
        }

        /// <summary>
        /// use startTime and Endtime to grab the object and return ComvertParameter
        /// And calculate number of Container and Layout
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        ComvertParameter SlicingSingle(int startIndex, int endIndex)
        {
            ComvertParameter single = new ComvertParameter();

            //Get Physical Refrence Object
            single.ListRefrenceObject = _originalBeatmap.HitObjects.GetRange(startIndex, endIndex- startIndex);

            //Generate Parameter
            single.SliceConvertParameter = GetSliceConvertParameterResult(single);
            return single;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public SliceConvertParameter GetSliceConvertParameterResult(ComvertParameter result)
        {
            //decide the number of container and layout
            SliceConvertParameter SliceConvertParameter=new SliceConvertParameter();
            
            //startTime
            SliceConvertParameter.StartTime = result.ListRefrenceObject[0].StartTime;

            //EndTime
            int endIndex = result.ListRefrenceObject.Count - 1;
            double lastHitObjectDuration = 0;
            SliceConvertParameter.EndTime = result.ListRefrenceObject[endIndex].StartTime + lastHitObjectDuration;

            //BPM
            SliceConvertParameter.BPM = _originalBeatmap.TimingInfo.BPMAt(SliceConvertParameter.StartTime);

            return  SliceConvertParameter;
        }

    }
}
