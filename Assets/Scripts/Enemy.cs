using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    private Vector2 movement;
    [SerializeField] private float moveSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.transform.position - transform.position;
        direction.Normalize();
        movement = direction;
        //transform.Translate(movement * (moveSpeed * Time.deltaTime));
        
        _rigidbody2D.MovePosition(transform.position+(direction * (moveSpeed * Time.deltaTime)));
    }
}
