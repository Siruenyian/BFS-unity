using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MoveLevel : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private GameObject loadingscreen;
    [SerializeField]private Slider loadingbar;
    private int nextsceneLoad;
    private int reloadscene;

    void Start()
    {
       
        //buildindex from 0
        //stage 1 has build of 2, 3, 4, so on
        reloadscene = SceneManager.GetActiveScene().buildIndex;
        nextsceneLoad = reloadscene + 1;
  
    }

    
    public void ReloadLevel()
    {
        SceneManager.LoadScene(reloadscene);
    }
    public void LoadNext()
    {
        SceneManager.LoadScene(nextsceneLoad);
    }

    //handle quiting
    public void QuitToMain()
    {
        GameManager.Instance.UnpauseGame();
        SceneManager.LoadScene("Menu");
    }

    public void LoadLevel(int id)
    {
        StartCoroutine(loadasync(id));

    }
    IEnumerator loadasync(int sceneid)
    {
        AsyncOperation loading = SceneManager.LoadSceneAsync(sceneid);
        loadingscreen.SetActive(true);
        while (!loading.isDone)
        {
            float loadvalue = Mathf.Clamp01(loading.progress / 0.9f);
            loadingbar.value = loadvalue;
            //Debug.Log("Sudah load " + loadvalue);
            yield return null;
        }
    }
}
