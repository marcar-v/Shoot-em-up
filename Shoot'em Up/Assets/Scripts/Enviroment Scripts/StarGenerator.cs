using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGenerator : MonoBehaviour
{
    [SerializeField] GameObject star;
    [SerializeField] int maxStars;

    Color[] starColor =
        {
        new Color (0.5f, 0.5f, 1f), //blue
        new Color (0f, 1f, 1f), //green
        new Color (1f, 1f, 0f), //yellow
        new Color (1f, 0f, 0f), //red
        };

    void Start()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        for (int i = 0; i < maxStars; i++)
        {
            GameObject stars = (GameObject)Instantiate(star);

            stars.GetComponent<SpriteRenderer>().color = starColor[i % starColor.Length];

            stars.transform.position = new Vector2(Random.Range(min.x, max.x), Random.Range(min.y,max.y));

            stars.GetComponent<StarsController>().speed = -(1f * Random.value + 0.5f);

            stars.transform.parent = transform;
        }
    }
}
