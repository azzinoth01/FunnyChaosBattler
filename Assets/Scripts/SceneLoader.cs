using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        StartCoroutine(Skip(sceneName));
       
    }

    public IEnumerator Skip(string sceneName)
    {

        yield return new WaitForSeconds(2);

        SceneManager.LoadScene(sceneName);

    }
}
