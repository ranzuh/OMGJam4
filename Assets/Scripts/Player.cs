using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Player : MonoBehaviour {

    Rigidbody2D rigidbody;
    [SerializeField]
    Vector2 momentum;

    // Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        momentum = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0)) {
            Debug.Log("dsaf");
            rigidbody.AddForce(100*momentum);
        }
        //rigidbody.AddForce(Input.mousePosition);
    }
}
