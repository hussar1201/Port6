using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VolumetricLines;

public class Cube : MonoBehaviour
{
    public float speed = 1f;
    public VolumetricLineBehavior vlb;
    public Collider collider_DirectionPointer;
    public bool is_cube_blue
    {
        get;
        private set;
    }


    // Start is called before the first frame update
    void Start()
    {
        vlb.LineColor = Color.blue;

        if(vlb.LineColor== Color.blue)
        {
            is_cube_blue = true;
        }
        else
        {
            is_cube_blue = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += speed * transform.forward * Time.deltaTime;
    }


}
