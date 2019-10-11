using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class SpriteSet: MonoBehaviour
{
    public Sprite[] sprites;
    public SpriteRenderer sr;
    public int index = 0;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.color= new Color(1,1,1,UnityEngine.Random.Range(0,1f));
        

    }

    void Update()
    {

    }
    public void SetSprite(int ind=0)
    {

        index = ind;
        sr.sprite = sprites[index];
        sr.sortingOrder = UnityEngine.Random.Range(0, 10);
    }

    public void NextSprite()
    {
        if (++index >= sprites.Length)
            index = 0;
        
        SetSprite();

    }
    
}
