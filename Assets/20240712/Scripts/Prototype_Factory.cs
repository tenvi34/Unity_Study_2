using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prototype_Factory : MonoBehaviour
{
    public Prototype_Example lastedSpawnObject;
    
    // Start is called before the first frame update
    void Start()
    {
        // Prototype prototype = new Prototype();
        // prototype.c = 20;
        //
        // Prototype prototype2 = prototype.Clone();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            lastedSpawnObject.b = 20;
            Instantiate(lastedSpawnObject.gameObject).GetComponent<Prototype_Example>();
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            lastedSpawnObject.b = 30;
            Instantiate(lastedSpawnObject.gameObject).GetComponent<Prototype_Example>();
        }
    }
}
