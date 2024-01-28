using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlLoader : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        StartCoroutine(Skip(sceneName));

    }

    public IEnumerator Skip(string sceneName)
    {

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(sceneName);

    }
}