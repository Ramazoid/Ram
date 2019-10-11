using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Clouds : MonoBehaviour
{
    public float speed;
    private SpriteSet sriteset;
    public float MinY = 6;
    public float MaxY = 8;
    public float StartX = -8;
 public float FinishX = 6;

    // Start is called before the first frame update
    void Start()
    {
        
        SetStartPositionAndScale();
        sriteset = GetComponent<SpriteSet>();
        sriteset.SetSprite();
        speed = Random.Range(0.001f, 0.05f);


    }

    private void SetStartPositionAndScale()
    {
        transform.position=new Vector3(StartX,Random.Range(MinY,MaxY),0);
        float scale = Random.Range(0.05f, 01f);
        
       transform.localScale = new Vector3(scale, scale, scale);

    }

    // Update is called once per frame
    void Update()
    {transform.position+=new Vector3(speed,0,0);

        if (transform.position.x >= FinishX)
        {
            sriteset.NextSprite();
            SetStartPositionAndScale();
            
        }
    }
    
}
