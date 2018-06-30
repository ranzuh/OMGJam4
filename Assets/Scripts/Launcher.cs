using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour {

    [SerializeField]
    private int multiplier = 5;

    [SerializeField]
    AudioClip boostSound;

    void Update()
    {
        Vector2 direction = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float distance = -Vector2.Distance(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
        distance = -Mathf.Clamp(distance, 1, 10);

        if (Input.GetMouseButtonDown(0))
        {
            Destroy(this);
            GetComponent<Rigidbody2D>().AddForce(multiplier * distance * direction);
            

            AudioSource audio = GetComponent<AudioSource>();
            audio.clip = boostSound;
            audio.Play();

        }
        //rigidbody.AddForce(Input.mousePosition);

    }
}
