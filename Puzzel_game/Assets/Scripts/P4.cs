using UnityEngine;

public class P4 : MonoBehaviour
{
    public GameObject firstImageTarget;
    public string objectNameOnFirstTarget = "Puzzle_4";

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
