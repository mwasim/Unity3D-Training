using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Basic Settings")]
    [SerializeField] private int _jumpForce = 10;
    [SerializeField] private int _doubleJumpForce = 6;
    [SerializeField] private float _gravityModifier = 1.5f;
    [SerializeField] private bool __isOnGround = true;

    [Header("Particle Effects")]
    [SerializeField] private ParticleSystem _explosionParticles;
    [SerializeField] private ParticleSystem _dirtSplatterParticles;

    [Header("Audio Settings")]
    [SerializeField] private AudioClip _jumpSound;
    [SerializeField] private AudioClip _crashSound;
    

    private Animator _playerAnim;
    private AudioSource _playerAudioSource;

    private bool _isGameOver = false;
    public bool IsGameOver => _isGameOver;

    private Rigidbody _rigidbody;

    private bool _doubleJumpUsed;

    //private int _inAirJumpCount = 0;
    //const int MaxJumpCount = 2;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _playerAnim = GetComponent<Animator>();
        _playerAudioSource = GetComponent<AudioSource>();

        Physics.gravity *= _gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && __isOnGround && !_isGameOver)
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            __isOnGround = false;

            _playerAnim.SetTrigger("Jump_trig");

            if (_dirtSplatterParticles != null)
                _dirtSplatterParticles.Stop();

            _playerAudioSource.PlayOneShot(_jumpSound, 1f);

            //_inAirJumpCount++;
            _doubleJumpUsed = false;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && !__isOnGround && !_doubleJumpUsed)
        {
            _doubleJumpUsed = true;
            _rigidbody.AddForce(Vector3.up * _doubleJumpForce, ForceMode.Impulse);
            _playerAnim.Play("Running_Jump", 3, 0f);
            _playerAudioSource.PlayOneShot(_jumpSound, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            //Debug.Log("Collided with the ground");
            __isOnGround = true;
            //_inAirJumpCount = 0; //reset jump count

            if (_dirtSplatterParticles != null && _dirtSplatterParticles.isStopped)
                _dirtSplatterParticles.Play();

        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            _isGameOver = true;

            _playerAnim.SetBool("Death_b", true);
            _playerAnim.SetInteger("DeathType_int", 1);

            //play smoke/explosion particle effect
            if (_explosionParticles != null)
                _explosionParticles.Play();

            if (_dirtSplatterParticles != null)
                _dirtSplatterParticles.Stop();

            _playerAudioSource.PlayOneShot(_crashSound, 1f);

            Debug.Log("Game Over");
        }
    }
}
