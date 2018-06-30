using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartArea : MonoBehaviour {

    [SerializeField]
    GameObject playerPrefab;

	// Use this for initialization
	void OnMouseUp () {
        GameObject obj = Instantiate(playerPrefab);
        Vector3 v = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        obj.transform.position = new Vector3(v.x, v.y, 0);

        Destroy(this);
	}
}
