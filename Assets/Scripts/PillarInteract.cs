using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PillarInteract : MonoBehaviour
{
    [SerializeField] private AudioManager _audioManager;
    
    private bool canInteract, cannotInteract;
    
    public float timeRemaining;

    [SerializeField] private GameObject bridgeCollider, grassGrid, silhouette, runes, text, panel;
    
    
    
    // Update is called once per frame
    void Update()
    {
        
        if (canInteract)
        {
            silhouette.SetActive(true);
            if (Input.GetMouseButton(0))
            {
                text.SetActive(true);
                panel.SetActive(true);
                if (timeRemaining > 0)
                {
                    timeRemaining -= Time.deltaTime;
                }

                if (timeRemaining <= 0)
                {
                    runes.SetActive(true);
                    bridgeCollider.SetActive(false);
                    grassGrid.SetActive(true);
                    cannotInteract = true;
                    text.SetActive(false);
                    panel.SetActive(false);
                }
            }
        }
        else
        {
            silhouette.SetActive(false);
            runes.SetActive(false);
        }

        text.GetComponent<TextMeshProUGUI>().text = timeRemaining.ToString("F2");
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
