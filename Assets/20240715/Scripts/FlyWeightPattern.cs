using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyWeightPattern : MonoBehaviour
{
    void Start()
    {
        Debug.Log(FlyWeightData.instance.data3);
    }

    void Update()
    {
        
    }
}
