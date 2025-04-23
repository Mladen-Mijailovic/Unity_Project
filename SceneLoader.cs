using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadHouse(string sceneName) {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }

  
}
