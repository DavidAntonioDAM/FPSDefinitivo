using UnityEngine;
using UnityEngine.UI;

public class Cargador
{
    public static int municion = 0;
}

public class TusMuertos
{
    public static int muertos = 0;
}

namespace Nokobot.Assets.Crossbow
{
    

    public class CrossbowShoot : MonoBehaviour
    {
        public int numMuertos;


        //Municion
        public Text sinBalas;
        public Text textoFlechas;
        public Arma arma;

        public int flechasEnMochila; //Flechas que quedam em total
        public int flechasEnCartucho; //Flechas que puedes cargar
        public int tamañoDeCartucho = 15;
        public int maximoDeFlechas = 45;

        //Recargar Municion
        public bool recargando = false;


        //Disparo
        public GameObject arrowPrefab;
        public Transform arrowLocation;

        public float shotPower = 100f;

        void Start()
        {
            if (arrowLocation == null)
                arrowLocation = transform;

            flechasEnCartucho = tamañoDeCartucho;
            flechasEnMochila = maximoDeFlechas;
            Cargador.municion = 30;
            TusMuertos.muertos = 10;
        }

        void Update()
        {
            
            flechasEnMochila = Cargador.municion;
            if (recargando) return;
            if (Input.GetButtonDown("Fire1"))
            {
                Disparar();
            }
        }


        //Lo he puesto así porque funciona tanto el restar municion como cargarlo, pero falla cuando lo recarga la tercera vez
        void Disparar()
        {
            if (flechasEnMochila > 0)
            {
                Cargador.municion -= 1;
                Instantiate(arrowPrefab, arrowLocation.position, arrowLocation.rotation).GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * shotPower);
            }

        }

        void sumarFlechas ()
        {
            flechasEnMochila += 30;
        }
    }
}
