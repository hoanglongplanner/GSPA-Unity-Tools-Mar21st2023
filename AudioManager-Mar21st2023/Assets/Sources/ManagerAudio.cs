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

/*
NOTES

Please set up AUDIO MIXER correctly like the diagram below:
MASTER <- MUSIC
MASTER <- SFX <- SFX_GAME or SFX_GUI
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

    public class ManagerAudioSettings {        
        public const float K_AUDIO_MIXER_RATE = 20.0f;
        public const float K_AUDIO_MIXER_RATE_MUTE = -80.0f;
        public const bool K_IS_AUDIO_PLAY_ON_AWAKE = false; //def: false
    }

    public class ManagerAudio : MonoBehaviour, IAudioManager {

        public AudioMixerGroup[] sz_m_audioMixerGroup;
        public AudioClip[] sz_m_audioClipMusic;
        public AudioClip[] sz_m_audioClipGUI;        
        public AudioClip[] sz_m_audioGame;

        public bool isFadeIn = false;
        public bool isFadeOut = false;

        public AudioClip GetAudioClip() {
            throw new System.NotImplementedException();
        }

        public void PlayMusic(ENUM_AUDIO_MUSIC_TYPE type, bool isRandom = false) {
            switch (type) {
                case ENUM_AUDIO_MUSIC_TYPE.MENU:
                    break;
                case ENUM_AUDIO_MUSIC_TYPE.GAMEPLAY:
                    break;
                case ENUM_AUDIO_MUSIC_TYPE.GAMEOVER:
                    break;                
            }

            PlayAudio((int)type, sz_m_audioClipMusic, sz_m_audioMixerGroup[(int)ENUM_AUDIOMIXER_TYPE.MUSIC]);
        }

        public void PlaySFX_GUI(ENUM_AUDIO_GUI_TYPE type, bool isRandom = false) {
            switch (type) {
                case ENUM_AUDIO_GUI_TYPE.HOVER:
                    break;
                case ENUM_AUDIO_GUI_TYPE.CLICK:
                    break;
                case ENUM_AUDIO_GUI_TYPE.CANCEL:
                    break;
            }

            PlayAudio((int)type, sz_m_audioClipGUI, sz_m_audioMixerGroup[(int)ENUM_AUDIOMIXER_TYPE.SFX_GUI]);
        }        

        public void PlaySFX_Game(ENUM_AUDIO_GAME_TYPE type, bool isRandom = false) {
            switch (type) {
                case ENUM_AUDIO_GAME_TYPE.ENEMY_DEATH:
                    break;
                case ENUM_AUDIO_GAME_TYPE.EXPLOSION:
                    break;
            }

            PlayAudio((int)type, sz_m_audioGame, sz_m_audioMixerGroup[(int)ENUM_AUDIOMIXER_TYPE.SFX_GAME]);
        }        

        public void PlayAudio(AudioClip audioClip, AudioMixerGroup audioMixer) {
            throw new System.NotImplementedException();
        }

        public void PlayAudio(int index, AudioClip[] audioClips, AudioMixerGroup audioMixer) {
            throw new System.NotImplementedException();
        }

        public void PlayMusic(AudioClip clip, bool isLooping) {
            
            if (clip != null) {
                //m_bgmSource.clip = clip;
                //m_bgmSource.loop = isLooping;
                //m_bgmSource.Play();
            }

            else Debug.Log(this.name + ": Music clip not found!");
        }

        public UnityEngine.AudioSource CreateAudioObject() {
            UnityEngine.GameObject temp = null;
            return temp.GetComponent<AudioSource>();
        }        

        public void SetMixerVol(ENUM_AUDIOMIXER_TYPE type, float value) {
            /*
             AudioMixer mixer = m_mixerGroup[(int)mixerType].audioMixer;

        string mixerName = mixerType.ToString();

        switch (mixerType)
        {
            case ENUM_MIXER_GROUP_NAME.MASTER:
                mixer.SetFloat(mixerName, SaveData.Load_MixerMaster() == 0
                    ? -ProjectConstants.K_AUDIO_RATE_MUTE : Mafthf.Log10(SaveData.Load_MixerMaster()) * ProjectConstants.K_AUDIORATE);
                break;
            case ENUM_MIXER_GROUP_NAME.MUSIC:
                    mixer.SetFloat(mixerName, SaveData.Load_MixerMusic() == 0
                    ? -ProjectConstants.K_AUDIO_RATE_MUTE : Mafthf.Log10(SaveData.Load_MixerMusic()) * ProjectConstants.K_AUDIORATE);
                break;
            case ENUM_MIXER_GROUP_NAME.SFX:
                    mixer.SetFloat(mixerName, SaveData.Load_MixerSFX() == 0
                    ? -ProjectConstants.K_AUDIO_RATE_MUTE : Mafthf.Log10(SaveData.Load_MixerSFX()) * ProjectConstants.K_AUDIORATE);
                break;
            case ENUM_MIXER_GROUP_NAME.SFX_GAME:
                    mixer.SetFloat(mixerName, SaveData.Load_MixerGameSFX() == 0
                    ? -ProjectConstants.K_AUDIO_RATE_MUTE : Mafthf.Log10(SaveData.Load_MixerGameSFX()) * ProjectConstants.K_AUDIORATE);
                break;
            case ENUM_MIXER_GROUP_NAME.SFX_UI:
                        mixer.SetFloat(mixerName, SaveData.Load_MixerGUISFX() == 0
                    ? -ProjectConstants.K_AUDIO_RATE_MUTE : Mafthf.Log10(SaveData.Load_MixerGUISFX()) * ProjectConstants.K_AUDIORATE);
                break;
        }
             
             */
        }

        public void SetAudioSourceVol(AudioSource audioSource, float value) {
            throw new System.NotImplementedException();
        }

        public void SetAudioSourcePitch(AudioSource audioSource, float value) {
            throw new System.NotImplementedException();
        }

        public void SetAudioSourcePan(AudioSource audioSource, float value) {
            throw new System.NotImplementedException();
        }

        public void SetAudioSourceFadeIn(AudioSource audioSource, float fadeTime) {
            //if (isFadeIn == false) StartCoroutine(MusicFadeInRoutine(fadeTime, isForced)); 
            //else Debug.Log(this.name + ": Already fading in!"); 
        }

        public void SetAudioSourceFadeOut(AudioSource audioSource, float fadeTime) {
            //if (isFadeOut == false) StartCoroutine(MusicFadeOutRoutine(fadeTime)); 
            //else Debug.Log(this.name + ": Already fading out!"); 
        }

        IEnumerator ScheduleAudioSourceFadeIn(AudioSource audioSource, float fadeTime) {
            float elapsedTime = 0f;

            audioSource.volume = 0;

            isFadeIn = true;

            while (isFadeIn) {

                if (audioSource.volume >= 0.99f) {
                    audioSource.volume = 1f;
                    isFadeIn = false;
                    break;
                }

                elapsedTime += Time.unscaledDeltaTime;

                float t = elapsedTime / fadeTime;

                yield return null; audioSource.volume = Mathf.Lerp(0, 1, t);
            }
        }        

        IEnumerator ScheduleAudioSourceFadeOut(AudioSource audioSource, float fadeTime) {
            float elapsedTime = 0f;

            isFadeOut = true;

            while (isFadeOut) {
                if (audioSource.volume <= 0.01f) {
                    audioSource.volume = 0f;
                    isFadeOut = false;
                    break;
                }

                elapsedTime += Time.unscaledDeltaTime;

                float t = elapsedTime / fadeTime;

                yield return null; audioSource.volume = Mathf.Lerp(1, 0, t);
            }
        }        

        public void SetMixerMute(ENUM_AUDIOMIXER_TYPE type, bool status) { }
    }
}

