using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// sealed -> 더이상 상속받지 못하게 할 때
public sealed class Tway
{
    public void Fly()
    {
        
    }
}

public class RunObject
{
    public void Run()
    {
        Debug.Log("Run");
    }
}

public interface RunInterface
{
    void Run();
}

public class Adapter_Example : MonoBehaviour
{
    private RunObject _runObject = new();
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Run()
    {
        _runObject.Run();
    }
}

public class Adapter_Example2 : MonoBehaviour
{
    void Start()
    {
        // RunObject가 private이므로 adapter로 한번 거쳐서 접속
        var adapter = new Adapter_Example();
        adapter.Run();
    }
}
