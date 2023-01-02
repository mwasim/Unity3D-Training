using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    [SerializeField] private float _upperBound = 30f, _lowerBound = -30;

    //private void Start()
    //{
    //    Invoke(nameof(AutoDestroyGameObject), 1f);
    //}

    private void Update()
    {
        //Debug.Log("transform.position.z: " + transform.position.z + ", boundaryLimit: " + boundaryLimit);
        if (transform.position.z < _lowerBound || transform.position.z > _upperBound) AutoDestroyGameObject();
        //else if (transform.position.z > _upperBound) AutoDestroyGameObject();

        //animal passed the player, and player couldn't hit the animal
        if (transform.position.z < _lowerBound) Debug.Log("GAME OVER!");
    }

    private void AutoDestroyGameObject()
    {
        Destroy(gameObject);
    }
}
