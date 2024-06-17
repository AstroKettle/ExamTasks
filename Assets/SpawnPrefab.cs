using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPrefab : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn;
    public Vector3 origin = Vector3.zero;
    public float radius = 20f;

    void Start()
    {
        Vector3 randomPosition = origin + Random.insideUnitSphere * radius;
        Instantiate(objectToSpawn, randomPosition, Quaternion.identity);
    }

}
