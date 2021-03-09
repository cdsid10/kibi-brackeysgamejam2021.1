using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushTrap : MonoBehaviour
{
    [SerializeField] private ActivatingColliderTraps _activatingColliderTraps;
    
    [SerializeField] private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Push());
    }

    // Update is called once per frame
    void Update()
    {
        //InvokeRepeating("PushBitch", 0, 1.5f);
        
        
    }

    IEnumerator Push()
    {
        if (_activatingColliderTraps.animStarted)
        {
            _animator.SetTrigger("isTriggered");
            yield return new WaitForSeconds(2);
            _animator.ResetTrigger("isTriggered");
            yield return new WaitForSeconds(2);

            StartCoroutine(Push());
        }
    }

    void PushBitch()
    {
        if (_activatingColliderTraps.animStarted)
        {
            _animator.SetTrigger("isTriggered");

        }
    }
    
}
