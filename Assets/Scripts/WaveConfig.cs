﻿using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Enemy wave config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject pathPrefab;
    [SerializeField] private float timeBetweenSpawns = .5f;
    [SerializeField] [Range(0, 1)] private float spawnRandomFactor = .3f;
    [SerializeField] private int numberOfEnemies = 5;
    [SerializeField] private float moveSpeed = 2f;

    public GameObject EnemyPrefab => enemyPrefab;

    public List<Transform> Waypoints
    {
        get
        {
            var waveWaypoints = new List<Transform>();
            foreach (Transform child in pathPrefab.transform)
            {
                waveWaypoints.Add(child);
            }
            return waveWaypoints;
        }
    }

    public float TimeBetweenSpawns => timeBetweenSpawns;

    public float SpawnRandomFactor => spawnRandomFactor;

    public int NumberOfEnemies => numberOfEnemies;

    public float MoveSpeed => moveSpeed;
}
