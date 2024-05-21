using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public GameObject knife;
    public GameObject pipe;

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
