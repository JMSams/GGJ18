using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace FallingSloth.GGJ18
{
    [CreateAssetMenu(fileName = "NewEnemyType", menuName = "Enemy Type", order = 1)]
    public class EnemyType : ScriptableObject
    {
        public Enemy enemyPrefab;

        public int startingWave;
    }
}
