using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VolumetricLines;

public class Cube : MonoBehaviour
{
    public float speed = 1f;
    public VolumetricLineBehavior vlb;
    public Collider collider_DirectionPointer;
    public Collider[] arr_colliders_child;
    private bool flag_is_hit;

    public float interval_Max=6f;
    public float interval_Min=3.5f;



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
        interval_change = Random.Range(interval_Min, interval_Max);
        animator_clock.speed = 1 / interval_change;
        flag_is_hit = false;
        speed = Random.Range(0.1f, 0.2f);
        arr_colliders_child = GetComponentsInChildren<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (UIManager.instance.is_menu_called || flag_is_hit) return;

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

    public void BlowUp()
    {
        if (!flag_is_hit)
        {
            flag_is_hit = true;
            StartCoroutine(ShowBlowUpEffect());
            Destroy(vlb.gameObject);
            Destroy(gameObject, 1.5f);
        }
    }



    IEnumerator ShowBlowUpEffect()
    {
        for (int i = 0; i < arr_colliders_child.Length; i++)
        {
            arr_colliders_child[i].enabled = true;

        }
        yield return new WaitForSeconds(0.1f);

        for (int i = 0; i < arr_colliders_child.Length; i++)
        {
            arr_colliders_child[i].enabled = false;

        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ComboBreaker"))
        {
            UIManager.instance.ResetCombo();

        }
    }




}


