using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IDamageOption
{
    protected int damage;
    public IDamageOption nextOption;

    public int DamageWithOption()
    {
        int result = damage;
        result *= nextOption?.DamageWithOption() ?? 1;
        
        return result;
    }
}

public class Sword_D : IDamageOption
{
    public Sword_D()
    {
        damage = 20;
    }

}

public class Jewelry : IDamageOption
{
    public Jewelry()
    {
        damage = 40;
    }
}

public class DecoratorPattern : MonoBehaviour
{
    void Start()
    {
        IDamageOption option = new Sword_D();
        option.nextOption = new Jewelry();
        option.nextOption.nextOption = new Jewelry();
        Debug.Log(option.DamageWithOption()); 
    }

    void Update()
    {
        
    }
}
