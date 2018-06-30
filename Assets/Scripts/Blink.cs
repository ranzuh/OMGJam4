using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour {
    
    [SerializeField]
    bool rotate;
    [SerializeField]
    [Range(0,1)]
    float rotateSpeed;

    [SerializeField]
    bool fade;
    [SerializeField]
    bool fade2;
    [SerializeField]
    bool changeColor;
    
    void Update() {

        Color newColor = GetComponent<SpriteRenderer>().material.color;

        if (fade) { 
            newColor.a = Mathf.Lerp(0.5f, 0.75f, Mathf.Sin(Time.time * Mathf.PI));
            GetComponent<SpriteRenderer>().material.color = newColor;
        }
        if (fade2) { 
            newColor.a = Mathf.Lerp(0.5f, 0.75f, (Mathf.Sin(Time.time * Mathf.PI)+1)/2);
            GetComponent<SpriteRenderer>().material.color = newColor;
        }
        if(rotate)
            transform.Rotate(new Vector3(0,0,rotateSpeed));

        if (changeColor) {
            newColor.r = Mathf.Abs(Mathf.LerpUnclamped(0.25f, 0.75f, Mathf.Cos(Time.time)));
            newColor.g = Mathf.Lerp(0.25f, 0.75f, Mathf.Sin(Time.time * Mathf.PI));
            newColor.b = Mathf.Abs(Mathf.LerpUnclamped(0.5f, 0.75f, Mathf.Cos(Time.time/2)));
            GetComponent<SpriteRenderer>().material.SetColor("_Color", newColor);
        }
	}
}
