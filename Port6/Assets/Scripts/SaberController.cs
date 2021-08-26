using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaberController : MonoBehaviour
{
    public Saber saber_L;
    public Saber saber_R;


    private float timer = 0f;
    private float interval_input = .2f;


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (interval_input <= timer)

        {
            timer = 0f;
            if(InputController_XR.instance.Btn_X)
            {
                saber_L.ChangeColor();
            }
            if (InputController_XR.instance.Btn_A)
            {
                saber_R.ChangeColor();
            }
        }


    }
}
