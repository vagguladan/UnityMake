using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.Audio;
using UnityEngine.UI;


public enum EAudioMixerType {Matster, BGM, SFX}

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    [SerializeField] private AudioMixer _audioMixer;

    private bool[] _isMute = new bool[3];
    private float[] _audioVolumes = new float[3];
    private void Awake()
    {
        Instance = this;
    }


    public void SetAudioVolume(EAudioMixerType audioMixerType, float volume)
    {
        _audioMixer.SetFloat(audioMixerType.ToString(), Mathf.Log10(volume) * 20);
    }

    public void SetAudioMute(EAudioMixerType audioMixerType)
    {
        int type = (int)audioMixerType;
        if (!_isMute[type])
        {
            _isMute[type] = true;
            _audioMixer.GetFloat(audioMixerType.ToString(), out float curVolume);
            _audioVolumes[type] = curVolume;
            SetAudioVolume(audioMixerType, 0.001f);
        }
        else
        {
            _isMute[type] = false;
            SetAudioVolume(audioMixerType, _audioVolumes[type]);
        }
    }

    private void Mute()
    {
        SoundManager.Instance.SetAudioMute(EAudioMixerType.BGM);
    }

    private void ChangeVolume(float volume)
    {
        SoundManager.Instance.SetAudioVolume(EAudioMixerType.BGM, volume);
    }

}
