using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proxy1
{
    public void Load()
    {
        // ex) 1 GB
    }

    public void UnLoad()
    {
        
    }
}

public class ProxyPattern : MonoBehaviour
{
    private Proxy1 proxy1 = null;

    public void ProxyLoad()
    {
        proxy1 = new Proxy1();
        proxy1.Load();
    }

    public void ProxyUnload()
    {
        if (proxy1 != null) proxy1.UnLoad();
        proxy1 = null;
    }
}
