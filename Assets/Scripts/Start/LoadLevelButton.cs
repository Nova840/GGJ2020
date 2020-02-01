using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelButton : MonoBehaviour {

    [SerializeField]
    private string levelToLoad = "";

    public void OnButtonClick() {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
        SceneManager.LoadScene(levelToLoad, LoadSceneMode.Additive);
    }

}