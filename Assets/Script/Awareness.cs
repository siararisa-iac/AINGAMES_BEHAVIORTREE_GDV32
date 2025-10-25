using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Awareness : MonoBehaviour
{
    [SerializeField]
    private Transform[] enemies;
    [SerializeField]
    private float detectionRange;

    public bool IsEnemyNear()
    {
        for(int i = 0; i < enemies.Length; i++)
        {
            return (Vector3.Distance(transform.position, enemies[i].position) < detectionRange);
        }
        return false;
    }
}
