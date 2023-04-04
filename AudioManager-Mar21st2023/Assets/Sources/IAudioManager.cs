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
        public void PlayMusic(ENUM_AUDIO_MUSIC_TYPE type);
        public void PlaySFX_GUI(ENUM_AUDIO_GUI_TYPE type);
        public void PlaySFX_Game(ENUM_AUDIO_GAME_TYPE type);
        public void PlayAudio(int index, UnityEngine.AudioClip[] audioClips, UnityEngine.Audio.AudioMixerGroup audioMixer);
        public void SetAudioObjectVol(UnityEngine.AudioSource audioSource, float value);
        public void SetAudioObjectPitch(UnityEngine.AudioSource audioSource, float value);
        public void SetAudioObjectPan(UnityEngine.AudioSource audioSource, float value);
        public void SetMixerVol(ENUM_AUDIOMIXER_TYPE type, float value);
        public UnityEngine.AudioSource CreateAudioObject();
    }
}

