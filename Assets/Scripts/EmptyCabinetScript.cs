using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EmptyCabinetScript : MonoBehaviour
{
    public float maxprogress = 5;
    public float currentprogress;

    public ProgressBar progressBar;

    bool Colliding = false;

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
            print("Empty Cabinet");
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
            gameObject.SetActive(false);
    }
}
