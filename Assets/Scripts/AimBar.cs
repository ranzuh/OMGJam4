using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimBar : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        transform.localScale = new Vector3(Mathf.Min(5+Vector2.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.position),10),1,22);

        if(Input.GetMouseButtonDown(0))
            Destroy(this.gameObject);
    }
}
