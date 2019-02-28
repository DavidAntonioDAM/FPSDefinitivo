using Nokobot.Assets.Crossbow;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Municion : MonoBehaviour {

    public Text textoMunicion;
    public Text textoCarcaj;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        /*
        textoMunicion.text = arma.flechasEnCartucho + "/" + arma.tamañoDeCartucho;
        textoCarcaj.text = arma.flechasEnMochila + "/" + arma.maximoDeFlechas;
        */
        textoCarcaj.text = Cargador.municion + "";
        textoMunicion.text = TusMuertos.muertos + "/ 10"; // ESTO ES EL CONTADOR DE TUS MUERTOS BRO
    }
}
