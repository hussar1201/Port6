using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VolumetricLines;

public class Saber : MonoBehaviour
{
    public LayerMask layer;
    private Vector3 oldPos;
    public bool is_saber_blue;
    public bool is_on_right;
    public VolumetricLineBehavior vlb;
    private ParticleSystem[] arr_particles;

    private void Start()
    {
        vlb = GetComponent<VolumetricLineBehavior>();
        arr_particles = GetComponentsInChildren<ParticleSystem>();
        Debug.Log(arr_particles.Length);
        for (int i = 0; i < arr_particles.Length; i++)
        {
            arr_particles[i].gameObject.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (UIManager.instance.is_menu_called) return;
        

        /*
        RaycastHit hit;       
        if (Physics.Raycast(transform.position, transform.up, out hit, 250f, layer))
        {
            if (Vector3.Angle(transform.position - oldPos, hit.transform.up) > 120)
            {
                Cube tmp = hit.transform.gameObject.GetComponent<Cube>();
                if (tmp.is_cube_blue == is_saber_blue)
                {
                    Destroy(tmp.gameObject);
                    UIManager.instance.AddScore(10);
                }
            }
        }
        oldPos = transform.position;
        */


    }

    public void ChangeColor()
    {
        is_saber_blue = !is_saber_blue;

        StartCoroutine(ShowEffects());

        if(vlb.LineColor == Color.blue)
            vlb.LineColor = Color.red;
        else
            vlb.LineColor = Color.blue;
    }

    IEnumerator ShowEffects()
    {
        for(int i = 0;i<arr_particles.Length;i++)
        {
            arr_particles[i].gameObject.SetActive(true);
        }
        
        yield return new WaitForSeconds(0.2f);

        for (int i = 0; i < arr_particles.Length; i++)
        {
            arr_particles[i].gameObject.SetActive(false);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Cube"))
        {
            Cube tmp = collision.gameObject.GetComponent<Cube>();
            Debug.Log(tmp);
            if (tmp.is_cube_blue == is_saber_blue)
            {
                Destroy(tmp.gameObject);
                UIManager.instance.AddScore(10);
            }
        }
    }



}
