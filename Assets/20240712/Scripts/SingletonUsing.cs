using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SingletonUsing : MonoBehaviour
{
    [FormerlySerializedAs("singleton")] public Singleton_PrefabUsing singletonPrefabUsing;
    
    void Start()
    {
        // singleton = GameObject.Find("Singleton").GetComponent<Singleton>();
        singletonPrefabUsing = Singleton_PrefabUsing.Instance;
    }
    
    void Update()
    {
        singletonPrefabUsing.TestFunction();
    }
}
