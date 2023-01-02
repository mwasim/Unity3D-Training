using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    private Material _material;

    void Start()
    {
        //transform.position = new Vector3(0, 5, 1);
        //transform.localScale = Vector3.one * 1.5f;

        transform.position = new Vector3(Random.Range(0, 3), Random.Range(0, 5), 1);

        transform.localScale = Vector3.one * Random.Range(1.2f, 4f);

        _material = Renderer.material;

        //_material.color = new Color(1f, 0.0f, 0.5f, 0.4f);
        _material.color = new Color(Random.Range(0.1f, 1.0f), Random.Range(0.1f, 1.0f), Random.Range(0.1f, 1.0f), 0.6f);
    }

    void Update()
    {
        //transform.position = new Vector3(Random.Range(0, 3), Random.Range(0, 5), 1);

        //transform.localScale = Vector3.one * Random.Range(1.2f, 3f);

        transform.Rotate(Random.Range(10f, 20f) * Time.deltaTime, Random.Range(15f, 30f) * Time.deltaTime, Random.Range(5f, 15f) * Time.deltaTime);

        //_material.color = new Color(Random.Range(0.1f, 1.0f), Random.Range(0.1f, 1.0f), Random.Range(0.1f, 1.0f), 0.6f);
    }
}
