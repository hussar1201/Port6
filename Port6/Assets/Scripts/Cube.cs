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

    public float interval_change;
    private float timer = 0f;

    public Animator animator_clock;

    private void Start()
    {
        animator_clock.speed = 1 / interval_change;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += speed * transform.forward * Time.deltaTime;
        timer += Time.deltaTime;

        if (timer >= interval_change)
        {
            timer = 0f;
            ChangeRotationAndColor();
        }
    }


    private void ChangeRotationAndColor()
    {
        int num_color = Random.Range(0, 2);
        int num_rotation = Random.Range(0, 3);

        if (num_color == 0)
        {
            vlb.LineColor = Color.blue;
            is_cube_blue = true;
        }
        else
        {
            vlb.LineColor = Color.red;
            is_cube_blue = false;
        }

        switch (num_rotation)
        {
            case 0:
                break;
            case 1:
                transform.Rotate(new Vector3(0, 0, 90f));
                break;
            case 2:
                transform.Rotate(new Vector3(0, 0, -90f));
                break;
        }


    }

}


