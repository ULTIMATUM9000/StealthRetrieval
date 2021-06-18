using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class CabinetScript : MonoBehaviour
{
    [SerializeField] private GameObject[] objects;

    private void Awake()
    {
        gameObject.SetActive(false);
        Instantiate(objects[Random.Range(0, objects.Length)], transform.position, Quaternion.identity);
    }
}
