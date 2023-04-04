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

namespace APIAudioManager_Mar21st2023 {
    public interface IAudioManager {
        //Get Functions
        public UnityEngine.AudioClip GetAudioClip();
        
        //Play Audio Functions
        public void PlayMusic(ENUM_AUDIO_MUSIC_TYPE type, bool isRandom = false);
        public void PlaySFX_GUI(ENUM_AUDIO_GUI_TYPE type, bool isRandom = false);
        public void PlaySFX_Game(ENUM_AUDIO_GAME_TYPE type, bool isRandom = false);
        public void PlayAudio(UnityEngine.AudioClip audioClip, UnityEngine.Audio.AudioMixerGroup audioMixer);
        public void PlayAudio(int index, UnityEngine.AudioClip[] audioClips, UnityEngine.Audio.AudioMixerGroup audioMixer);

        //Audio Source Functions
        public void SetAudioSourceVol(UnityEngine.AudioSource audioSource, float value);
        public void SetAudioSourcePitch(UnityEngine.AudioSource audioSource, float value);
        public void SetAudioSourcePan(UnityEngine.AudioSource audioSource, float value);
        public void SetAudioSourceFadeIn(UnityEngine.AudioSource audioSource, float fadeTime);
        public void SetAudioSourceFadeOut(UnityEngine.AudioSource audioSource, float fadeTime);

        //Mixer Functions
        public void SetMixerVol(ENUM_AUDIOMIXER_TYPE type, float value);
        public void SetMixerMute(ENUM_AUDIOMIXER_TYPE type, bool status);

        //Other
        public UnityEngine.AudioSource CreateAudioObject();
    }
}

