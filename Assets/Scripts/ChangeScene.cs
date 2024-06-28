using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void GoTo(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
