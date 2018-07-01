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
        if(col.gameObject.tag.Equals("MustEat")) {
            GameObject collidedFood = col.gameObject;
            List<GameObject> foodList = new List<GameObject>(food);
            foodList.Remove(collidedFood);
            food = foodList.ToArray();
        }
        

        foodCount++;
        SetScoreText();

        if (finish == null)
            CheckWin();
        
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
        StartCoroutine("EndLevel");
    }

    IEnumerator EndLevel()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        int frames = 0;
        float target = 256;
        while (frames < target)
        {
            player.GetComponent<Rigidbody2D>().drag += 0.1f;
            player.transform.localScale = Vector3.Lerp(player.transform.localScale, Vector3.zero, frames / target);
            if (Vector3.Distance(player.transform.localScale, Vector3.zero) < 0.1f)
                break;
            frames++;
            yield return null;
        }
        player.transform.localScale = Vector3.zero;
        player.GetComponent<Rigidbody2D>().drag = 1000;
        if(finish != null)
           finish.GetComponent<Animator>().enabled = true;
        yield return null;
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

    IEnumerator NextScene() {
        //Fade screen
        panel = Instantiate(panel);
        panel.transform.SetParent(GameObject.Find("Canvas").transform, false);
        yield return panel.GetComponent<Transition>().Fade();

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        StopCoroutine("EndLevel");
        SceneManager.LoadScene(currentSceneIndex + 1);


    }

    IEnumerator FollowPlayer() {
        Vector3 pos = transform.position;
        pos.z = Camera.main.transform.position.z;
        Camera.main.transform.position = pos;
        yield return null;
    }
}
