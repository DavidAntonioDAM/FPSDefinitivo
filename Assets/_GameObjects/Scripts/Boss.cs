using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour {
    enum Estado { Idle, Following, Dead }; //enumeracion de estados
    private Estado estado = Estado.Idle; //asignacion del estado actual

    private Animator animator; // declaracion del animator
    public GameObject player; // referencia a un objeto player
    private TextMesh tm; // declaracion del texto flotante

    //variables que se pueden modificar desde unity
    public float speed;
    

    private NavMeshAgent nma;

    void Start()
    {
        nma = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        tm = GetComponentInChildren<TextMesh>();
        InvokeRepeating("MostrarVida", 0, 0);

        tm.color = Color.magenta;
    }

    void Update()
    {
        if (estado == Estado.Following)
        {
            nma.enabled = true;
            nma = GetComponent<NavMeshAgent>();
            nma.destination = player.transform.position;
        }
        else if (estado == Estado.Idle)
        {
            nma.enabled = false;
        }

        InvokeRepeating("MostrarVida", 0, 0);
    }


    private void CambiarEstado()
    {
        if (estado == Estado.Idle)
        {
            estado = Estado.Following;
            animator.SetBool("Correr", true);
        }
        else if (estado == Estado.Following)
        {
            estado = Estado.Idle;
            animator.SetBool("Correr", false);
        }
    }


    private int vida = 40;
    private System.String barraVida = "__________";
    private int numBarrasVida = 4;
    private int recortePalabra = 10;

    public void QuitarVida(int danyo)
    {
        vida -= danyo;
        if (vida != 0)
        {
            print(vida);
            recortePalabra -= danyo;

            barraVida = barraVida.Substring(0, recortePalabra);
            MostrarVida();
            
            if (vida == 30)
            {
                tm.color = Color.red;
                barraVida = "__________";
                recortePalabra = 10;
            } else if (vida == 20)
            {
                tm.color = Color.yellow;
                barraVida = "__________";
                recortePalabra = 10;
            } else if (vida == 10)
            {
                tm.color = Color.green;
                barraVida = "__________";
                recortePalabra = 10;
            }
            
        }
        else if (vida <= 0)
        {
            estado = Estado.Dead;
            barraVida = "";
            CancelInvoke("Rotar");
            nma.enabled = false;
            animator.SetBool("Morir", true);
            SceneManager.LoadScene("GameWin", LoadSceneMode.Single);
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
            Atacar(true);
            collision.gameObject.GetComponent<HealthBar>().makeDamage(20f);
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
