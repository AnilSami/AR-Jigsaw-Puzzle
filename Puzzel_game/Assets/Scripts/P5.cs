using UnityEngine;

public class P5 : MonoBehaviour
{
    public GameObject firstImageTarget;
    public string objectNameOnFirstTarget = "Puzzle_5";

    void Update()
    {
        if (firstImageTarget && firstImageTarget.activeInHierarchy)
        {
            Rigidbody rb = firstImageTarget.transform.Find(objectNameOnFirstTarget)?.GetComponent<Rigidbody>();
            if (rb) 
            {
                firstImageTarget.SetActive(false); // Corrected line to deactivate the specific GameObject
            }
        }
    }
}
