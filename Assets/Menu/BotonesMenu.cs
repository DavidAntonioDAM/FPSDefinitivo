using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonesMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Jugar()
    {
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }

    public void Salir()
    {
        Application.Quit();
    }

    public void CargarEscenaBoss()
    {
        if (TusMuertos.muertos <= 0)
        {
            SceneManager.LoadScene("Boss-Scene", LoadSceneMode.Single);
        }
    }
}
