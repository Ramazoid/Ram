using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ram : MonoBehaviour
{
    public float moveStep;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
       
    }

    private void MoveRam(bool left)
    {
        if(left)
            transform.position+=new Vector3(-moveStep,0,0);
        else
            transform.position+=new Vector3(moveStep,0,0);
    }
}
