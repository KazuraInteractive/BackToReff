﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Leg : Monster
{

    [SerializeField]
    private float speed = -2.0F;

    Vector3 originalPos;
    bool puk = false;

    [SerializeField]
    public GameObject p;

    private Vector3 direction;
    int v1 = 10;

    protected override void Start()
    {
        originalPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        direction = transform.up;
    }

    protected override void Update()
    {
        if (v1 <=0)
        {
            Move();

            if (puk == true)
            {
                gameObject.transform.position = new Vector3(originalPos.x, gameObject.transform.position.y);
                v1 = 10;
                puk = false;
            }
        }
        if (v1 > 0)
            v1--;
    }

    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Unit>();

        if (unit && unit is Character)
        {
            if (Mathf.Abs(unit.transform.position.y - transform.position.y) < 0.3F)
            {
                ReceiveDamage();
            }
            else
            {
                unit.ReceiveDamage();
            }
        }
    }

    private void Move()
    {
        Vector3 pik = new Vector3(transform.position.x , transform.position.y - 9);

        Collider2D[] colliders = Physics2D.OverlapCircleAll(pik, 0.1F);

        if (colliders.Length > 0 && colliders.All(y => !y.GetComponent<Character>()))
        {
            puk = true;
            direction *= -1.0F;
        }

        if(gameObject.transform.position.y >= originalPos.y)
            direction *= -1.0F;

        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }
}