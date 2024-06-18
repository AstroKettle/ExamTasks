using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioMixer _mixer;
    [SerializeField] private AudioSource _source;
    [SerializeField] List<AudioClip> _sounds;

    private int _currentClipIndex = 0;
    private float _step;

    private const string MasterVolume = "MasterVolume";
    private const float minVolume = 40f;

    void Start()
    {
        SetClip();
    }

    void Update ()
    {
        if (_source.isPlaying)
        {
            float masterVolume;
            _mixer.GetFloat(MasterVolume, out masterVolume);
            _mixer.SetFloat(MasterVolume, masterVolume - _step * Time.deltaTime);
        }
        else
        {
            _currentClipIndex = (_currentClipIndex + 1) % _sounds.Count;
            SetClip();
        }
    }

    private void SetClip()
    {
        _source.clip = _sounds[_currentClipIndex];
        _mixer.SetFloat(MasterVolume, 0);
        _step = minVolume / _source.clip.length;
        _source.Play();
    }
}
