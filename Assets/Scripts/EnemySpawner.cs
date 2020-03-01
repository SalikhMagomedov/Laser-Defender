using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<WaveConfig> waveConfigs;
    [SerializeField] private bool looping = false;

    private IEnumerator Start()
    {
        do
        {
            yield return SpawnAllWaves();
        } while (looping);
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig wave)
    {
        for (int i = 0; i < wave.NumberOfEnemies; i++)
        {
            var enemy = Instantiate(wave.EnemyPrefab, wave.Waypoints[0].position, Quaternion.identity);
            enemy.GetComponent<EnemyPathing>().WaveConfig = wave;
            yield return new WaitForSeconds(wave.TimeBetweenSpawns);
        }
    }

    private IEnumerator SpawnAllWaves()
    {
        foreach (var wave in waveConfigs)
        {
            yield return SpawnAllEnemiesInWave(wave);
        }
    }
}
