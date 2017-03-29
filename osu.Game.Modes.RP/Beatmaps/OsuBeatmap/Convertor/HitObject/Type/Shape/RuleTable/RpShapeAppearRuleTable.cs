// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;
using OpenTK;

namespace osu.Game.Modes.RP.Beatmaps.OsuBeatmap.Convertor.HitObject.Type.Shape.RuleTable
{
    internal class RpShapeAppearRuleTable
    {
        //交換規則全部寫在這邊
        private readonly string[] _listRule =
        {
            //1:1
            "1,2", //有點規律(連打會用到)
            "1,2,3,4", //神奇規律
            //1:2
            "1,2_3",
            //1:3
            "1,2_3_4",
            //1:4
            "1,1_2_3_4",
            //2:2
            "1_2,3_4",
            //2:3
            "1_2,2_3_4",
            //2:4
            "1_2,1_2_3_4",
            //3:3
            "1_2_3,2_3_4",
            //3:4
            "1_2_3,1_2_3_4",
            //4:4
            "1_2_3_4,1_2_3_4",
            //4:4:4
            "1_2_3_4,1_2_3_4,1_2_3_4",
            //4:4:4:4
            "1_2_3_4,1_2_3_4,1_2_3_4,1_2_3_4"
        };

        //存放欄位
        private readonly List<int[][]> _listTable;

        //目前的索引
        private int _nowListIndex;
        //亂數
        private int _randomValue;

        //參數
        private int _index;

        private int _beatNumber;
        private int _nowBeat;

        /// <summary>
        ///     建構，會順便把資料轉換好存進 _listTable 裡面
        /// </summary>
        public RpShapeAppearRuleTable()
        {
            _listTable = new List<int[][]>();
            foreach (var str in _listRule)
                _listTable.Add(ComvertSingleString(str));
        }

        public void SetIndex(int index)
        {
            _index = index;
        }

        /// <summary>
        ///     取得亂數，用來分配指定物件順序
        /// </summary>
        /// <param name="thisPosition"></param>
        /// <param name=""></param>
        public void SetRandomValue(Vector2 thisPosition, int startTime)
        {
            _randomValue = (int)thisPosition.X + (int)thisPosition.Y + startTime;
        }

        /// <summary>
        ///     取得目前打擊和
        /// </summary>
        public void SetBeatParameter(int beatNumber, int nowBeat)
        {
            _beatNumber = beatNumber;
            _nowBeat = nowBeat;
        }

        /// <summary>
        ///     重新計算一次
        ///     要找到滿足的條件
        ///     目前用Aracde 的方式計算
        /// </summary>
        public void ReCalculate()
        {
            try
            {
                var compareTable = new List<int[][]>();

                _listTable.ForEach(delegate(int[][] each)
                    {
                        if (each.Length == _beatNumber)
                            compareTable.Add(each);
                    }
                );

                //回傳
                _nowListIndex = _randomValue % compareTable.Count;
            }
            catch
            {
                _nowListIndex = 0;
            }
        }

        /// <summary>
        ///     如果沒有要重新改變規律，就照目前規律進行
        /// </summary>
        public void UpdateState()
        {
        }

        /// <summary>
        ///     取得對應大小的陣列回來
        /// </summary>
        /// <returns></returns>
        public int[] GetIndexTable()
        {
            return _listTable[_nowBeat][_nowListIndex];
        }

        /// <summary>
        ///     處理單一轉換
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private int[][] ComvertSingleString(string iput)
        {
            var single = iput.Split(',');
            var arrayWidth = single.Length;
            var result = new int[arrayWidth][];
            for (var i = 0; i < arrayWidth; i++)
            {
                var str2 = single[i].Split('_');
                var singleObjectValue = new int[str2.Length];
                for (var j = 0; j < str2.Length; j++)
                    singleObjectValue[j] = int.Parse(str2[j]);
                result[i] = singleObjectValue;
            }
            return result;
        }
    }
}
