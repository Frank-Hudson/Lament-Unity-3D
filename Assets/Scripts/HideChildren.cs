using UnityEngine;

public class HideChildren : MonoBehaviour
{
    public void HideAllChildren()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }
}
