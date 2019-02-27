using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour {
    public AudioClip disparo;//El fichero de sonido
    private AudioSource audioSource;
    public GameObject prefabProyectil;
    public Transform puntoGeneracion;
    public float fuerzaDisparo = 0.1f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject proyectil =
                Instantiate(
                    prefabProyectil,
                    puntoGeneracion.position,
                    Quaternion.identity);
            proyectil.GetComponent<Rigidbody>().AddForce(
                transform.forward * fuerzaDisparo,
                ForceMode.Impulse);
            audioSource.PlayOneShot(disparo);
            Destroy(proyectil, 3);
        }
    }
}
