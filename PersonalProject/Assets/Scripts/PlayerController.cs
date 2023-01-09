using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;

    private float _verticalMovement, _horizontalMovement;
    private float _zBound = 3.5f;

    private Rigidbody _rbPlayer;
    
    // Start is called before the first frame update
    void Start()
    {
        _rbPlayer = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();

        ConstraintPlayerMovement();
    }

    private void MovePlayer()
    {
        _horizontalMovement = Input.GetAxis("Horizontal");
        _verticalMovement = Input.GetAxis("Vertical");

        _rbPlayer.AddForce(Vector3.forward * _speed * _verticalMovement);
        _rbPlayer.AddForce(Vector3.right * _speed * _horizontalMovement);
    }

    private void ConstraintPlayerMovement()
    {
        if (transform.position.z < -_zBound) transform.position = new Vector3(transform.position.x, transform.position.y, -_zBound);
        if (transform.position.z > _zBound) transform.position = new Vector3(transform.position.x, transform.position.y, _zBound);
    }
}
