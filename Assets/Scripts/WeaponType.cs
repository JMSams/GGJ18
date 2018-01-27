using UnityEngine;
using System.Collections;

namespace FallingSloth.GGJ18
{
    [CreateAssetMenu(fileName = "NewWeaponType", menuName = "Weapon Type", order = 1)]
    public class WeaponType : ScriptableObject
    {
        new public string name;

        public int roundsPerClip = 7;

        public float reloadTime = 1f;

        public float timeBetweenRounds = .1f;
		
		public float damagePerRound = 10f;
    }
}