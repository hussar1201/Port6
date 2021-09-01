using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float interval_Max;
    public float interval_Min;

    private float interval = 0.0f;
    private float last_time_respawn = 0.0f;
    public GameObject prefab_cube;

    void Update()
    {
        if (UIManager.instance.is_menu_called || !UIManager.instance.flag_start_game) return;


        if(Time.time >= last_time_respawn + interval)
        {
            last_time_respawn = Time.time;
            interval = Random.Range(interval_Min, interval_Max);
            Vector3 CEP = new Vector3(Random.Range(-0.08f, 0.08f), Random.Range(-0.08f, 0.08f), 0);
            Instantiate(prefab_cube, transform.position + CEP, Quaternion.Euler(0f, 180f, 0f));
        }

    }

   


}
