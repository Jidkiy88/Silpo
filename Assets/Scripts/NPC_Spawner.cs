using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _NPC;
    [SerializeField] private Transform[] _randomSpawnPoint;
    [SerializeField] private Transform[] _randomMovePoint;

    public int _npcCount = 0;

    
    

    private void Start()
    {
        StartCoroutine(SpawnNPC());
    }
    
    IEnumerator SpawnNPC()
    {
        while (true)
        {
            if (_npcCount < 10)
            {
                Transform point = _randomMovePoint[Random.Range(0, _randomMovePoint.Length)];
                Transform spawnPoint = _randomSpawnPoint[Random.Range(0, _randomSpawnPoint.Length)];
                if (point.position != spawnPoint.position)
                {
                GameObject NPC = Instantiate(_NPC[Random.Range(0, _NPC.Length)], _randomSpawnPoint[Random.Range(0, _randomSpawnPoint.Length)]);
                
                NPC.GetComponent<NPC_Mover>().randomPoint = point;

                NPC.GetComponent<NPC_Mover>().SetDestination(point.position);

                NPC.GetComponent<NPC_Mover>().spawnerNPC = this;
                _npcCount++;
                }
                else
                {
                    continue;
                }
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
