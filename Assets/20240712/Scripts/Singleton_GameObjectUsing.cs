using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton_GameObjectUsing : MonoBehaviour
{
    public GameObject GameObject1;
    
    private static Singleton_GameObjectUsing _instance;

    public static Singleton_GameObjectUsing Instance
    {
        get
        {
            // Instance가 없으면
            if (_instance == null)
            {
                // Scene에서 찾는다
                _instance = FindObjectOfType<Singleton_GameObjectUsing>();

                // Scene에 없으면
                // if (_instance == null)
                // {
                //     // 새로 생성
                //     // GameObject singleton = new GameObject("Singleton");
                //     // _instance = singleton.AddComponent<Singleton>();
                //     
                //     GameObject singletonPrefab = Resources.Load("Singleton") as GameObject;
                //     GameObject singletonInstance = Instantiate(singletonPrefab);
                //     if (singletonInstance != null) _instance = singletonInstance.GetComponent<Singleton_PrefabUsing>();
                // }
            }

            return _instance;
        }
    }

    private void Awake()
    {
        // if (_instance == null)
        // {
        //     _instance = this;
        //     DontDestroyOnLoad(gameObject);
        // }
        // else if (_instance != this)
        // {
        //     Destroy(gameObject);
        // }
    }

    public void TestFunction()
    {
        Debug.Log("Test Function");
    }
}