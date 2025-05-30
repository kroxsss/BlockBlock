using UnityEngine;

public class BackGround : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip backgroundSound;

    public void Start()
    {
        audioSource.clip = backgroundSound;
        audioSource.Play();
    }
}