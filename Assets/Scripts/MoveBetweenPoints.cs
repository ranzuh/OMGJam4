using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBetweenPoints : MonoBehaviour {

     [SerializeField]
    GameObject[] endPoints;

    [SerializeField]
    float duration = 5;

    private int endPoint = 0;        
    private float targetTime;

    private void Start()
    {
        targetTime = duration;
    }
    // Update is called once per frame
    void FixedUpdate () {
        GameObject target = endPoints[endPoint % endPoints.Length];
        GameObject startPoint = endPoints[endPoint+1 % endPoints.Length];

        Vector2 realPos = target.transform.position;        
        Vector2 moveVector = Vector2.Lerp(startPoint.transform.position, realPos, (targetTime- Time.time)/duration);
        transform.position = moveVector;

        float dist = Vector3.Distance(realPos, startPoint.transform.position);
        if (dist < 0.1f)
        {
            targetTime = Time.time + duration;
            increaseEndPoint();
        }
    }

    public void increaseEndPoint() {
        endPoint++;
    }
}
