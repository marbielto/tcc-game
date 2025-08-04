using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance { get; private set; }
    private List<EnemyDeath> enemies = new List<EnemyDeath>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        enemies.AddRange(FindObjectsOfType<EnemyDeath>());
        Debug.Log("Inimigos na fase: " + enemies.Count);
    }

    public void RegisterEnemy(EnemyDeath enemy)
    {
        if (!enemies.Contains(enemy))
        {
            enemies.Add(enemy);
            Debug.Log("Inimigo registrado. Total: " + enemies.Count);
        }
    }

    public void EnemyDefeated(EnemyDeath enemy)
    {
        if (enemies.Contains(enemy))
        {
            enemies.Remove(enemy);
            Debug.Log("Inimigo derrotado! Restantes: " + enemies.Count);
        }
    }

    public bool AllEnemiesDefeated()
    {
        return enemies.Count == 0;
    }
}
