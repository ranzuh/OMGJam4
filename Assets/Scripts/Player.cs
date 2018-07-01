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

    [SerializeField]
    GameObject PressRText;

    private int time = 5;
    Text text;

    void Start()
    {
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
        time = 5;
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
        if (finish != null)
        {
            int frames = 0;
            float target = 256;
            while (frames < target)
            {
                GetComponent<Rigidbody2D>().drag += 0.1f;
                transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, frames / target);
                if (Vector3.Distance(transform.localScale, Vector3.zero) < 0.1f)
                    break;
                frames++;
                yield return null;
            }
            transform.localScale = Vector3.zero;
            GetComponent<Rigidbody2D>().drag = 1000;
            finish.GetComponent<Animator>().enabled = true;
        }
        yield return NextScene();
    }

    private void OnBecameInvisible()
    {
        if (gameObject.activeInHierarchy) {
            StartCoroutine("FollowPlayer");
            
        }
    }
    void SetScoreText() {
        text.text = "Food Left: " + food.Length.ToString();
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

    IEnumerator CheckTime() {
        while (true) {
            yield return new WaitForSeconds(2);
            time -= 2;
            if (time < 0)
            {
                PressRText = Instantiate(PressRText);
                PressRText.transform.SetParent(GameObject.Find("Canvas").transform, false);
            }
            yield return null;
        }

    }
    
    void OnTriggerEnter2D(Collider2D col) {
        time = 5;
    }
    
}
