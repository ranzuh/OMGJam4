using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBetweenPoints : MonoBehaviour {

     [SerializeField]
    GameObject[] endPoints;

    [SerializeField]
    float duration = 5000;

    private int startPoint = 0;        
    private float targetTime;

    private void Start()
    {
        targetTime = Time.time+duration;
    }
    // Update is called once per frame
    void FixedUpdate () {
        GameObject target = endPoints[(startPoint+1) % endPoints.Length];
        GameObject start = endPoints[startPoint % endPoints.Length];

        Vector2 realPos = target.transform.position;
        Vector2  moveVector = Vector2.Lerp(start.transform.position, realPos, 1-((targetTime - Time.time)/duration));
        transform.position = moveVector;

        float dist = Vector3.Distance(realPos, transform.position);
        if (dist < 0.1f)
        {
            targetTime = Time.time + duration;
            increaseStartPoint();
        }
    }

    public void increaseStartPoint() {
        startPoint++;
    }
}
