﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Player : MonoBehaviour {
    
    [SerializeField]
    private int multiplier = 5;
    
    int foodCount = 0;

    void Update() {
        Vector2 direction = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float distance = -Vector2.Distance(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
        if (Input.GetMouseButtonDown(0)) {
            Destroy(this);
            GetComponent<Rigidbody2D>().AddForce(multiplier * distance * direction);
        }
        //rigidbody.AddForce(Input.mousePosition);

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(col.gameObject);
    }
}
