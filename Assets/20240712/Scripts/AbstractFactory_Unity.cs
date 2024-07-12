using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitySimpleShapeFactory
{
    public static GameObject getShapeInstance(string typeString)
    {
        GameObject prefab = Resources.Load(typeString) as GameObject;
        return GameObject.Instantiate(prefab);   
    }
}

public class AbstractFactory_Unity : MonoBehaviour
{
    public string CreateShapeName;

    void Start()
    {
        UnitySimpleShapeFactory.getShapeInstance(CreateShapeName);
    }

    void Update()
    {
        
    }
}
