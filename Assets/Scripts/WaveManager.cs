using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using FallingSloth.UI;
using System.Text;

namespace FallingSloth.GGJ18
{
    public class WaveManager : MonoBehaviour
    {
        public Text currentWaveText;

        public Transform spawnPosition, stopPosition;

        int currentWave = 0;

        public List<EnemyType> enemyPrefabs;
        List<EnemyType> waveEnemyPrefabs;

        List<Enemy> waveEnemies;

        public Animator interwaveScreen;

        bool checkForWaveEnd = false;

        int waveEnemyCount
        {
            get
            {
                return Mathf.RoundToInt(Mathf.Pow(currentWave, 1.4f) + 5 + Mathf.Sin(currentWave));
            }
        }
        float waveSpawnInterval
        {
            get
            {
                return (1f / (Mathf.Pow(currentWave, 1.2f) + 2 - Mathf.Sin(currentWave))) * 8f;
            }
        }

        void Start()
        {
            currentWave = 0;

            waveEnemyPrefabs = new List<EnemyType>();
            waveEnemies = new List<Enemy>();

            StartNewWave();
        }
        
        public void StartNewWave()
        {
            currentWave++;

            currentWaveText.text = "Current Wave: " + currentWave;

            waveEnemyPrefabs.Clear();
            foreach (EnemyType e in enemyPrefabs)
            {
                if (e.startingWave <= currentWave)
                    waveEnemyPrefabs.Add(e);
            }

            waveEnemies.Clear();

            StartCoroutine(SpawnEnemies());

            checkForWaveEnd = true;
        }

        void Update()
        {
            if (checkForWaveEnd)
            {
                if (waveEnemies.Count < waveEnemyCount)
                    return;

                foreach (Enemy e in waveEnemies)
                    if (e != null) return;

                interwaveScreen.SetTrigger("Open");
                checkForWaveEnd = false;
            }
        }

        IEnumerator SpawnEnemies()
        {
            int count = 0;
            do
            {
                Enemy tempEnemy = Instantiate<Enemy>(waveEnemyPrefabs[Random.Range(0, waveEnemyPrefabs.Count)].enemyPrefab);
                tempEnemy.transform.position = spawnPosition.position;
                
                tempEnemy.maxPosition = stopPosition;

                waveEnemies.Add(tempEnemy);

                yield return new WaitForSeconds(waveSpawnInterval);
                count++;
            } while (count < waveEnemyCount);
        }
    }
}