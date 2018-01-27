using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FallingSloth.GGJ18
{
    [Serializable]
    public class EnemyType
    {
        public string name;

        public Enemy enemyPrefab;

        public int startingWave;
    }
}
