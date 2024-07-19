using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 전략 인터페이스
public interface IMovementStrategy
{
    void Move(Transform transform);
}

// 구체적인 전략 1: 직선 이동
public class StraightMovement : IMovementStrategy
{
    public float speed = 5f;
    
    public void Move(Transform transform)
    {
        Debug.Log("직선 이동");
        transform.Translate(Vector3.forward * speed * Time.deltaTime);        
    }
}

// 구체적인 전략 2: 지그재그 이동
public class ZigzagMovement : IMovementStrategy
{
    public float speed = 3f;
    public float frequency = 2f;
    public float magnitude = 0.5f;
    
    public void Move(Transform transform)
    {
        Debug.Log("지그재그 이동");
        Vector3 pos = transform.position;
        pos += transform.forward * speed * Time.deltaTime;
        pos += transform.right * Mathf.Sin(Time.time * frequency) * magnitude;
        transform.position = pos;
    }
}

// 전략을 사용하는 컨텍스트 클래스
public class Character_1 : MonoBehaviour
{
    private IMovementStrategy movementStrategy;

    public void SetMovementStrategy(IMovementStrategy strategy)
    {
        movementStrategy = strategy;
    }

    void Update()
    {
        if (movementStrategy != null)
        {
            movementStrategy.Move(transform);
        }
    }
}

// 전략 패턴 사용 예시
public class GameManager_1 : MonoBehaviour
{
    public Character_1 character;   

    void Start()
    {
        character = GetComponent<Character_1>();
        
        // 초기 전략 설정
        character.SetMovementStrategy(new StraightMovement());
    }

    void Update()
    {
        // 스페이스바를 누르면 전략 변경
        if (Input.GetKeyDown(KeyCode.Space))
        {
            character.SetMovementStrategy(new ZigzagMovement());
        }
    }
}

public class Strategy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
