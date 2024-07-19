using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class ReflectionClass
{
    public ReflectionClass()
    {
        Debug.Log("Created Reflection Class");
    }

    public ReflectionClass(int a, int b)
    {
        Debug.Log($"Created Reflection Class with member values : a = {a}, b = {b}");
    }
}

public class ReflectionFriend : MonoBehaviour
{
    private Reflection _cachedExample;
    
    void Start()
    {
        MethodInfo methodInfo = typeof(GameObject).GetMethod("GetComponent", new System.Type[] { typeof(System.Type) });

        _cachedExample = methodInfo?.Invoke(gameObject, new object[] { typeof(Reflection) }) as Reflection;
        _cachedExample?.ExampleFunction3();

        ReflectionClass instance = Activator.CreateInstance(System.Type.GetType("ReflectionClass")) as ReflectionClass;
        ReflectionClass instance2 = Activator.CreateInstance(System.Type.GetType("ReflectionClass"), new object[] {1, 2}) as ReflectionClass;
    }

    void Update()
    {
        
    }
}
