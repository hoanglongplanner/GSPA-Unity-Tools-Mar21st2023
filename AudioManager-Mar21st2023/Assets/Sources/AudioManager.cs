/*
Copyright 2023 hoanglongplanner

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

//ADDED
using APIAudioManager_Mar21st2023;

namespace APIAudioManager_Mar21st2023 {
    public enum ENUM_AUDIOMIXER_TYPE {
        MASTER,
        MUSIC,
        SFX,
        SFX_GAME,
        SFX_GUI
    }

    public enum ENUM_AUDIO_MUSIC_TYPE {
        MENU,
        GAMEPLAY,
        GAMEOVER
    }

    public enum ENUM_AUDIO_GUI_TYPE {
        HOVER,
        EXIT,
        CLICK,
        CANCEL
    }

    public enum ENUM_AUDIO_GAME_TYPE {
        ENEMY_DEATH,
        EXPLOSION,
    }    

    public class AudioManagerSettings {
        public const bool K_IS_AUDIO_PLAY_ON_AWAKE = false; //def: false
    }

    public class AudioManager : MonoBehaviour, IAudioManager {

        public AudioMixerGroup[] sz_m_audioMixer;
        public AudioClip[] sz_m_audioClipMusic;
        public AudioClip[] sz_m_audioClipGUI;        
        public AudioClip[] sz_m_audioGame;

        public void PlayMusic(ENUM_AUDIO_MUSIC_TYPE type) {
            switch (type) {
                case ENUM_AUDIO_MUSIC_TYPE.MENU:
                    break;
                case ENUM_AUDIO_MUSIC_TYPE.GAMEPLAY:
                    break;
                case ENUM_AUDIO_MUSIC_TYPE.GAMEOVER:
                    break;                
            }

            PlayAudio((int)type, sz_m_audioClipMusic, sz_m_audioMixer[(int)ENUM_AUDIOMIXER_TYPE.MUSIC]);
        }

        public void PlaySFX_GUI(ENUM_AUDIO_GUI_TYPE type) {
            switch (type) {
                case ENUM_AUDIO_GUI_TYPE.HOVER:
                    break;
                case ENUM_AUDIO_GUI_TYPE.CLICK:
                    break;
                case ENUM_AUDIO_GUI_TYPE.CANCEL:
                    break;
            }

            PlayAudio((int)type, sz_m_audioClipGUI, sz_m_audioMixer[(int)ENUM_AUDIOMIXER_TYPE.SFX_GUI]);
        }        

        public void PlaySFX_Game(ENUM_AUDIO_GAME_TYPE type) {
            switch (type) {
                case ENUM_AUDIO_GAME_TYPE.ENEMY_DEATH:
                    break;
                case ENUM_AUDIO_GAME_TYPE.EXPLOSION:
                    break;
            }

            PlayAudio((int)type, sz_m_audioGame, sz_m_audioMixer[(int)ENUM_AUDIOMIXER_TYPE.SFX_GAME]);
        }

        public void PlayAudio(int index, AudioClip[] audioClips, AudioMixerGroup audioMixer) {
            throw new System.NotImplementedException();
        }        

        public UnityEngine.AudioSource CreateAudioObject() {
            UnityEngine.GameObject temp = null;
            return temp.GetComponent<AudioSource>();
        }        

        public void SetMixerVol(ENUM_AUDIOMIXER_TYPE type, float value) {
            throw new System.NotImplementedException();
        }

        public void SetAudioObjectVol(AudioSource audioSource, float value) {
            throw new System.NotImplementedException();
        }

        public void SetAudioObjectPitch(AudioSource audioSource, float value) {
            throw new System.NotImplementedException();
        }

        public void SetAudioObjectPan(AudioSource audioSource, float value) {
            throw new System.NotImplementedException();
        }
    }
}

