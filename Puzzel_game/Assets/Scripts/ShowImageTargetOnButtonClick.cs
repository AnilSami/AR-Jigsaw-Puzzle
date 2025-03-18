using UnityEngine;

public class ShowImageTargetOnButtonClick : MonoBehaviour
{
    public GameObject Whole_Puzzle;

    void Start()
    {
        if (Whole_Puzzle != null)
        {
            Whole_Puzzle.SetActive(false);
        }
    }

    public void OnButtonClick()
    {
        if (Whole_Puzzle != null)
        {
            Whole_Puzzle.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Whole_Puzzle GameObject not assigned in the inspector.");
        }
    }
}
