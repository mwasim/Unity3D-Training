using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int _jumpForce = 10;
    [SerializeField] private float _gravityModifier = 1.5f;
    [SerializeField] private bool _isOnGround = true;

    private Animator _playerAnim;
    private bool _isGameOver = false;
    public bool IsGameOver => _isGameOver;

    private Rigidbody _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _playerAnim = GetComponent<Animator>();

        Physics.gravity *= _gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isOnGround && !_isGameOver)
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _isOnGround = false;

            _playerAnim.SetTrigger("Jump_trig");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            //Debug.Log("Collided with the ground");
            _isOnGround = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            _isGameOver = true;

            _playerAnim.SetBool("Death_b", true);
            _playerAnim.SetInteger("DeathType_int", 1);

            Debug.Log("Game Over");
        }
    }
}
