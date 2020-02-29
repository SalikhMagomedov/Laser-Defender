using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<WaveConfig> waveConfigs;

    private int startigWave = 0;

    private void Start()
    {
        var currentWave = waveConfigs[startigWave];
        StartCoroutine(SpawnAllEnemiesInWave(currentWave));
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig wave)
    {
        for (int i = 0; i < wave.NumberOfEnemies; i++)
        {
            Instantiate(wave.EnemyPrefab, wave.Waypoints[0].position, Quaternion.identity);
            yield return new WaitForSeconds(wave.TimeBetweenSpawns);
        }
    }
}
