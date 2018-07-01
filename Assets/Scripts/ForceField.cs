using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceField : MonoBehaviour {

    public float fieldScale = 5;
    public float time;
    public bool repulse = false;

    private void Awake()
    {
        enabled = false;
    }

    void Start()
    {
        transform.localScale = Vector3.zero;
        StartCoroutine("MoveField");
    }

    IEnumerator MoveField () {
        float duration = 5;
        time = 0;
        Vector3 start;
        Vector3 finish;
        if (repulse)
        {            
            finish = new Vector3(fieldScale, fieldScale, fieldScale);
            start = Vector3.zero;
        }
        else {
            start = new Vector3(fieldScale, fieldScale, fieldScale);
            finish = Vector3.zero;
        }
        while (true) {
            transform.localScale = Vector3.Lerp(start, finish, time/duration);
            time += 0.01f;
            if (Vector3.Distance(transform.localScale, finish) <0.1f)
            {
                transform.localScale = start;
                time = 0;
            }
            yield return new WaitForSeconds(0.01f);
        }
	}
}
