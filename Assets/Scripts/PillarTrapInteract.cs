using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarTrapInteract : MonoBehaviour
{
    [SerializeField] private AudioManager _audioManager;
    
    [SerializeField] private SpikeAnim _spikeAnim;
    [SerializeField] private ActivatingColliderTraps _activatingColliderTraps;
    
    private bool canInteract, cannotInteract;

    [SerializeField] private GameObject duplicate, original, runes, silhouette;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canInteract && _activatingColliderTraps.animStarted)
        {
            silhouette.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                _audioManager.PlayPillarTrap();
                original.SetActive(false);
                duplicate.SetActive(true);
                runes.SetActive(true);
                cannotInteract = true;
            }
        }
        else
        {
            silhouette.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player Orb"))
        {
            canInteract = true;
            if (cannotInteract)
            {
                canInteract = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player Orb"))
        {
            canInteract = false;
        }
    }
}
