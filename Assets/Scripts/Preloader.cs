using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Preloader : MonoBehaviour
{
    private AudioSource audioPlayer;
    [Space]
    [Header("Sound Clips")]
    public AudioClip start;
    public AudioClip glitch;
    public AudioClip end;
    public AudioClip waitWhat;
    
    private void Start() {
        audioPlayer = GetComponent<AudioSource>();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlaySound(AudioClip clip)
    {
        audioPlayer.Stop();
        audioPlayer.clip = clip;
        audioPlayer.Play();
    }
}
