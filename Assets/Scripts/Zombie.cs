using System.Collections;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public GameObject zomb;
    public GameObject mush;
    public GameObject player;
    public bool isDead;
    public GameObject start;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        start = GameObject.Find("titlescreen");
        mush.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("titlescreen") == null)
        {
            transform.rotation = Quaternion.LookRotation(transform.position - player.transform.position);
            if (!isDead)
            {
                transform.Translate(0, 0, -2f * Time.deltaTime);
            }
            if (isDead)
            {
                mush.SetActive(true);
                zomb.SetActive(false);
            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (!isDead)
        {
            if (collision.gameObject.CompareTag("Bullet"))
            {
                isDead = true;
                StartCoroutine(DeleteAfterDie());
            }
        }
    }
    public IEnumerator DeleteAfterDie()
    {
        int i = 0;
        while (i < 3)
        {
            i++;
            yield return new WaitForSeconds(1);
        }
        Destroy(gameObject);
    }
}
