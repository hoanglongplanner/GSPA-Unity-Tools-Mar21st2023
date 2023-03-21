namespace AudioManagerV00_Mar21st2023 {
    public interface IAudioManager {
        public void PlayMusic(ENUM_AUDIO_MUSIC_TYPE type);
        public void PlaySFX_GUI(ENUM_AUDIO_GUI_TYPE type);
        public void PlaySFX_Game(ENUM_AUDIO_GAME_TYPE type);
        public void PlayAudio(int index, UnityEngine.AudioClip[] audioClips, UnityEngine.Audio.AudioMixerGroup audioMixer);
    }
}

