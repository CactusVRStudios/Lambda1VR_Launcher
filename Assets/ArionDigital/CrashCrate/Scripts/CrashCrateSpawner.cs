namespace ArionDigital
{
    using UnityEngine;

    public class CrashCrateSpawner : MonoBehaviour
    {
        public enum LODLevel
        {
            LOD0,
            LOD1,
            LOD2
        }
        public LODLevel _LODLevel;
        public GameObject crashCrateLOD0;
        public GameObject crashCrateLOD1;
        public GameObject crashCrateLOD2;
        private GameObject spawnedCrate;

        private void Start()
        {
            if (_LODLevel == LODLevel.LOD0)
            {
                SpawnLOD0();
            }
            else if (_LODLevel == LODLevel.LOD1)
            {
                SpawnLOD1();
            }
            else if (_LODLevel == LODLevel.LOD2)
            {
                SpawnLOD2();
            }
        }

        public void SpawnLOD0()
        {
            if (spawnedCrate)
            {
                Destroy(spawnedCrate);
            }
            spawnedCrate = Instantiate(crashCrateLOD0);
        }

        public void SpawnLOD1()
        {
            if (spawnedCrate)
            {
                Destroy(spawnedCrate);
            }
            spawnedCrate = Instantiate(crashCrateLOD1);
        }

        public void SpawnLOD2()
        {
            if (spawnedCrate)
            {
                Destroy(spawnedCrate);
            }
            spawnedCrate = Instantiate(crashCrateLOD2);
        }
    }
}