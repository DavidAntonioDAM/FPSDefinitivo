using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour {

    public int cantidadRecogida = 0;
    [SerializeField]
    private float amount = 30;
    // Use this for initialization
    HealthBar hb = new HealthBar();
    void Start()
    {

    }

   
    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider Personaje)
    {
        if (Personaje.CompareTag("Player"))
        {
            hb.addHealth(amount);
            Destroy(gameObject);
        }
    }


        
    
}
