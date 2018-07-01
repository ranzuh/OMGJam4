using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheatcode : MonoBehaviour {

    LinkedList<string> input = new LinkedList<string>();

    [SerializeField]
    Sprite sprite;

	// Update is called once per frame
	void Update () {
        if (Input.inputString.Length > 0)
        {
            input.AddLast(Input.inputString);
            if (input.Count > 5)
                input.RemoveFirst();

            string code = "";
            foreach (string s in input) {
                code += s;
            }

            if (code.ToLower().Equals("salla")) {
                GetComponent<SpriteRenderer>().sprite = sprite;
            }
        }
	}
}
