using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    private AudioSource _audioSource;
    public AudioClip deathSFX;
    public AudioClip bombaSFX;
    public AudioClip estrellaSFX;
    public AudioClip vidaSFX;
    public AudioClip victoriaSFX;


    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void DeathSound()
   {
       _audioSource.PlayOneShot(deathSFX);
   }

   public void TocasBomba()
   {
       _audioSource.PlayOneShot(bombaSFX);
   }

   public void RecogerEstrella()
   {
       _audioSource.PlayOneShot(estrellaSFX);
   }

   public void SumaVida()
   {
       _audioSource.PlayOneShot(vidaSFX);
   }

   public void EstrellasVictoria()
   {
        _audioSource.PlayOneShot(victoriaSFX);
   }

}
