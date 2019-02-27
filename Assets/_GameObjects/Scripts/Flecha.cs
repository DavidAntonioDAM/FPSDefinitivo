using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flecha : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemigo") )
        {
            print(gameObject.name);
            collision.gameObject.GetComponent<TrollDavid>().QuitarVida(1);
            Destroy(this.gameObject);
        } else
        {
            Destroy(this.gameObject, 3);
        }
        /*
        if (collision.gameObject.CompareTag("Vampiro"))
        {
            print(gameObject.name);
            collision.gameObject.GetComponent<TrollDavid>().QuitarVida(1);
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject, 3);
        }
        */
        if (collision.gameObject.CompareTag("boss"))
        {
            print(gameObject.name);
            collision.gameObject.GetComponent<Boss>().QuitarVida(1);
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject, 3);
        }
    }
}
