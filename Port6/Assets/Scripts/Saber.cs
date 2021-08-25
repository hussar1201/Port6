using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saber : MonoBehaviour
{
    public LayerMask layer;
    private Vector3 oldPos;
    public bool is_saber_blue;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;       
        if (Physics.Raycast(transform.position, transform.up, out hit, 300f, layer))
        {
            if (Vector3.Angle(transform.position - oldPos, hit.transform.up) > 130)
            {
                Cube tmp = hit.transform.gameObject.GetComponent<Cube>();
                if(tmp.is_cube_blue == is_saber_blue) Destroy(tmp.gameObject);
            }
        }
        oldPos = transform.position;
    }
}
