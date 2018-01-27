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

        public HealthBar healthBarPrefab;

        public Transform spawnPosition, stopPosition;

        int currentWave = 0;

        public List<EnemyType> enemyPrefabs;
        List<EnemyType> waveEnemyPrefabs;

        List<Enemy> waveEnemies;

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

        [HideInInspector]
        public bool gameInSession = false;

        RectTransform gameUI;

        void Start()
        {
            gameUI = GameObject.Find("GameUI").transform as RectTransform;
        }

        public void StartNewGame()
        {
            StartCoroutine(_StartNewGame());
        }

        IEnumerator _StartNewGame()
        {
            yield return new WaitForSeconds(1.5f);

            currentWave = 0;

            waveEnemyPrefabs = new List<EnemyType>();
            waveEnemies = new List<Enemy>();

            gameInSession = true;

            StartNewWave();
        }
        
        public void StartNewWave()
        {
            currentWave++;

            waveEnemyPrefabs.Clear();
            foreach (EnemyType e in enemyPrefabs)
            {
                if (e.startingWave <= currentWave)
                    waveEnemyPrefabs.Add(e);
            }

            waveEnemies.Clear();

            StartCoroutine(SpawnEnemies());

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Starting wave " + currentWave);
            sb.AppendLine("Enemy count: " + waveEnemyCount);
            sb.Append("Spawn interval: " + waveSpawnInterval);
            Debug.Log(sb);
        }

        IEnumerator SpawnEnemies()
        {
            int count = 0;
            do
            {
                Enemy tempEnemy = Instantiate<Enemy>(waveEnemyPrefabs[Random.Range(0, waveEnemyPrefabs.Count)].enemyPrefab);
                tempEnemy.transform.position = spawnPosition.position;

                HealthBar tempBar = Instantiate<HealthBar>(healthBarPrefab);
                tempBar.transform.SetParent(gameUI, false);
                tempBar.maxValue = tempEnemy.maxHealth;
                tempBar.currentValue = tempEnemy.maxHealth;
                tempEnemy.healthBar = tempBar;

                tempEnemy.maxPosition = stopPosition;

                waveEnemies.Add(tempEnemy);

                yield return new WaitForSeconds(waveSpawnInterval);
                count++;
            } while (count < waveEnemyCount);
        }
    }
}