using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteGame : MonoBehaviour {

    [SerializeField]
    private GameObject winCanvas = null;

    [SerializeField]
    private float returnDelay = 5;

    private static bool alreadyCompleted = false;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (!alreadyCompleted && collision.gameObject.layer == LayerMask.NameToLayer("Player")) {
            alreadyCompleted = true;
            winCanvas.SetActive(true);
            StartCoroutine(ReturnToStart());
        }
    }

    private IEnumerator ReturnToStart() {
        yield return new WaitForSeconds(returnDelay);
        SceneManager.LoadScene("Start");
    }

    private void OnDestroy() {
        alreadyCompleted = false;
    }

}