using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Memento 클래스: 플레이어의 상태를 저장
public class Player_1Memento
{
    public Vector3 Position { get; private set; }
    public int Health { get; private set; }
    public int Score { get; private set; }

    public Player_1Memento(Vector3 position, int health, int score)
    {
        Position = position;
        Health = health;
        Score = score;
    }
}

// Originator 클래스: 플레이어
public class Player_1 : MonoBehaviour
{
    public Vector3 Position { get; set; }
    public int Health { get; set; }
    public int Score { get; set; }

    // 현재 상태를 Memento에 저장
    public Player_1Memento SaveState()
    {
        return new Player_1Memento(Position, Health, Score);
    }

    // Memento로부터 상태를 복원
    public void RestoreState(Player_1Memento memento)
    {
        Position = memento.Position;
        Health = memento.Health;
        Score = memento.Score;

        // Unity Transform 업데이트
        transform.position = Position;

        Debug.Log($"State restored - Position: {Position}, Health: {Health}, Score: {Score}");
    }

    // 플레이어 상태 변경 (예시용)
    public void ChangeState(Vector3 newPosition, int healthChange, int scoreChange)
    {
        Position = newPosition;
        Health += healthChange;
        Score += scoreChange;

        // Unity Transform 업데이트
        transform.position = Position;

        Debug.Log($"State changed - Position: {Position}, Health: {Health}, Score: {Score}");
    }
}

// Caretaker 클래스: 메멘토 관리
public class MementoPattern : MonoBehaviour
{
    public Player_1 Player_1;
    private Stack<Player_1Memento> mementos = new Stack<Player_1Memento>();

    void Start()
    {
        Player_1 = GetComponent<Player_1>();
        SavePlayer_1State(); // 초기 상태 저장
    }

    public void SavePlayer_1State()
    {
        mementos.Push(Player_1.SaveState());
        Debug.Log("Player_1 state saved.");
    }

    public void UndoPlayer_1State()
    {
        if (mementos.Count > 1) // 항상 하나의 상태는 남겨둠
        {
            mementos.Pop(); // 현재 상태 제거
            Player_1.RestoreState(mementos.Peek());
        }
        else
        {
            Debug.Log("Can't undo: No more saved states.");
        }
    }

    // 테스트용 메서드들
    public void MovePlayer_1Randomly()
    {
        Vector3 randomPosition = Random.insideUnitSphere * 5f;
        randomPosition.y = 0; // y축은 0으로 유지

        int healthChange = Random.Range(-10, 11);
        int scoreChange = Random.Range(0, 101);

        Player_1.ChangeState(randomPosition, healthChange, scoreChange);
        SavePlayer_1State();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            MovePlayer_1Randomly();
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            UndoPlayer_1State();
        }
    }
}

// public class MementoPattern : MonoBehaviour
// {
//     // Start is called before the first frame update
//     void Start()
//     {
//         
//     }
//
//     // Update is called once per frame
//     void Update()
//     {
//         
//     }
// }
