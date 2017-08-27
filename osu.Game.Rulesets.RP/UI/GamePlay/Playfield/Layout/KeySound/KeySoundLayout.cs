﻿// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;
using osu.Framework.Allocation;
using osu.Framework.Audio;
using osu.Framework.Audio.Sample;
using osu.Framework.Input;
using osu.Game.Rulesets.RP.Input;
using osu.Game.Rulesets.RP.Objects;
using OpenTK.Input;
using osu.Framework.Input.Bindings;

namespace osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.KeySound
{
    /// <summary>
    ///     放置顯示在打擊物件之前的東西
    ///     例如DecisionLine
    /// </summary>
    internal class KeySoundLayout : BaseGamePlayLayout , IKeyBindingHandler<RpAction>
    {
        //TODO : 增加聲音
        protected List<SampleChannel> ShapeSample = new List<SampleChannel>();

        protected List<SampleChannel> ContainerPressSample = new List<SampleChannel>();

        private InputState _lastState;

        public KeySoundLayout()
        {
            var keyList = new List<RpAction>();//(RpKeyManager.GetCurrentKeyConfig());

            //foreach (var singleKey in keyList.KeyDictionary)
            //    if (singleKey.Type == Shape.ContainerPress)
            //        _containerPressKeys.Add(singleKey.Key);
            //    else
            //        _listShapeKeys.Add(singleKey.Key);
        }


        public bool OnPressed(RpAction action)
        {
            return true;
        }

        public bool OnReleased(RpAction action)
        {
            return true;
        }

        //protected override bool OnKeyDown(InputState state, KeyDownEventArgs args)
        //{
        //    if (args.Repeat)
        //        return false;
        //    var hitIndex = 0;
        //    if (_listShapeKeys.Contains(args.Key))
        //        for (int i = 0; i < _listShapeKeys.Count; i++)
        //            if (_listShapeKeys[i] == args.Key)
        //                PlayShapeSample(i);
        //            else if (_containerPressKeys.Contains(args.Key))
        //                for (int j = 0; j < _containerPressKeys.Count; j++)
        //                    if (_containerPressKeys[j] == args.Key)
        //                        PlayContainerPressSample(j);
        //    return base.OnKeyDown(state, args);
        //}

        protected virtual void PlayShapeSample(int keyIndex)
        {
            ShapeSample[keyIndex]?.Play();
        }

        protected virtual void PlayContainerPressSample(int keyIndex)
        {
            ShapeSample[keyIndex]?.Play();
        }

        [BackgroundDependencyLoader]
        private void load(AudioManager audio)
        {
            //foreach (var single in _listShapeKeys)
            //    ShapeSample.Add(audio.Sample.Get($@"RPKey/Key-Shape"));
            //foreach (var single in _containerPressKeys)
            //    ContainerPressSample.Add(audio.Sample.Get($@"RPKey/Key-ContainerHold"));
        }

    }
}
