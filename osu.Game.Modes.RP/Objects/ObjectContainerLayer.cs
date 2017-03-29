using OpenTK.Graphics;

namespace osu.Game.Modes.RP.Objects
{
    /// <summary>
    ///     裡面會儲存所有該在上面的物件
    /// </summary>
    public class ObjectContainerLayer : BaseRpObject
    {
        /// <summary>
        ///     用來從原本的Container裡面取得一些資訊
        /// </summary>
        public ObjectContainer ObjectContainer;

        /// <summary>
        ///     結束時間，可以任意設定
        /// </summary>
        public new double EndTime;

        /// <summary>
        ///     物件長度
        /// </summary>
        public float Lenght = 512;

        public ObjectContainerLayer(ObjectContainer objectContainer)
        {
            UpdateContainerLayout(objectContainer);

            InitialDefaultValue();
        }

        /// <summary>
        ///     初始化物件參數
        /// </summary>
        public override void InitialDefaultValue()
        {
            TIME_FADEIN = 300;

            //提早多久出現，通常是延後(-的)
            TIME_PREEMPT = 0;
            TIME_FADEOUT = 300;

            //顏色
            Colour = new Color4(100, 100, 100, 255);
        }

        /// <summary>
        ///     更新裡面的資訊
        /// </summary>
        /// <param name="objectContainer"></param>
        public void UpdateContainerLayout(ObjectContainer objectContainer)
        {
            ObjectContainer = objectContainer;
            StartTime = ObjectContainer.StartTime;
            Velocity = ObjectContainer.Velocity;
            EndTime = ObjectContainer.EndTime;
            Lenght = ObjectContainer.Lenght;
        }
    }
}
