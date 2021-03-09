using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeAnim : MonoBehaviour
{
    [SerializeField] private ActivatingColliderTraps _activatingColliderTraps;
    [SerializeField] private Animator _animator;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_activatingColliderTraps.animStarted)
        {
            _animator.SetTrigger("isTriggered");
        }
    }
}
