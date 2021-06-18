using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KeyScript : MonoBehaviour
{
    private GameManager _gameManager;

    public float maxprogress = 5;
    public float currentprogress;

    public ProgressBar progressBar;

    bool Colliding = false;

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }
    private void Start()
    {
        currentprogress = 0f;
        progressBar.Set(currentprogress);
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            Colliding = true;
            StartCoroutine(WaitOneSecToDisappear(other));
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            currentprogress = 0;
            progressBar.Set(currentprogress);
            Colliding = false;
            StopCoroutine(WaitOneSecToDisappear(other));
        }
    }

    IEnumerator WaitOneSecToDisappear(Collision other)
    {
        currentprogress += 1.0f * Time.deltaTime;
        progressBar.Set(currentprogress);

        yield return new WaitForSeconds(1f);

        if (Colliding == true)
        {
            var player = other.gameObject.GetComponent<PlayerController>();
            player.KeysFound = CollectKeys(player.KeysFound);
        }
    }

    private int CollectKeys(int current)
    {
        if (current < _gameManager.NumberOfKeys())
        {
            current++;
            gameObject.SetActive(false);
        }
        return current;
    }
}
