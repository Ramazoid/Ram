using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Item: MonoBehaviour
{
    public float speed;
    private SpriteSet sriteset;
    public float StartY = 5;
    private Game game;

    // Start is called before the first frame update
    void Start()
    {

        SetStartPositionAndScale();
        sriteset = GetComponent<SpriteSet>();
        sriteset.SetSprite();
        speed = Random.Range(0.001f, 0.05f);
        game = GameObject.FindObjectOfType<Game>();
        


    }

    private void SetStartPositionAndScale()
    {
        transform.position = new Vector3(0,StartY, 0);
        float scale = Random.Range(1f, 1.5f);


     //   transform.localScale = new Vector3(scale, scale, scale);

    }

    // Update is called once per frame
    void Update()
    {
        //sriteset.sr.sortingOrder = 5;
        {
            transform.position += new Vector3(0, -Game.ItemSpeed, 0);

            if (transform.position.y <= -10)
            {
                RestartNext();

            }
        }

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("**************************COLLISION"+ col.gameObject.name);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        RestartNext();
      //  Debug.Log("**************************COLLISION Trigger***"+ col.gameObject.name);
    }

    private void RestartNext()
    {
        sriteset.NextSprite();
        SetStartPositionAndScale();
        game.EarnCoins();
        
    }
}