//Manage and run all types of audio in game
//(c) hoanglongplanner & Vinh

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

//ADD LIBRARY
using AudioManagerV00_Mar21st2023;

namespace AudioManagerV00_Mar21st2023 {
    public enum ENUM_MIXER_TYPE {
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
        CLICK,
        CANCEL
    }

    public enum ENUM_AUDIO_GAME_TYPE {
        ENEMY_DEATH,
        EXPLOSION,
    }    

    public class AudioManagerSettings {
        public const bool K_IS_AUDIO_PLAY = false; //def: false
    }

    public class AudioManager : MonoBehaviour, IAudioManager {
        public AudioMixerGroup[] m_sz_audioMixer;
        public AudioClip[] m_sz_audioMusic;
        public AudioClip[] m_sz_audioGUI;        
        public AudioClip[] m_sz_audioGame;

        public void PlayMusic(ENUM_AUDIO_MUSIC_TYPE type) {
            switch (type) {
                case ENUM_AUDIO_MUSIC_TYPE.MENU:
                    break;
                case ENUM_AUDIO_MUSIC_TYPE.GAMEPLAY:
                    break;
                case ENUM_AUDIO_MUSIC_TYPE.GAMEOVER:
                    break;                
            }
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
        }        

        public void PlaySFX_Game(ENUM_AUDIO_GAME_TYPE type) {
            switch (type) {
                case ENUM_AUDIO_GAME_TYPE.ENEMY_DEATH:
                    break;
                case ENUM_AUDIO_GAME_TYPE.EXPLOSION:
                    break;
            }
        }

        public void PlayAudio(int index, AudioClip[] audioClips, AudioMixerGroup audioMixer) {
            throw new System.NotImplementedException();
        }

        public UnityEngine.GameObject CreateAudioObject() {
            UnityEngine.GameObject newObject = null;
            return newObject;
        }
    }
}

