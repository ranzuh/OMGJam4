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
                StartCoroutine("ShrinkPlayer");
            }
    }

    IEnumerator ShrinkPlayer() {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        int frames = 0;
        float target = 256;
        while(frames < target)
        {
            player.GetComponent<Rigidbody2D>().drag += 0.1f;
            player.transform.localScale = Vector3.Lerp(player.transform.localScale, Vector3.zero, frames/target);
            if (Vector3.Distance(player.transform.localScale, Vector3.zero) < 0.1f)
                break;
            frames++;
            yield return null;
        }
        player.transform.localScale = Vector3.zero;
        player.GetComponent<Rigidbody2D>().drag = 1000;
        GetComponent<Animator>().enabled = true;
        StopCoroutine("ShrinkPlayer");
        yield return null;
    }
}
