using OpenTK;

namespace osu.Game.Modes.RP.Objects.Drawables.Calculator.Position
{
    /// <summary>
    /// 用來計算物件位置(時間點)
    /// </summary>
    class ContainerLayoutPositionCounter
    {
        /// <summary>
        /// 倍率
        /// </summary>
        float MULTIPLE = 1000;

        /// <summary>
        /// 寬度
        /// </summary>
        public float Width = 700;//512;

        /// <summary>
        /// 速度
        /// </summary>
        public static float Speed = 0.3f;

        /// <summary>
        /// 指標位置(X軸)
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public float GetPosition(double time)
        {
            float positionX = ((float)time / 1000) * Speed * MULTIPLE;
            positionX = positionX % Width;
            //inverse
            //position_x = -position_x + screenWidth + 10;
            return positionX;
        }

        /// <summary>
        /// 根據縮放比例和傾斜角度修改位置
        /// </summary>
        /// <returns></returns>
        public Vector2 GetfixedPosition(double time,float rotation,float scale)
        {
            return new Vector2();
        }
    }
}
