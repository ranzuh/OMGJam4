using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    
    int foodCount = 0;

    Text text;

    void Start() {
        text = GameObject.Find("Scoretext").GetComponent<Text>();
        SetScoreText();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(col.gameObject);
        foodCount++;
        SetScoreText();
    }

    void SetScoreText() {
        text.text = "Score: " + foodCount.ToString();
    }
}
