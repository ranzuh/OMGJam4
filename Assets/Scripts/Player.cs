using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Player : MonoBehaviour {
    
    int foodCount = 0;

    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(col.gameObject);
        foodCount++;
        Debug.Log(foodCount);
    }
}
