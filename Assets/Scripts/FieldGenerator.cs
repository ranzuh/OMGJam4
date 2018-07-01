using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldGenerator : MonoBehaviour {

    [SerializeField]
    GameObject field;

	// Use this for initialization
	void Start () {
        GameObject go = Instantiate(field);
        go.transform.parent = transform;
        go.transform.position = new Vector3(0,0,0);
	}
	

}
