using System.Collections;
using TMPro;
using UnityEngine;

public class ChraracterController : MonoBehaviour
{
    public float turnSpeed;
    public float walkSpeed;
    public float health;
    public float weaponOneAmmo;
    public float weaponTwoAmmo;
    public GameObject weaponOne;
    public GameObject weaponTwo;
    public GameObject weaponThree;
    public GameObject start;
    public TextMeshProUGUI healthDisplay;
    public GameObject bullet;
    public GameObject slash;

    // Start is called before the first frame update
    void Start()
    {
        health = 100f;
        weaponTwo.SetActive(false);
        weaponThree.SetActive(false);
        slash.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //is the game running yet?
        if (start.activeSelf == false)
        {
            //check running input
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                walkSpeed = 15f;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                walkSpeed = 5f;
            }
            //walk forward
            float walk = Input.GetAxis("Vertical") * Time.deltaTime * walkSpeed;
            transform.Translate(0, 0, walk);
            //strafe
            float strafe = Input.GetAxis("Horizontal") * Time.deltaTime * walkSpeed;
            transform.Translate(strafe, 0, 0);

            //look (deprecated)




            //weapon selection (to be changed)
            if (Input.GetKey(KeyCode.Alpha1))
            {
                weaponOne.SetActive(true);
                weaponTwo.SetActive(false);
                weaponThree.SetActive(false);
            }
            if (Input.GetKey(KeyCode.Alpha2))
            {
                weaponOne.SetActive(false);
                weaponTwo.SetActive(true);
                weaponThree.SetActive(false);
            }
            if (Input.GetKey(KeyCode.Alpha3))
            {
                weaponOne.SetActive(false);
                weaponTwo.SetActive(false);
                weaponThree.SetActive(true);
            }
            //die (to be changed
            if (health == 0f)
            {
                Debug.Log("You died!");
            }
            //display health on ui
            healthDisplay.text = "Health: " + health;
            //shoot gun or melee
            if (Input.GetMouseButtonDown(0))
            {
                if (weaponThree.activeSelf)
                {
                    slash.SetActive(true);
                    StartCoroutine(Slash());
                }
                else
                {
                    Vector3 shotPoint = transform.position + transform.forward * 2;
                    GameObject shot = Instantiate(bullet, shotPoint, transform.rotation);
                    Destroy(shot, 2f);
                }
            }
        }
    }
    //zombie hit 
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Zombie"))
        {
            if (collision.gameObject.GetComponent<Zombie>().isDead == false)
            {
                health -= 5f;
            }
        }
    }
    //show melee effect
    public IEnumerator Slash()
    {
        yield return new WaitForSeconds(0.75f);
        slash.SetActive(false);
    }
}
