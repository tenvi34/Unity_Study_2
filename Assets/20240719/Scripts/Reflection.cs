using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Reflection : MonoBehaviour
{
    private int exampleInt = 10;
    public int exampleInt2 = 20;

    void Start()
    {
        System.Type myType = typeof(Reflection);
        System.Type myType2 = this.GetType();
        
        Debug.Log($"myType.Name : {myType.Name}");
        Debug.Log($"myType2.Name : {myType2.Name}");
        
        // public member 함수를 가져와서 호출
        MethodInfo exampleFunctionMethodInfo = myType.GetMethod("ExampleFunction");
        exampleFunctionMethodInfo?.Invoke(this, null);
        
        // non public(private or protected) 함수를 가져와서 호출
        MethodInfo exampleFunction2MethodInfo = myType.GetMethod("ExampleFunction2", BindingFlags.NonPublic | BindingFlags.Instance);
        exampleFunction2MethodInfo?.Invoke(this, null);
        
        // not public 멤버 변수를 가져온다
        FieldInfo exampleIntInfo = myType.GetField("exampleInt", BindingFlags.NonPublic | BindingFlags.Instance);
        exampleIntInfo?.SetValue(this, 50);
        Debug.Log($"example int value : {exampleIntInfo?.GetValue(this)}");
        Debug.Log($"example int Origin value : {exampleInt}");
        
        // public 멤버 변수를 가져온다
        FieldInfo exampleIntInfo2 = myType.GetField("exampleInt2");
        Debug.Log($"example int 2 value : {exampleIntInfo2?.GetValue(this)}");
    }

    void Update()
    {
        
    }

    public void ExampleFunction()
    {
        Debug.Log("Called ExampleFunction");
    }

    void ExampleFunction2()
    {
        Debug.Log("Called ExampleFunction2");
    }
    
    public void ExampleFunction3()
    {
        Debug.Log("Called ExampleFunction3");
    }
}
