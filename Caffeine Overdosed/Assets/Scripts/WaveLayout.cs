using UnityEngine;

[System.Serializable]
public class WaveLayout {
    public float spawnRate;
    public WaveGroup[] minions;
    [System.Serializable]
    public class WaveGroup
    {
        public GameObject minion;
        public int count;
    }  
}