using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndArea : MonoBehaviour {

    [SerializeField]
    GameObject field;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
            if (collision.gameObject.GetComponent<Player>().CheckWin()) {
                GameObject go = Instantiate(field);
                go.transform.position = transform.position;
                go.GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
            }
    }

    
}
