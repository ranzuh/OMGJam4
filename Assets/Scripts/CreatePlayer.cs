using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlayer : MonoBehaviour {

    [SerializeField]
    GameObject player;

	// Update is called once per frame
	void Update () {
        this.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0)) {
            GameObject obj = Instantiate(player);
            obj.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
            Destroy(this.gameObject);
        }
	}
}
