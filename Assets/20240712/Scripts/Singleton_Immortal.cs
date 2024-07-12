using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Scene 내에 오브젝트를 바인딩 하지 않는 구조이면서
// 데이터를 다른 Scene으로 넘어가도 누적되서 사용해야 하거나
// Scene Load와 상관없이 사용해야 하는 경우에는
// DontDestroyOnLoad 를 통해서 삭제되지 않게 한다.
public class Singleton_Immortal : MonoBehaviour
{
    public GameObject Prefab1;
    public int TotalTime;
    
    private static Singleton_Immortal _instance;

    // Public static property to access the instance
    public static Singleton_Immortal Instance
    {
        get
        {
            // If the instance is null, find an instance in the scene
            if (_instance == null)
            {
                _instance = FindObjectOfType<Singleton_Immortal>();

                // If there is no instance in the scene, create a new onec
                if (_instance == null)
                {
                    GameObject singletonPrefab = Resources.Load("Singleton") as GameObject;
                    GameObject singletonInstance = Instantiate(singletonPrefab);
                    if (singletonInstance != null) _instance = singletonInstance.GetComponent<Singleton_Immortal>();
                }
            }

            return _instance;
        }
    }

    // Awake method to enforce singleton property
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject); // This makes sure the instance is not destroyed on scene load
        }
        else if (_instance != this)
        {
            Destroy(gameObject); // Destroy this instance if another instance already exists
        }
    }

    public void TestFunction()
    {
        Debug.Log("TestFunction");
    }
}