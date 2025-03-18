using UnityEngine;

public class ObjectSelection : MonoBehaviour
{
    public Material selectedMaterial;
    private GameObject selectedObject;
    public Material originalMaterial;
    private Transform selectedObjectOriginalParentTransform;
    private bool isAnObjectSelected;

    public GameObject selectedCube; // Add this to store the selected cube

    void Start()
    {
        isAnObjectSelected = false;
    }

    void Update()
    {
        GameObject mainCamera = Camera.main.gameObject;
        Vector3 origin = mainCamera.transform.position;
        Vector3 direction = mainCamera.transform.forward;
        Ray ray = new Ray(origin, direction);
        RaycastHit hit;
        bool isThereAHit = Physics.Raycast(ray, out hit);

        if (isAnObjectSelected)
        {
            if (getUserTap())
            {
                isAnObjectSelected = false;
                selectedObject.transform.parent = selectedObjectOriginalParentTransform;

                // Clear the selected cube
                selectedCube = null;
            }
        }
        else
        {
            if (isThereAHit && hit.collider.gameObject.name != "GroundPlane")
            {
                if (getUserTap())
                {
                    selectedObject = hit.collider.gameObject;
                    // Check if the selected object should be excluded
                    if (!IsExcludedObject(selectedObject))
                    {
                        if (!isAnObjectSelected)
                        {
                            originalMaterial = selectedObject.GetComponent<Renderer>().material;
                        }
                        isAnObjectSelected = true;
                        selectedObject.transform.parent = mainCamera.transform;

                        // Set the selected cube
                        selectedCube = selectedObject;
                    }
                }
            }
        }
    }

    private bool IsExcludedObject(GameObject obj)
    {
        // You can add conditions here to check if the object should be excluded.
        // For example, check the tag or name.
        return obj.CompareTag("ExcludeTag") || obj.name == "Puzzle_Piece1" || obj.name == "Puzzle_Piece2" || obj.name == "Puzzle_Piece3" || obj.name == "Puzzle_Piece4" || obj.name == "Puzzle_Piece5" || obj.name == "Puzzle_Piece6" || obj.name == "Whole_Puzzle";
    }

    private bool getUserTap()
    {
        bool isTap = false;
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Vector2 p = touch.position;
                float fractScreenBorder = 0.3f;
                if (p.x > fractScreenBorder * Screen.width && p.x < (1 - fractScreenBorder) * Screen.width &&
                    p.y > fractScreenBorder * Screen.height && p.y < (1 - fractScreenBorder) * Screen.height)
                {
                    isTap = true;
                }
            }
        }
        else
        {
            isTap = Input.anyKeyDown && Input.GetKey(KeyCode.Space);
        }
        return isTap;
    }
}
