using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    
    int foodCount = 0;

    [SerializeField]
    AudioClip collisionSound;

    [SerializeField]
    GameObject[] food;

    [SerializeField]
    GameObject finish;

    Text text;

    void Start() {
        food = GameObject.FindGameObjectsWithTag("MustEat");
        finish = GameObject.FindGameObjectWithTag("Finish");

        text = GameObject.Find("Scoretext").GetComponent<Text>();
        SetScoreText();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        GameObject collidedFood = col.gameObject;
        Destroy(col.gameObject);
        foodCount++;
        SetScoreText();
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = collisionSound;
        audio.Play();

        List<GameObject> foodList = new List<GameObject>(food);

        if(finish == null)
            CheckWin();

        foodList.Remove(collidedFood);

        food = foodList.ToArray();
        
    }

    public void CheckWin()
    {
        List<GameObject> foodList = new List<GameObject>(food);

        if (food.Length == 0)
        {
            GameManager.Instance.Win();
        }

    }

    void SetScoreText() {
        text.text = "Score: " + foodCount.ToString();
    }

}
