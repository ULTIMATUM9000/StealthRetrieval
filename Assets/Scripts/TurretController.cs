using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;

    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(Vector3.up * (rotationSpeed * Time.deltaTime));
    }
}
