using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VolumetricLines;

public class LightChanger : MonoBehaviour
{

    public VolumetricLineBehavior[] arr_vlb;
    public float time_change_min=2f;
    public float time_change_max=4f;



    private Color[] arr_Color =
    {Color.white,Color.black,Color.blue,Color.red,Color.blue,Color.magenta,Color.gray,Color.green,Color.grey,Color.yellow};



    private void Start()
    {
        StartCoroutine(ChangeColor());
    }



    IEnumerator ChangeColor()
    {
        while(true)
        {
            
            if(UIManager.instance.flag_start_game)
            { 
                Color color_tmp = arr_Color[Random.Range(0, arr_Color.Length)];

                for (int i = 0;i<arr_vlb.Length;i++)
                {
                    arr_vlb[i].LineColor = color_tmp;
                }
            }

            yield return new WaitForSeconds(Random.Range(time_change_min, time_change_max));
        }
    }




}
