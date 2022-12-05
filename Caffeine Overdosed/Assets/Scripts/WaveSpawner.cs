using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesLeft = 0; 
    public WaveLayout[] waves;
    public Transform spawnPoint;
        
    public float timeBetweenWaves = 5f;
    private float countdown = 2f;
    public TextMeshProUGUI waveCountdownText;
    public GameManager gameManager;

    private int waveNumber = 0;
    // Update is called once per frame
    void Update()
    {
        if(EnemiesLeft > 0){
            return;
        }
        if (EnemiesLeft == 0 && waveNumber == waves.Length)
		{
            gameManager.WinLevel();
		}
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }
        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0F, Mathf.Infinity);
        waveCountdownText.text = string.Format("{0:00.00}",countdown);
    }
     IEnumerator SpawnWave()
    {
        WaveLayout wave = waves[waveNumber];
        for(int j = 0; j < wave.minions.Length; j++){
            EnemiesLeft += wave.minions[j].count;
            for (int i = 0; i < wave.minions[j].count; i++)
            {
                SpawnEnemy(wave.minions[j].minion);
                yield return new WaitForSeconds(1f / wave.spawnRate);
            }
        }
		waveNumber++;
    }

    void SpawnEnemy(GameObject minion)
    {
        Instantiate(minion, spawnPoint.position, spawnPoint.rotation);
    }
}
