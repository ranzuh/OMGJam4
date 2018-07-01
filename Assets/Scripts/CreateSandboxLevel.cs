using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSandboxLevel : MonoBehaviour {

    [SerializeField]
    int foods = 50;
    [SerializeField]
    int radius = 40;
    [SerializeField]
    GameObject food;

	// Use this for initialization
	void Start () {
        for (int i = 0; i < foods; i++) {
            Vector2 position = UnityEngine.Random.insideUnitCircle;
            Instantiate(food, new Vector3(position.x, position.y, 0)*radius, Quaternion.identity);
        }
        Destroy(gameObject);
    }

}
