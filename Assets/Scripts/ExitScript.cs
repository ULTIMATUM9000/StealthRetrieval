using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitScript : MonoBehaviour
{
    private PlayerController _player;
    private GameManager _gameManager;

    private void Awake()
    {
        _player = FindObjectOfType<PlayerController>();
        _gameManager = FindObjectOfType<GameManager>();
    }
    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            if(_player.DocumentsFound == _gameManager.NumberOfDocuments() && _player.KeysFound == _gameManager.NumberOfKeys())
            {
                SceneManager.LoadScene("Main Menu");
            }
        }
    }
}
