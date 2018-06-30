using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour {

    public float curTime = 0;
	// Update is called once per frame
	void Update () {
        Color c = GetComponent<SpriteRenderer>().material.GetColor("_Color");
        
        curTime += Time.deltaTime;
        Debug.Log(Mathf.Lerp(0, 1, curTime / 1000));
        Color newColor = new Color(c.r, c.g, c.b, Mathf.Lerp(0.5f, 0.75f, Mathf.Sin(curTime*Mathf.PI)));
        GetComponent<SpriteRenderer>().material.SetColor("_Color", newColor);

        transform.Rotate(new Vector3(0,0,0.5f));
	}
}
