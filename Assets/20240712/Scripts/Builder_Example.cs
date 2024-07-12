using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoBuilderData
{
    public int a;
    public int b;
    public int c;
    public int d;
    public int e;
    
    public void Print()
    {
        Debug.Log($"a: {a}, b: {b}, c:{c}, d: {d}, e: {e}");
    }
}

public class BuilderData
{
    private int a;
    private int b;
    private int c;
    private int d;
    private int e;

    public void Print()
    {
        Debug.Log($"a: {a}, b: {b}, c:{c}, d: {d}, e: {e}");
    }

    public BuilderData SetA(int value)
    {
        a = value;
        return this;
    }
    
    public BuilderData SetB(int value)
    {
        b = value;
        return this;
    }
    
    public BuilderData SetC(int value)
    {
        c = value;
        return this;
    }
    
    public BuilderData SetD(int value)
    {
        d = value;
        return this;
    }
    
    public BuilderData SetE(int value)
    {
        e = value;
        return this;
    }
}

public class Builder_Example : MonoBehaviour
{
    private NoBuilderData _noBuilderData;
    private BuilderData _builderData;

    private List<Action> NoBuilderActions = default;
    private List<Action> BuilderActions = default;

    Builder_Example AddAction(Action action)
    {
        BuilderActions.Add(action);
        return this;
    }

    void ExcuteActions()
    {
        foreach (var builderAction in BuilderActions)
        {
            builderAction.Invoke();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _noBuilderData = new NoBuilderData
        {
            a = 10,
            b = 10,
            c = 10,
            d = 10,
            e = 10,
        };
        
        _noBuilderData.Print();

        // 빌더
        _builderData = new BuilderData();
        _builderData.SetA(10).SetB(10).SetC(10).SetD(10).SetE(10).Print();
        
        NoBuilderActions.Add(() => { Debug.Log("a"); });
        NoBuilderActions.Add(() => { Debug.Log("b"); });
        NoBuilderActions.Add(() => { Debug.Log("c"); });
        NoBuilderActions.Add(() => { Debug.Log("d"); });
        NoBuilderActions.Add(() => { Debug.Log("e"); });
        foreach (var noBuilderAction in NoBuilderActions)
        {
            noBuilderAction.Invoke();
        }

        // 실제 활용 사례 (빌더)
        AddAction(() => {Debug.Log("a");}).
            AddAction(() => {Debug.Log("b");}).
            AddAction(() => {Debug.Log("c");}).
            AddAction(() => {Debug.Log("d");}).
            AddAction(() => {Debug.Log("e");}).ExcuteActions();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
