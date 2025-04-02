using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSlider : MonoBehaviour
{
    private void Mute()
    {
        SoundManager.Instance.SetAudioMute(EAudioMixerType.BGM);
    }

    private void ChangeVolume(float volume)
    {
        SoundManager.Instance.SetAudioVolume(EAudioMixerType.BGM, volume);
    }

}
