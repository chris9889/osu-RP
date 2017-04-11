using System;

namespace osu.Game.Modes.RP.Objects.type
{
    /// <summary>
    ///     謇譛臥黄莉ｶ蝓ｺ譛ｬ
    /// </summary>
    public class RpBaseObjectType
    {
        /// <summary>
        ///     蜩ｪ荳遞ｮ迚ｩ莉ｶ
        /// </summary>
        [Flags]
        public enum ObjectType
        {
            Undefined = 1,
            HitObject = 2,
            Container = 4,
            ContainerLayout = 8,
            Click = 16, //謇・
            LongTail = 32, //Slider
            Hold = 64, //螢謎ｽ丞庄莉･邏ｯ遨榊・謨ｸ
            ContainerPress = 128, //閭梧勹螢謎ｽ・
            NewCombo = 256
        }

        /// <summary>
        ///     迚ｩ莉ｶ譏ｯ霓画鋤驕守噪・碁ｄ譏ｯ蜴滓悽隴憺擇
        /// </summary>
        [Flags]
        public enum Convert
        {
            Original,
            Convert
        }

        /// <summary>
        ///     迚ｩ莉ｶ遘ｻ蜍慕噪霆瑚ｷ｡鬘槫梛
        /// </summary>
        [Flags]
        public enum CurveTypes
        {
            Catmull,
            Bezier,
            Linear,
            PerfectCurve
        }

        /// <summary>
        ///     螳夂ｾｩ譏ｯ豁｣蟶ｸ讓｡蠑城ｄ譏ｯgold 讓｡蠑・
        ///     螯よ棡譏ｯ蝨ｨArcade 讓｡蠑丞ｺ穂ｸ句・蛟倶ｸ襍ｷ謖臥噪荵滓怎隶頑・gold 讓｡蠑・
        /// </summary>
        [Flags]
        public enum Special
        {
            Normal = 0,
            Gold = 1
        }

        /// <summary>
        ///     蜃ｺ迴ｾ菴咲ｽｮ
        ///     隕∝・閾ｪ蜍包ｼ悟濠閾ｪ蜍暮ｄ譏ｯ蜈ｨ驛ｨ謇句虚
        /// </summary>
        [Flags]
        public enum CurveGenerate
        {
            //RP隴憺擇・梧園譛蛾るｻ樣・譏ｯ謇句虚
            Manual = 1,
            //RP隴憺擇・悟宵譛芽｣ｽ菴憺幕蟋句柱邨先據菴咲ｽｮ
            Manual_Start_End_Position = 2,
            //RP隴憺擇・悟宵譛芽ｨｭ螳夐幕蟋倶ｽ咲ｽｮ
            Manual_StartPosition = 4,
            //蜈ｨ驛ｨ逕ｱosu隴憺擇蜃ｺ萓・噪
            Auto = 8
        }
    }

    /// <summary>
    ///     迚ｩ莉ｶ鬘槫梛
    /// </summary>
    public class RpBaseHitObjectType : RpBaseObjectType
    {
        /// <summary>
        ///     螳夂ｾｩ迚ｩ莉ｶ鬘槫挨
        ///     骰ｵ逶､險ｭ螳壻ｹ滓怎逕ｨ蛻ｰ
        /// </summary>
        [Flags]
        public enum Shape
        {
            Up = 1, //荳芽ｧ・蟆肴㊨荳贋ｸ句ｷｦ蜿ｳ逧・ｮ夂ｾｩ)
            Down = 2, //蜿牙初
            Left = 4, //譁ｹ
            Right = 8, //蝨亥怦
            Special = 16, // Up| Down| Left| Right, //迚ｹ谿奇ｼ碁圷萓ｿ謖我ｸ蛟矩嵯驛ｽOK
            ContainerPress = 32
        }

        /// <summary>
        ///     譏ｯ蜷梧凾謖牙｣謎ｸ蛟矩嵯驍・弍螟壼句酔譎・
        /// </summary>
        [Flags]
        public enum Multi
        {
            SingleClick,
            Multi
        }

        /// <summary>
        ///     譏ｯ蟾ｦ蜿ｳ驍企・OK
        ///     驍・弍蜿ｪ譛牙・荳ｭ荳驍・
        /// </summary>
        [Flags]
        public enum Coop
        {
            LeftOnly,
            RightOnly,
            Both
        }

        /// <summary>
        ///     螳夂ｾｩ關ｽ荳区婿蠑乗弍osu! 驍｣讓｣驍・弍 Diva驍｣讓｣
        /// </summary>
        [Flags]
        public enum ApproachType
        {
            ApproachCircle,
            flow
        }
    }

    /// <summary>
    ///     RPHitObject迚ｩ莉ｶ鬘槫梛
    /// </summary>
    public class RpHitObjectType : RpBaseHitObjectType
    {
    }

    /// <summary>
    ///     RPHitObject迚ｩ莉ｶ鬘槫梛
    /// </summary>
    public class RpHoldType : RpBaseHitObjectType
    {
    }

    /// <summary>
    ///     RPLongTailObject迚ｩ莉ｶ鬘槫梛
    /// </summary>
    public class RpLongTailObjectType : RpBaseHitObjectType
    {
    }

    /// <summary>
    ///     RPLeftRightSlider迚ｩ莉ｶ鬘槫梛
    /// </summary>
    public class RpContainerPressType : RpBaseHitObjectType
    {
        /// <summary>
        ///     譎る俣鮟樣｡ｯ遉ｺ蛟咲紫
        /// </summary>
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
