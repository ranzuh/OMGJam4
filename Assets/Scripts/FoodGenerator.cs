using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodGenerator : MonoBehaviour {

    [SerializeField]
    Sprite[] sprites;

    [SerializeField]
    private int minFieldSize = 5;
    [SerializeField]
    private int maxFieldSize = 25;

    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
        float newSize = Random.Range(minFieldSize, maxFieldSize);
        transform.GetChild(0).localScale = new Vector3(newSize, newSize, 1);
    }

}
