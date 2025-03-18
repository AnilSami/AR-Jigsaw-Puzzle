using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    public float snapDistance = 0.1f; // Adjust this value to set the snap distance
    public Transform[] snapPoints; // Array to store the predefined snap points

    private bool isSelected = false;
    private Vector3 originalPosition;
    private Quaternion originalRotation;

    void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    void Update()
    {
        if (isSelected)
        {
            // Move the puzzle piece based on user input or touch
            MovePuzzlePiece();

            // Check for snapping to predefined points when unselected
            if (!IsUserInteracting())
            {
                TrySnapToNearestPoint();
            }
        }
    }

    private void MovePuzzlePiece()
    {
        // Implement your code for moving the puzzle piece here
        // For example, use Input.GetAxis("Horizontal") and Input.GetAxis("Vertical") for keyboard input
        // Or use Input.touches for touch input
        // Move the puzzle piece using transform.Translate or transform.position +=
    }

    private void TrySnapToNearestPoint()
    {
        foreach (Transform snapPoint in snapPoints)
        {
            float distance = Vector3.Distance(transform.position, snapPoint.position);
            if (distance < snapDistance)
            {
                SnapToPoint(snapPoint);
                break;
            }
        }
    }

    private void SnapToPoint(Transform snapPoint)
    {
        // Snap the puzzle piece to the predefined point
        transform.position = snapPoint.position;
        transform.rotation = snapPoint.rotation;

        // Optionally, disable rigidbody to prevent physics interactions
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
        }
    }

    private bool IsUserInteracting()
    {
        return Input.GetMouseButton(0) || Input.touchCount > 0;
    }

    public void SelectPiece()
    {
        isSelected = true;
        // Optionally, store initial properties for restoration when deselected
    }

    public void DeselectPiece()
    {
        isSelected = false;
        // Optionally, reset the puzzle piece to its original state
        transform.position = originalPosition;
        transform.rotation = originalRotation;
    }
}
