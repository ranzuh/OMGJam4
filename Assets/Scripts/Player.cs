using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    
    int foodCount = 0;

    [SerializeField]
    AudioClip collisionSound;

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
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = collisionSound;
        audio.Play();

    }

    void SetScoreText() {
        text.text = "Score: " + foodCount.ToString();
    }
}
