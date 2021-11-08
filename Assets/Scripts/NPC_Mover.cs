using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC_Mover : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    public Transform randomPoint;
    public NPC_Spawner spawnerNPC;
    private Animator anim;

    public void SetDestination(Vector3 position)
    {
        _agent.SetDestination(position);
        StartCoroutine(Despawn());
        
    }

    IEnumerator Despawn()
    {
        while (true)
        {
            float distance = Vector3.Distance(gameObject.transform.position, randomPoint.position);
            yield return new WaitForSeconds(0.01f);
            if (distance <= 0.1f)
            {
                yield return new WaitForSeconds(0.1f);
                Destroy(gameObject);
                spawnerNPC._npcCount--;
                yield break;
            }
            if ( distance <= 3f)
            {
                yield return new WaitForSeconds(2f);
                Destroy(gameObject);
                spawnerNPC._npcCount--;
                yield break;
            }
        }
    }
    private void StandTime()
    {
        float distanceToStop = Vector3.Distance(gameObject.transform.position, randomPoint.position);
        if (distanceToStop <= 3f)
        {
            anim.SetTrigger("Stand");
        }
    }
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        StandTime();
    }
}
