using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportCanvas : MonoBehaviour
{
    public int SceneID;

    [SerializeField] private GameObject _background;
    [SerializeField] private GameObject _runes;
    [SerializeField] private GameObject _loadingText;

    public void SetSceneIDAndLoad(int id)
    {
        SceneID = id;
        DontDestroyOnLoad(this);
        StartCoroutine(LoadScene());
    }
    

    private IEnumerator LoadScene()
    {
        var scene = SceneManager.LoadSceneAsync(SceneID);
        scene.allowSceneActivation = false;

        LeanTween.moveLocalX(_background, 0, .5f);
        yield return new WaitForSeconds(.5f);
        LeanTween.moveLocalX(_loadingText, 0, .3f);
        LeanTween.moveLocalY(_runes, 1200, 2);
        yield return new WaitForSeconds(2f);
        scene.allowSceneActivation = true;
        LeanTween.moveLocalX(_background, -2000, .5f);
        LeanTween.moveLocalX(_loadingText, -2000, .5f);
        yield return new WaitForSeconds(.5f);
        PlayerInteractions.SetPlayerInteracting(false);
        Destroy(gameObject);
    }
}
