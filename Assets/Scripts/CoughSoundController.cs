using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoughSoundController : MonoBehaviour
{
    public List<AudioClip> sounds;
    public AudioSource audio1;
    public AudioSource audio2;

    void Start()
    {
        List<AudioClip> soundsTMP = new List<AudioClip>();
        soundsTMP.AddRange(sounds);
        int index = Random.Range(0, soundsTMP.Count);
        audio1.clip = soundsTMP[index];
        audio1.Play();
        StartCoroutine(ControllAudio1(audio1.clip.length));
        soundsTMP.RemoveAt(index);
        audio2.clip = soundsTMP[Random.Range(0, soundsTMP.Count)];
        audio2.Play();
        StartCoroutine(ControllAudio2(audio2.clip.length));
    }

    IEnumerator ControllAudio1(float time)
    {
        yield return new WaitForSeconds(time);
        audio1.clip = sounds[Random.Range(0, sounds.Count)];
        audio1.Play();
        StartCoroutine(ControllAudio1(audio1.clip.length));
    }

    IEnumerator ControllAudio2(float time)
    {
        yield return new WaitForSeconds(time);
        audio2.clip = sounds[Random.Range(0, sounds.Count)];
        audio2.Play();
        StartCoroutine(ControllAudio2(audio2.clip.length));
    }
}
