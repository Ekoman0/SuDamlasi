using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mauslook : MonoBehaviour
{
    [Range(50, 500)]
    public float sens;
    public Transform body;
    float xrot =0f;

 

    void Update()
    {
        float rotx = Input.GetAxis("Mouse X") * sens * Time.deltaTime;
        float roty = Input.GetAxis("Mouse Y") * sens * Time.deltaTime;

        xrot -= roty;
        xrot = Mathf.Clamp(xrot, -80, 80);
        transform.localRotation = Quaternion.Euler(xrot, 0f, 0f);

        body.Rotate(Vector3.up * rotx);

    }
}
