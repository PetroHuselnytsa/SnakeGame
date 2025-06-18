using NAudio.Wave;


namespace SnakeGame.Audio
{
    public class WavSoundManager : ISoundManager
    {
        private static WaveOutEvent? _outputDevice;
        private static WaveFileReader? _waveFileReader;
        public void PlaySound(string soundFileName)
        {
            _waveFileReader = new WaveFileReader($"Game Sounds/{soundFileName}");
            _outputDevice = new WaveOutEvent();
            _outputDevice.Init(_waveFileReader);
            _outputDevice.Play();
        }
    }
}