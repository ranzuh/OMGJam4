using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
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
        foodList.Remove(collidedFood);
        food = foodList.ToArray();

        if (finish == null)
            CheckWin();

    }

    public void CheckWin()
    {
        if (food.Length == 0)
        {
            GameManager.Instance.GetComponent<GameManager>().Win();
        }
    }

    void SetScoreText() {
        text.text = "Score: " + foodCount.ToString();
    }

}
