using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class harakett3d : MonoBehaviour
{
    public Transform egilme;
    public bool zýplarkenkosma = true;
    public float stamina = 1f; // karakter havadayken tekrardan zýplamamasý için
    public float hiz = 5f;
    public float ziplama = 300f; // aðýrlýðý 1 olarak baz aldým

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
            hiz = 2f; //gerçekçilik katmak için havadayken x ve z hýzlarýný yavaþlattým
            zýplarkenkosma = false;
        }

        else if (Input.GetKey(KeyCode.LeftShift) && zýplarkenkosma == true)
        {
            hiz = 10f;
            zýplarkenkosma = false;

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
        if (collision.gameObject.tag == "yer")// karakter zýpladýktan sonra "yer" taglý bir zemine deðmeden  bir daha zýplayamaz
        {
            stamina = 1f;
            hiz = 5f;
            zýplarkenkosma = true;
        }

        
    }
}

