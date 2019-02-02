using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apuntar : MonoBehaviour {


    public GameObject cadera;
    public GameObject apuntando;

	void Update () {

        if (Input.GetMouseButton(1))
        {
            cadera.SetActive(false);
            apuntando.SetActive(true);

        } else
        {
            cadera.SetActive(true);
            apuntando.SetActive(false);
        }
	}
}
