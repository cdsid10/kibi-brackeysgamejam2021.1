using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = Unity.Mathematics.Random;
using UnityEngine.Experimental.Rendering.LWRP;
using Light2D = UnityEngine.Experimental.Rendering.Universal.Light2D;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Bult _bult;
    
    private Rigidbody2D _rigidbody2D;
    [SerializeField] private Animator _animator;
    [SerializeField]private SpriteRenderer _spriteRenderer;

    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform offset, offset2, offset3, offset4;
    [HideInInspector] public bool isMoving, flipX, canMove, canShoot;

    public int totalKibi;

    [SerializeField] private Light2D _light2D;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        totalKibi = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            canMove = false;
            canShoot = true;
            _rigidbody2D.velocity = Vector2.zero;
            _animator.SetBool("isRunning", false);
            if (canShoot)
            {
                _bult.gameObject.SetActive(true);
                
            }
        }
        else
        {
            canMove = true;
            canShoot = false;
            _bult.gameObject.SetActive(false);
        }
        
        if(canMove)
        {
            MoveAnim();
        }

        if (totalKibi == 1)
        {
            _light2D.intensity = 0.7f;
        }
        else if (totalKibi == 2)
        {
            _light2D.intensity = 0.8f;
        }
        else if (totalKibi == 3)
        {
            _light2D.intensity = 0.9f;
        }

    }


    private void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveX, moveY);

        if (movement.sqrMagnitude > 1)
        {
            movement.Normalize();
        }

        if (canMove)
        {
            _rigidbody2D.velocity = movement * (Time.deltaTime * moveSpeed);
        }
        //_rigidbody2D.AddForce(movement * (Time.deltaTime * moveSpeed), ForceMode2D.Impulse);
    }

    void MoveAnim()
    {
        if (Input.GetAxis("Horizontal") < 0)
        {
            flipX = true;
            _spriteRenderer.flipX = true;
            //offset.transform.position = transform.position + new Vector3(1,0,0);
            offset.transform.position = Vector3.MoveTowards(offset.transform.position, transform.position + new Vector3(1f,UnityEngine.Random.Range(-0.25f, 0.25f),0), Time.deltaTime * 2f);
            offset2.transform.position = Vector3.MoveTowards(offset2.transform.position, transform.position + new Vector3(1.65f,UnityEngine.Random.Range(-0.25f, 0.25f),0), Time.deltaTime * 2.5f);
            offset3.transform.position = Vector3.MoveTowards(offset3.transform.position, transform.position + new Vector3(2.25f,UnityEngine.Random.Range(-0.25f, 0.25f),0), Time.deltaTime * 3f);
            offset4.transform.position = Vector3.MoveTowards(offset4.transform.position, transform.position + new Vector3(2.85f,UnityEngine.Random.Range(-0.25f, 0.25f),0), Time.deltaTime * 3.5f);
            //offset5.transform.position = Vector3.MoveTowards(offset5.transform.position, transform.position + new Vector3(3.45f,UnityEngine.Random.Range(-0.25f, 0.25f),0), Time.deltaTime * 4f);
        }
        else
        {
            flipX = false;
            _spriteRenderer.flipX = false;
            //offset.transform.position = transform.position + new Vector3(-1,0,0);
            offset.transform.position = Vector3.MoveTowards(offset.transform.position, transform.position + new Vector3(-1f,UnityEngine.Random.Range(-0.25f, 0.25f),0), Time.deltaTime * 2f);
            offset2.transform.position = Vector3.MoveTowards(offset2.transform.position, transform.position + new Vector3(-1.65f,UnityEngine.Random.Range(-0.25f, 0.25f),0), Time.deltaTime * 2.5f);
            offset3.transform.position = Vector3.MoveTowards(offset3.transform.position, transform.position + new Vector3(-2.25f,UnityEngine.Random.Range(-0.25f, 0.25f),0), Time.deltaTime * 3f);
            offset4.transform.position = Vector3.MoveTowards(offset4.transform.position, transform.position + new Vector3(-2.85f,UnityEngine.Random.Range(-0.25f, 0.25f),0), Time.deltaTime * 3.5f);
            //offset5.transform.position = Vector3.MoveTowards(offset5.transform.position, transform.position + new Vector3(-3.45f,UnityEngine.Random.Range(-0.25f, 0.25f),0), Time.deltaTime * 4f);
        }
        
        

        if (Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0 || Input.GetAxis("Vertical") > 0 || Input.GetAxis("Vertical") < 0)
        {
             isMoving = true;
            _animator.SetBool("isRunning", true);
        }
        else
        {
            isMoving = false;
            _animator.SetBool("isRunning", false);
        }
    }
}
