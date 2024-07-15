using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "FlyWeightData", menuName = "ScriptableSingleton/GameSettings")]
public class FlyWeightData : ScriptableSingleton<FlyWeightData>
{
    public int data = 10;
    public int data2 = 10;
    public int data3 = 10;
}
