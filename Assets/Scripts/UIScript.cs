using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    [SerializeField] private Text numberOfDocuments;
    [SerializeField] private Text numberOfKeys;
    private PlayerController _player;
    private GameManager _gameManager;

    private void Awake()
    {
        _player = FindObjectOfType<PlayerController>();
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        numberOfDocuments.text = $"Documents: {_player.DocumentsFound}/{_gameManager.NumberOfDocuments()}";
        numberOfKeys.text = $"Keys: {_player.KeysFound}/{_gameManager.NumberOfKeys()}";
    }
}
