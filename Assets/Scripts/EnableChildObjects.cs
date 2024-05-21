using UnityEngine;

public class EnableChildObjects : MonoBehaviour
{
    public GameObject[] emptyGameObjects;
    private int[] activeChildIndex; // Stores the index of the currently active child for each empty game object

    void Start()
    {
        // Check if the emptyGameObjects array is properly set
        if (emptyGameObjects == null || emptyGameObjects.Length == 0)
        {
            Debug.LogError("Empty game objects array is not set!");
            return;
        }

        activeChildIndex = new int[emptyGameObjects.Length];

        // Initialize the activeChildIndex array with 0 (assuming the first child of each empty game object is initially active)
        for (int i = 0; i < activeChildIndex.Length; i++)
        {
            activeChildIndex[i] = 0;
        }

        UpdateActiveChildObjects();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            // Increment the active child index for each empty game object
            for (int i = 0; i < activeChildIndex.Length; i++)
            {
                GameObject emptyGameObject = emptyGameObjects[i];
                if (emptyGameObject != null && emptyGameObject.transform.childCount > 0)
                {
                    activeChildIndex[i]++;
                    activeChildIndex[i] %= emptyGameObject.transform.childCount;
                }
            }

            UpdateActiveChildObjects();
        }
    }

    void UpdateActiveChildObjects()
    {
        // Iterate through each empty game object
        for (int i = 0; i < emptyGameObjects.Length; i++)
        {
            GameObject emptyGameObject = emptyGameObjects[i];

            // Check if the empty game object is valid
            if (emptyGameObject == null)
            {
                Debug.LogWarning("Empty game object is null!");
                continue;
            }

            // Deactivate all children of the empty game object
            for (int j = 0; j < emptyGameObject.transform.childCount; j++)
            {
                Transform child = emptyGameObject.transform.GetChild(j);
                child.gameObject.SetActive(false);
            }

            // Activate the currently active child of the empty game object
            int activeIndex = activeChildIndex[i];
            if (activeIndex >= 0 && activeIndex < emptyGameObject.transform.childCount)
            {
                Transform activeChild = emptyGameObject.transform.GetChild(activeIndex);
                activeChild.gameObject.SetActive(true);
            }
        }
    }
}
