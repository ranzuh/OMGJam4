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

    [SerializeField]
    GameObject panel;


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
            Win();
        }
    }

    public void Win() {
        // WIN
        Debug.Log("VICTORY½");

        //Fade screen
        panel = Instantiate(panel);
        panel.transform.SetParent(GameObject.Find("Canvas").transform, false);
        panel.GetComponent<Transition>().FadeIn();
        
        Invoke("NextScene", 0.5f);
    }

    void SetScoreText() {
        text.text = "Score: " + foodCount.ToString();
    }

    void NextScene() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

}
