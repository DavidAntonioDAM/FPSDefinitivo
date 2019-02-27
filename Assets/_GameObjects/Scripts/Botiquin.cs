using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botiquin : MonoBehaviour {
    float initTime = 0.8f;
    float time = 0.8f;
    bool direccion = true;
    float speed = 0.2f;
    void Update()
    {
        Invoke("Movimiento", 0);

        // Move the object upward in world space 1 unit/second.
        
    }

    void Movimiento()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * 100);
        if (direccion == true)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed, Space.World);
        } else
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed, Space.World);
        }

        if (time >= 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            if (direccion == true)
            {
                direccion = false;
                time = initTime;
            }
            else
            {
                direccion = true;
                time = initTime;
            }
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.GetComponent<HealthBar>().addHealth(100f);
            Destroy(this.gameObject, 0);
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            
        }
    }


}
