using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class TrollDavid : MonoBehaviour {
    enum Estado { Walking, Following, Dead}; //enumeracion de estados
    private Estado estado = Estado.Walking; //asignacion del estado actual

    private Animator animator; // declaracion del animator
    public GameObject player; // referencia a un objeto player
    private TextMesh tm; // declaracion del texto flotante

    //variables que se pueden modificar desde unity
    public float speed;
    private int vida = 10;
    private System.String barraVida = "__________";

    private NavMeshAgent nma;

    void Start () {
        nma = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        tm = GetComponentInChildren<TextMesh>();
        //InvokeRepeating("Rotar", 0, 3);
        InvokeRepeating("MostrarVida", 0, 0);       
	}

    void Update()
    {
        if (estado == Estado.Following)
        {
            nma.enabled = true;
            nma = GetComponent<NavMeshAgent>();
            nma.destination = player.transform.position;
        }
        else if (estado == Estado.Walking)
        {
            nma.enabled = false;
            Invoke("Rotar", 0);
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        InvokeRepeating("MostrarVida", 0, 0);
    }    

    
    private void CambiarEstado()
    {
        if (estado == Estado.Walking)
        {
            estado = Estado.Following;
            animator.SetBool("Correr", true);
        } else if (estado == Estado.Following) {
            estado = Estado.Walking;
            animator.SetBool("Correr", false);
        }
    }

    public void QuitarVida(int danyo)
    {
        vida -= danyo;
        if (vida != 0)
        {
            
            barraVida = barraVida.Substring(0, vida);
            MostrarVida();
        } 
        else 
        {
            estado = Estado.Dead;
            barraVida = "";
            CancelInvoke("Rotar");
            nma.enabled = false;
            animator.SetBool("Morir", true);
            Destroy(this.gameObject, 4f);
            TusMuertos.muertos--;

            if (TusMuertos.muertos == 0)
            {
                SceneManager.LoadScene("Boss-Scene", LoadSceneMode.Single);
            }
        }
    }

    float time = 4.0f;
    int direccion = 180;
    void Rotar()
    {
        //float delta = Random.Range(-180, 180);
        //transform.Rotate(new Vector3(0, delta, 0));
        if (time >= 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            transform.Rotate(new Vector3(0, direccion, 0));
            direccion = direccion * -1;
            time = 4.0f;
        } 
    }

    private void MostrarVida()
    {
        tm.transform.LookAt(player.transform);
        tm.text = barraVida;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Player")
        {
            Invoke("CambiarEstado", 0);
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.name == "Player")
        {
            Invoke("CambiarEstado", 0);
        }
    }

    public void Atacar(bool accion)
    {
        animator.SetBool("Atacar", accion);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.GetComponent<HealthBar>().makeDamage(20f);
            Atacar(true);
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Atacar(false);
        }
    }
}
