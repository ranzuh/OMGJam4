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

    GameObject[] wall;

    [SerializeField]
    GameObject finish;

    [SerializeField]
    GameObject panel;


    Text text;

    void Start() {
        food = GameObject.FindGameObjectsWithTag("MustEat");
        wall = GameObject.FindGameObjectsWithTag("Wall");
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
        if(col.gameObject.tag == "MustEat") {
            GameObject collidedFood = col.gameObject;
            List<GameObject> foodList = new List<GameObject>(food);
            foodList.Remove(collidedFood);
            food = foodList.ToArray();

            foodCount++;
            SetScoreText();

            if (finish == null)
                CheckWin();
        }
        
        Destroy(col.gameObject);
        
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = collisionSound;
        audio.Play();

    }

    public bool CheckWin()
    {
        if (food.Length == 0)
        {
            Win();
            return true;
        }
        return false;
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

    private void OnBecameInvisible()
    {
        if (gameObject.activeInHierarchy) {
            StartCoroutine("FollowPlayer");
            
        }
    }
    void SetScoreText() {
        text.text = "Score: " + foodCount.ToString();
    }

    void NextScene() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    IEnumerator FollowPlayer() {
        Vector3 pos = transform.position;
        pos.z = Camera.main.transform.position.z;
        Camera.main.transform.position = pos;
        yield return null;
    }
}
