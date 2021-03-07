using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class harakett3d : MonoBehaviour
{
    public Transform egilme;
    public bool z�plarkenkosma = true;
    public float stamina = 1f; // karakter havadayken tekrardan z�plamamas� i�in
    public float hiz = 5f;
    public float ziplama = 300f; // a��rl��� 1 olarak baz ald�m

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal") * hiz;
        float z = Input.GetAxis("Vertical") * hiz;

        x *= Time.deltaTime;
        z *= Time.deltaTime;
        transform.Translate(x, 0, z);

        if (stamina == 1f && Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * ziplama);
            stamina = 0f;
            hiz = 2f; //ger�ek�ilik katmak i�in havadayken x ve z h�zlar�n� yava�latt�m
            z�plarkenkosma = false;
        }

        else if (Input.GetKey(KeyCode.LeftShift) && z�plarkenkosma == true)
        {
            hiz = 10f;
            z�plarkenkosma = false;

        }

        else if (Input.GetKey(KeyCode.LeftControl))
        {
            this.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
        }

        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            this.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "yer")// karakter z�plad�ktan sonra "yer" tagl� bir zemine de�meden  bir daha z�playamaz
        {
            stamina = 1f;
            hiz = 5f;
            z�plarkenkosma = true;
        }

        
    }
}

