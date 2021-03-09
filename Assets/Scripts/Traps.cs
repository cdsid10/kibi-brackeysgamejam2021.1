using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour
{
    [SerializeField] private AudioManager _audioManager;
    public GameObject player;
    
    [SerializeField] private GameObject blacked;
    
    public Transform teleTarget;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator TeleportToHome()
    {
        _audioManager.PlayBass();
        yield return new WaitForSeconds(0.25f);
        blacked.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        blacked.SetActive(false);
    }

    void TeleHome()
    {
        player.transform.position = teleTarget.transform.position + new Vector3(0, 3.6f,0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Dead");
            StartCoroutine(TeleportToHome());
            Invoke("TeleHome", 1f);
            
        }
        
    }
}
