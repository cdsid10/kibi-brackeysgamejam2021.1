using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private AudioClip bass, interact, pillarTrap, pillar, trigger, home;
    
    // Start is called before the first frame update
    void Start()
    {
        _audioSource.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayBass()
    {
        _audioSource.PlayOneShot(bass);
    }

    public void PlayInteract()
    {
        _audioSource.PlayOneShot(interact);
    }

    public void PlayPillarTrap()
    {
        _audioSource.PlayOneShot(pillarTrap);
    }

    public void PlayPillar()
    {
        _audioSource.PlayOneShot(pillar);
    }

    public void PlayTrigger()
    {
        _audioSource.PlayOneShot(trigger);
    }

    public void PlayHome()
    {
        _audioSource.PlayOneShot(home);
    }
}
