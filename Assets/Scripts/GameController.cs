using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Button button;
    public GameObject start;
    public GameObject zombie;
    public Transform spawn;
    public SimpleSmoothMouseLook mouseScript;
    public GameObject display;

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(TaskOnClick);
        mouseScript.lockCursor = false;
        display.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void TaskOnClick()
    {
        start.SetActive(false);
        display.SetActive(true);
        StartCoroutine(Spawn());
        mouseScript.lockCursor = true;
    }
    private IEnumerator Spawn()
    {
        while (true)
        {
            float randX = Random.Range(9, 15);
            float randZ = Random.Range(9, 15);
            Vector3 random = new Vector3(randX, 2, randZ);
            Instantiate(zombie, random, Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }
    }
}
