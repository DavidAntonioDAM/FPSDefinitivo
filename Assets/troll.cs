using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class troll : MonoBehaviour {

    public float speed;
    enum State { Walking, Following };
    private State state = State.Walking;

    private Transform playerTransform;

    void Start()
    {
        InvokeRepeating("Rotar", 0, 3);
        Invoke("Walk", 10);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        if (state == State.Following)
        {
            transform.LookAt(playerTransform);
        }
    }

    void Rotar()
    {
        float delta = Random.Range(-180, 180);
        transform.Rotate(new Vector3(0, delta, 0));
    }

    public void HacerDanyo(int danyo)
    {
        Destroy(this.gameObject);
    }
    /*
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Player")
        {
            state = State.Following;
            playerTransform = collider.gameObject.transform;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.name == "Player")
        {
            state = State.Walking;
        }
    }
    */
}
