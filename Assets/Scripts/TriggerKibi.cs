using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerKibi : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private AudioManager _audioManager;
    
    [SerializeField] private GameObject afroKibi, silhouette, revealCanvas;

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
                StartCoroutine(RevealCanvas());
            }
            
        }
    }
    
    IEnumerator RevealCanvas()
    {
        _audioManager.PlayTrigger();
        yield return new WaitForSeconds(0.25f);
        revealCanvas.SetActive(true);
        afroKibi.SetActive(true);
        _playerMovement.totalKibi++;
        yield return new WaitForSeconds(4);
        revealCanvas.SetActive(false);
        Destroy(gameObject);
        Destroy(silhouette.gameObject);
        
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player Orb"))
        {
            silhouette.SetActive(true);
            canInteract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player Orb"))
        {
            silhouette.SetActive(false);
            canInteract = false;
        }
    }
}
