﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSC : MonoBehaviour
{
    public float maxSpeed;
    public float jumpPower;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //jump
        if(Input.GetButtonDown("Jump"))
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);

        //move Flip
        if(Input.GetButton("Horizontal"))
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
        if(Input.GetButtonUp("Horizontal")) 
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
    }


    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        
        rigid.AddForce(Vector2.right *h, ForceMode2D.Impulse);

        if(rigid.velocity.x > maxSpeed)//Right Max Speed
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        else if(rigid.velocity.x < maxSpeed*(-1))//Left Max Speed
            rigid.velocity = new Vector2(maxSpeed*(-1), rigid.velocity.y);
        
    }


}
