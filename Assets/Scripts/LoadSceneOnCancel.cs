using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class LoadSceneOnCancel : MonoBehaviour {

    [SerializeField]
    private string sceneName = "";

    private void Update() {
        if (Input.GetButtonDown("Cancel")) {
            SceneManager.LoadScene(sceneName);
        }
    }

}