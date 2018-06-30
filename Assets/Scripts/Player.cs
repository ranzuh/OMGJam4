using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Player : MonoBehaviour {
    
    [SerializeField]
    private int multiplier = 5;

	// Update is called once per frame
	void Update () {
        Vector2 direction = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0)) {
            float distance = -Vector2.Distance(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
            GetComponent<Rigidbody2D>().AddForce(multiplier * distance * direction);
        }
        //rigidbody.AddForce(Input.mousePosition);
    }
}
