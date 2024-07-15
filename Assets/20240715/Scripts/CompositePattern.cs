using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEventNotify
{
    void Event();
}

public class EN_Attack : IEventNotify
{
    public void Event()
    {
        Debug.Log("이벤트 공격 시스템");
    }
}

public class EN_Guard : IEventNotify
{
    public void Event()
    {
        Debug.Log("이벤트 방어 시스템");
    }
}

public class EN_Idle : IEventNotify
{
    public void Event()
    {
        Debug.Log("이벤트 기본 시스템");
    }
}

public class EventNotificationManager
{
    public List<IEventNotify> Notifies = new();
}

public class CompositePattern : MonoBehaviour
{
    void Start()
    {
        // Composite Pattern 미사용
        IEventNotify noti1 = new EN_Attack();
        noti1.Event();
        
        IEventNotify noti2 = new EN_Guard();
        noti2.Event();
        
        IEventNotify noti3 = new EN_Idle();
        noti3.Event();
        
        // Composite Pattern 사용
        EventNotificationManager manager = new();
        manager.Notifies.Add(new EN_Attack());
        manager.Notifies.Add(new EN_Guard());
        manager.Notifies.Add(new EN_Idle());

        foreach (var eventNotify in manager.Notifies)
        {
            eventNotify.Event();
        }
    }

    void Update()
    {
        
    }
}
