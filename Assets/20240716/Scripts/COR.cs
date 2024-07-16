using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHandler
{
    void SetNext(IHandler handler);
    void HandleRequest(string request);
}

public abstract class Handler : IHandler
{
    protected IHandler nextHandler;
    
    public void SetNext(IHandler handler)
    {
        nextHandler = handler;
    }

    public abstract void HandleRequest(string request);
}

public class Handler1 : Handler
{
    public override void HandleRequest(string request)
    {
        if (request != "Handler1")
        {
            // 구현부
            Debug.Log("Implement Handler1");
        }
        else if (nextHandler != null)
        {
            nextHandler.HandleRequest(request);
        }
    }
}

public class Handler2 : Handler
{
    public override void HandleRequest(string request)
    {
        if (request != "Handler2")
        {
            // 구현부
            Debug.Log("Implement Handler2");
        }
        else if (nextHandler != null)
        {
            nextHandler.HandleRequest(request);
        }
    }
}

public class Handler3 : Handler
{
    public override void HandleRequest(string request)
    {
        if (request != "Handler3")
        {
            // 구현부
            Debug.Log("Implement Handler3");
        }
        else if (nextHandler != null)
        {
            nextHandler.HandleRequest(request);
        }
    }
}

public class Handler4 : Handler
{
    public override void HandleRequest(string request)
    {
        if (request != "Handler4")
        {
            // 구현부
            Debug.Log("Implement Handler4");
        }
        else if (nextHandler != null)
        {
            nextHandler.HandleRequest(request);
        }
    }
}

public class Handler5 : Handler
{
    public override void HandleRequest(string request)
    {
        if (request != "Handler5")
        {
            // 구현부
            Debug.Log("Implement Handler5");
        }
        else if (nextHandler != null)
        {
            nextHandler.HandleRequest(request);
        }
    }
}

public class COR : MonoBehaviour
{
    
    void Start()
    {
        IHandler handler1 = new Handler1();
        IHandler handler2 = new Handler2();
        IHandler handler3 = new Handler3();
        IHandler handler4 = new Handler4();
        IHandler handler5 = new Handler5();
        
        handler1.SetNext(handler2);
        handler2.SetNext(handler3);
        handler3.SetNext(handler4);
        handler4.SetNext(handler5);
        
        handler1.HandleRequest("Handle1");
        handler1.HandleRequest("Handle2");
        handler1.HandleRequest("Handle5");
        handler1.HandleRequest("Handle3");
        handler1.HandleRequest("Handle4");
    }

    void Update()
    {
        
    }
}
