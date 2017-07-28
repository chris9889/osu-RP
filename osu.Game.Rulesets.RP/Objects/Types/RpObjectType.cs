// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System;

namespace osu.Game.Rulesets.RP.Objects.Types
{
    /// <summary>
    ///     所有物件基本
    /// </summary>
    public class RpBaseObjectType
    {
        //ObjectType
        [Flags]
        public enum ObjectType
        {
            Undefined = 1,
            HitObject = 2,
            Hit = 16,
            Hold = 32,
            ContainerGroup = 4,
            ContainerLine = 8,
            ContainerHold = 64,
            NewCombo = 128
        }

        //Convert
        [Flags]
        public enum Convert
        {
            Original,
            Convert
        }

        //CurveTypes , not use anymore
        [Flags]
        public enum CurveTypes
        {
            Catmull,
            Bezier,
            Linear,
            PerfectCurve
        }

        //Special
        [Flags]
        public enum Special
        {
            Normal = 0,
            Gold = 1
        }

        //CurveGenerate
        [Flags]
        public enum CurveGenerate
        {
            //RP譜面�E�E�E�E�E�E�E�所有頂點�E是手動
            Manual = 1,

            //RP譜面�E�E�E�E�E�E�E�只有製作開始和結束位置
            Manual_Start_End_Position = 2,

            //RP譜面�E�E�E�E�E�E�E�只有設定開始位置
            Manual_StartPosition = 4,

            //全部由osu譜面出侁E�E�E�E��E�E�E�
            Auto = 8
        }
    }

    /// <summary>
    ///     物件類型
    /// </summary>
    public class RpBaseHitObjectType : RpBaseObjectType
    {
        //Shape
        [Flags]
        public enum Shape
        {
            Up = 1, //up
            Down = 2, //down
            Left = 4, //left
            Right = 8, //right
            Special = 16, // Up| Down| Left| Right
            ContainerPress = 32 //containerPress
        }

        //Multi , not impliment yet
        [Flags]
        public enum Multi
        {
            SingleClick,
            Multi
        }

        //Coop
        [Flags]
        public enum Coop
        {
            LeftOnly,
            RightOnly,
            Both
        }
    }

    public class RpHitObjectType : RpBaseHitObjectType
    {
    }

    public class RpHoldType : RpBaseHitObjectType
    {
    }

    public class RpLongTailObjectType : RpBaseHitObjectType
    {
    }

    public class RpContainerPressType : RpBaseHitObjectType
    {
        //tickle the beat
        public enum ShowTimeLineView
        {
            none,
            normal,
            _2x,
            _3x,
            _4x,
            _6x,
            _8x
        }
    }
}
