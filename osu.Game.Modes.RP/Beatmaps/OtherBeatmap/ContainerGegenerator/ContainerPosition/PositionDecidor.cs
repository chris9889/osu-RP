


using System;
using System.Collections.Generic;
using osu.Game.Modes.RP.Beatmaps.OtherBeatmap.Parameter;

namespace osu.Game.Modes.RP.Beatmaps.OtherBeatmap.ContainerGegenerator.ContainerPosition
{
    public class PositionDecidor
    {
        //物件位置定義，會定義可以的座標等等
        LinePositionDefinition LinePositionDefinition=new LinePositionDefinition();

        //用來統計不同line 被占用的次數
        private List<int> _listLineRemainCount = new List<int>();

        //會被占用兩次
        private int _lineOccupancyCount = 2;

        public PositionDecidor()
        {
            int maxLineNumber = LinePositionDefinition.MaxContainerNumber;
            _listLineRemainCount.Clear();
            for (int i = 0; i < maxLineNumber; i++)
            {
                _listLineRemainCount.Add(0);
            }
        }

        public void AllocatePosition(ComvertParameter single)
        {
            int availLine = ScanAvailableList();

            //開始分派線線
            for (int i = 0; i < single.ContainerConvertParameter.ListObjectContainer.Count; i++)
            {
                //目前優先順序
                int decideLinePriprity = GetRandNumber(single, i) % availLine;
                int line = FindLineIndexFromPriority(decideLinePriprity);
                single.ContainerConvertParameter.ListObjectContainer[i].Position = LinePositionDefinition.GetPosition(line);
                //被佔用了
                _listLineRemainCount[line] = _lineOccupancyCount;
                availLine--;
            }

            //把上一回的全部--;
            for (int i = 0; i < _listLineRemainCount.Count; i++)
            {
                if(_listLineRemainCount[i]>0)
                    _listLineRemainCount[i]--;
            }
        }

        int ScanAvailableList()
        {
            int emptyNum = 0;
            for (int i = 0; i < _listLineRemainCount.Count; i++)
            {
                if (_listLineRemainCount[i] == 0)
                    emptyNum++;
            }
            return emptyNum;
        }

        /// <summary>
        /// 找出沒辦占用的位置
        /// </summary>
        /// <returns></returns>
        int FindLineIndexFromPriority(int priority)
        {
            for(int i=0;i< _listLineRemainCount.Count;i++)
            {
                if (_listLineRemainCount[i] == 0)
                {
                    if (priority == 0)
                        return i;
                    priority--;
                }
            }
            return 0;
        }

        int GetRandNumber(ComvertParameter single,int index)
        {
            //確保
            return single.ContainerConvertParameter.LayoutNumber + (int)single.SliceConvertParameter.StartTime + index * (_listLineRemainCount.Count - 2) - ScanAvailableList();//確保每次物件會間隔兩個位置
        }
    }
}
