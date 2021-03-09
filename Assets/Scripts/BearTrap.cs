using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearTrap : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    
    public bool deactivated;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (deactivated)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _animator.SetTrigger("TrapTriggered");
        deactivated = true;
        if (deactivated)
        {
            this.GetComponent<CircleCollider2D>().enabled = false;
        }
    }
}
