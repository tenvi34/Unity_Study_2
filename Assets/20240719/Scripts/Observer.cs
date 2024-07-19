using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObserver
{
    void OnNotify(string message);
}

// 주체(Subject) 클래스
public class Subject : MonoBehaviour
{
    private List<IObserver> _observers = new List<IObserver>();
    
    // 옵저버 등록
    public void AddObserver(IObserver observer)
    {
        _observers.Add(observer);
    }
    
     // 옵저버 제거
     public void RemoveObserver(IObserver observer)
     {
         _observers.Remove(observer);
     }
     
      // 모든 옵저버에게 알림
      protected void NotifyObservers(string message)
      {
          foreach (var observer in _observers)
          {
              observer.OnNotify(message);
          }
      }
}

// 구체적인 주체 클래스 예시 (플레이어)
public class Player : Subject
{
    private int health = 100;

    public void TakeDamage(int damage)
    {
        health -= damage;
        NotifyObservers($"Player health changed to {health}");

        if (health <= 0)
        {
            NotifyObservers("You Die");
        }
    }
}

// 구체적인 옵저버 클래스 예시 (UI)
public class HealthUI : MonoBehaviour, IObserver
{
    public void OnNotify(string message)
    {
        Debug.Log($"HealthUI received: {message}");
        // 여기서 UI 업데이트 진행
    }
}

public class PartyMemberNotify : MonoBehaviour, IObserver
{
    public void OnNotify(string message)
    {
        Debug.Log($"PartyMemberNotify received: {message}");
        // 여기서 UI 업데이트 진행
    }
}

public class Observer : MonoBehaviour
{
    private Player _player;
    
    void Start()
    {
        _player = gameObject.AddComponent<Player>();
        HealthUI healthUI = gameObject.AddComponent<HealthUI>();
        PartyMemberNotify partyMemberNotify = gameObject.AddComponent<PartyMemberNotify>();
        
        _player.AddObserver(healthUI);
        _player.AddObserver(partyMemberNotify);
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            // 플레이어가 데미지를 받으면 모든 옵저버에게 알림이 간다
            _player.TakeDamage(20);
        }
    }
}
