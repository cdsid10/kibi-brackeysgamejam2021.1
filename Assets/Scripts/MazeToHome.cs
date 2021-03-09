using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeToHome : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private AudioManager _audioManager;

    public GameObject player;

    public Transform teleTarget;

    [SerializeField] private GameObject blacked;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (_playerMovement.totalKibi == 1 || _playerMovement.totalKibi == 2 || _playerMovement.totalKibi == 3 || _playerMovement.totalKibi == 4)
            {
                StartCoroutine(TeleportToHome());
                Invoke("TeleHome", 2f);
            }
        }
    }

    IEnumerator TeleportToHome()
    {
        _audioManager.PlayHome();
        yield return new WaitForSeconds(0.25f);
        blacked.SetActive(true);
        yield return new WaitForSeconds(2);
        blacked.SetActive(false);
    }

    void TeleHome()
    {
        player.transform.position = teleTarget.transform.position + new Vector3(0, 3.6f,0);
    }
    
}
