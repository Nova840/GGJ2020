using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenechange : MonoBehaviour
{
    // Start is called before the first frame update
    public void gotoStartScene()
    {
        SceneManager.LoadScene(2);

    }
    public void goCreditsScene()
    {
        SceneManager.LoadScene(1);

    }
    public void goTitleScene()
    {
        SceneManager.LoadScene(0);

    }
}

