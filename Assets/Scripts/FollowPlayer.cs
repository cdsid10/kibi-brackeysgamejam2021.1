using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] public Animator _animator;
    public Transform leader;
    public float followSharpness = 0.05f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    void LateUpdate () {
        Vector3 random = new Vector3(Random.Range(-2, 2), Random.Range(-1, 1), 0);
        transform.position += (leader.position - transform.position) * followSharpness;
        
    }

    private void Update()
    {
        if (_playerMovement.flipX)
        {
            _spriteRenderer.flipX = true;
        }
        else
        {
            _spriteRenderer.flipX = false;
        }

        if (_playerMovement.isMoving && _playerMovement.canMove)
        {
            _animator.SetBool("isRunningNPC", true);
        }
        else
        {
            _animator.SetBool("isRunningNPC", false);
        }
    }
}