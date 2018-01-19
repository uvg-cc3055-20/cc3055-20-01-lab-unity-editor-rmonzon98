using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour {
    public float jumpForce = 90f;//fuerza del salto
    public float forwardSpeed = 2f;//velocidad de subida
    public GameObject cam;//acceso al game object
    public bool dead = false;
    public GameObject moneda1, moneda2, moneda3, moneda4, moneda5;
    Rigidbody2D rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>(); //obtener la referencia del Rigidbody2D del objeto Bird
    }
	
	// Update is called once per frame
	void Update () {

        if ((!(dead)) && (transform.localPosition.x<49)) {

            if (Input.GetButtonDown("Jump")) 
            {
                rb.velocity = Vector2.zero;//velocidad en caida igual 0
                rb.AddForce(Vector2.up*jumpForce);//Le da fuerza hacia adelante, esto nos sirve para que el personaje salte
            }

            rb.transform.Translate(new Vector3(1, 0, 0) * forwardSpeed * Time.deltaTime);//Hace que el personaje se mueva hacia delante
            cam.transform.Translate(new Vector3(1, 0, 0) * forwardSpeed * Time.deltaTime);//Hace que la camara se mueva hacia delante

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Monedas")
        {
            Destroy(collision.gameObject); 
        }
        else
        {
            dead = true;
        }
           
    }   

}
