using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueUiTrigger : MonoBehaviour
{
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private GameObject uiCanvas, silhouette;

    private bool canInteract;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canInteract)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _audioManager.PlayInteract();
                uiCanvas.SetActive(true);
                
            }
        }
        
        if (!canInteract)
        {
            uiCanvas.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player Orb"))
        {
            canInteract = true;
            silhouette.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player Orb"))
        {
            canInteract = false;
            silhouette.SetActive(false);
        }
        
    }
}
