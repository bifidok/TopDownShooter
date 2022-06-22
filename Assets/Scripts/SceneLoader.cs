using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void OnReload()
    {
        SceneManager.LoadScene(0);
    }
}
