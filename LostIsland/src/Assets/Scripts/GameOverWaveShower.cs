using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace FallingSloth.GGJ18
{
    public class GameOverWaveShower : MonoBehaviour
    {
        void Awake()
        {
            //GetComponent<Text>().text = "Highest wave: " + WaveManager.saveManager.data.highestWave;
            GetComponent<Text>().text = "Highest wave: n/a";
        }
    }
}