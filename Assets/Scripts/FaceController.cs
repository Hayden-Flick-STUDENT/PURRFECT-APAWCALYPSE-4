using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaceController : MonoBehaviour
{
    public Sprite[] oliveFaces;
    public Sprite[] patchesFaces;
    public Image image;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator ChangeFaceForSeconds(Sprite newSprite, Sprite current, float seconds)
    {
        image.sprite = newSprite;
        yield return new WaitForSeconds(1);
        image.sprite = current;
    }
}
