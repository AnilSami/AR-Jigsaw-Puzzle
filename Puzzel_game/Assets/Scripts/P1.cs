using UnityEngine;

public class P1 : MonoBehaviour
{
    public GameObject firstImageTarget;
    public string objectNameOnFirstTarget = "Puzzle_1";

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
