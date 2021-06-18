using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("MOVEMENT")]
    [SerializeField] private float movementSpeed;
    //[SerializeField] private float turnSmoothTime;
    private Vector3 _movement;
    private Rigidbody _rigidbody;
    //private float _turnSmoothVelocity;

    [Header("ITEMS")] 
    internal int DocumentsFound;
    internal int KeysFound;

    public bool isCaught;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        isCaught = false;
    }

    private void Update()
    {
        _movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        _movement.Normalize();
        PlayerTurn();
    }

    private void PlayerTurn()
    {
        //https://youtu.be/4HpC--2iowE
        if (_movement != Vector3.zero)
        {
            var targetAngle = Mathf.Atan2(_movement.x, _movement.z) * Mathf.Rad2Deg;
            //var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity,
            //    turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
        }
    }

    private void FixedUpdate()
    {
        _rigidbody.MovePosition(_rigidbody.position + _movement * (movementSpeed * Time.fixedDeltaTime));
    }

}
