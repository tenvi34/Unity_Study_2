using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    void UseWeapon();
}

public class Sword : IWeapon
{
    public void UseWeapon()
    {
        Debug.Log("Sword 장착");
    }
}

public class Staff : IWeapon
{
    public void UseWeapon()
    {
        Debug.Log("Staff 장착");
    }
}

public abstract class Character
{
    protected IWeapon MyWeapon;

    public Character SetWeapon(IWeapon weapon)
    {
        MyWeapon = weapon;
        return this;
    }

    public abstract Character Attack();
}

public class Warrior : Character
{
    public override Character Attack()
    {
        Debug.Log("전사의 공격");
        MyWeapon.UseWeapon();
        return this;
    }
}

public class Mage : Character
{
    public override Character Attack()
    {
        Debug.Log("마법사의 공격");
        MyWeapon.UseWeapon();
        return this;
    }
}

public class BridgePattern : MonoBehaviour
{
    void Start()
    {
        Character warrior = new Warrior().SetWeapon(new Sword());
        warrior.Attack();
        
        Character mage = new Mage().SetWeapon(new Staff());
        mage.Attack();
    }

    void Update()
    {
        
    }
}
