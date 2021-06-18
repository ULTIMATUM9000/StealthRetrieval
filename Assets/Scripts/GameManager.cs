using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private DocumentScript[] _documents;
    private KeyScript[] _key;
    [SerializeField] private GameObject cabinet;
    [SerializeField] private Transform[] cabinetLocations;
    private PlayerController _player;

    private void Awake()
    {
        foreach (var t in cabinetLocations)
        {
            Instantiate(cabinet, t.position, Quaternion.identity);
        }
    }

    private void Start()
    {
        _documents = FindObjectsOfType<DocumentScript>();
        _key = FindObjectsOfType<KeyScript>();
        _player = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        if (_player.isCaught)
        {
            SceneManager.LoadScene("Main Game Scene");
        }
    }

    public int NumberOfDocuments()
    {
        return _documents.Length;
    }

    public int NumberOfKeys()
    {
        return _key.Length;
    }
    
}
