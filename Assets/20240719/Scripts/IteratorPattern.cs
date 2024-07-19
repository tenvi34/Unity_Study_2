using System.Collections.Generic;
using UnityEngine;

public interface IIterator<T>
{
    bool HasNext();
    T Next();
}

// Iterable 인터페이스
public interface IIterable<T>
{
    IIterator<T> GetIterator();
}

// 구체적인 Iterable 클래스: 게임 레벨
public class GameLevel : IIterable<GameObject>
{
    private List<GameObject> enemies = new List<GameObject>();

    public void AddEnemy(GameObject enemy)
    {
        enemies.Add(enemy);
    }

    public IIterator<GameObject> GetIterator()
    {
        return new EnemyIterator(this);
    }

    // 구체적인 Iterator 클래스
    private class EnemyIterator : IIterator<GameObject>
    {
        private GameLevel level;
        private int index = 0;

        public EnemyIterator(GameLevel level)
        {
            this.level = level;
        }

        public bool HasNext()
        {
            return index < level.enemies.Count;
        }

        public GameObject Next()
        {
            if (HasNext())
            {
                return level.enemies[index++];
            }

            return null;
        }
    }
}

// 반복자 패턴 사용 예시
public class IteratorPattern : MonoBehaviour
{
    private GameLevel currentLevel;

    void Start()
    {
        // 게임 레벨 초기화 및 적 추가
        currentLevel = new GameLevel();
        currentLevel.AddEnemy(CreateEnemy("Enemy1"));
        currentLevel.AddEnemy(CreateEnemy("Enemy2"));
        currentLevel.AddEnemy(CreateEnemy("Enemy3"));

        // List<GameObject> list = new List<GameObject>();
        // list.Add(CreateEnemy("Enemy4"));
        // list.Add(CreateEnemy("Enemy5"));
        // list.Add(CreateEnemy("Enemy6"));
        // list.Add(CreateEnemy("Enemy7"));
        //
        // foreach (var o in list)
        // {
        //     DealDamage(o);
        // }
        
        // 반복자를 사용하여 모든 적에게 데미지 주기
        IIterator<GameObject> iterator = currentLevel.GetIterator();
        while (iterator.HasNext())
        {
            GameObject enemy = iterator.Next();
            DealDamage(enemy);
        }
    }

    private GameObject CreateEnemy(string name)
    {
        GameObject enemy = new GameObject(name);
        enemy.AddComponent<Enemy>();
        return enemy;
    }

    private void DealDamage(GameObject enemy)
    {
        Enemy enemyComponent = enemy.GetComponent<Enemy>();
        if (enemyComponent != null)
        {
            enemyComponent.TakeDamage(10);
            Debug.Log($"Dealt damage to {enemy.name}. Current health: {enemyComponent.Health}");
        }
    }
}

// 간단한 적 클래스
public class Enemy : MonoBehaviour
{
    public int Health { get; private set; } = 100;

    public void TakeDamage(int amount)
    {
        Health -= amount;
        if (Health <= 0)
        {
            Health = 0;
            Debug.Log($"{gameObject.name} is defeated!");
        }
    }
}