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

