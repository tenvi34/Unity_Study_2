using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prototype
{
    public int a = 10;
    public int b = 10;
    public int c = 10;

    public Prototype Clone()
    {
        var result = new Prototype();
        result.a = a;
        result.b = b;
        result.c = c;

        return result;
    }
}

public class Prototype_Example : MonoBehaviour
{
    public int a = 10;
    public int b = 10;
    public int c = 10;
    
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
        // if (Input.GetKeyDown(KeyCode.A))
        // {
        //     b = 20;
        //     Instantiate(this.gameObject);
        // }
        // if (Input.GetKeyDown(KeyCode.B))
        // {
        //     b = 30;
        //     Instantiate(this.gameObject);
        // }
    }
}
