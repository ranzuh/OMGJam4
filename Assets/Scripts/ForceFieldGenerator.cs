using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceFieldGenerator : MonoBehaviour {

    [SerializeField]
    GameObject field;
    [SerializeField]
    private bool repulse = false;

    public int divider = 1;

    // Use this for initialization
    void Start () {
        StartCoroutine("GenerateFields");
	}
	
	// Update is called once per frame
	IEnumerator GenerateFields () {
        for (int i = 0; i < 4; i++) {
            GameObject go = Instantiate(field, transform);
            go.GetComponent<ForceField>().fieldScale = transform.GetChild(0).localScale.x/divider;
            go.GetComponent<ForceField>().transform.localPosition = Vector3.zero;
            go.GetComponent<ForceField>().repulse = repulse;
            go.GetComponent<ForceField>().enabled = true;            
            yield return new WaitForSeconds(2f);
        }
	}
}
