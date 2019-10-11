using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Waves: MonoBehaviour
{
    public float speed;
    private SpriteSet sriteset;
    public float StartY = 5;

    // Start is called before the first frame update
    void Start()
    {

        SetStartPositionAndScale();
        sriteset = GetComponent<SpriteSet>();
        sriteset.SetSprite(Random.Range(1,2));
        speed = Random.Range(0.001f, 0.005f);


    }

    private void SetStartPositionAndScale()
    {
        transform.position = new Vector3(Random.Range(0, 5), Random.Range(StartY,StartY*2), 0);
        float scale = Random.Range(1f, 2f);


        transform.localScale = new Vector3(scale, scale, scale);

    }

    // Update is called once per frame
    void Update()
    {
        sriteset.sr.sortingOrder = 0;
        {
            transform.position += new Vector3(0, -speed, 0);

            if (transform.position.y <= 0)
            {
                sriteset.NextSprite();
                SetStartPositionAndScale();

            }
        }

    }
}