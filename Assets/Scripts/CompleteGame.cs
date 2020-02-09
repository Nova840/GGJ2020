using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteGame : MonoBehaviour {

    [SerializeField]
    private GameObject winCanvas = null;

    [SerializeField]
    private float returnDelay = 5;

    public static bool AlreadyCompleted { get; private set; } = false;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (!AlreadyCompleted && collision.gameObject.layer == LayerMask.NameToLayer("Player")) {
            AlreadyCompleted = true;
            winCanvas.SetActive(true);
            transform.parent.GetComponent<Animator>().SetInteger("Player", transform.parent.GetComponent<PlayerController>().PlayerNum);
            transform.parent.GetComponent<Animator>().SetBool("Won", true);
            collision.collider.transform.parent.GetComponent<Animator>().SetInteger("Player", collision.collider.transform.parent.GetComponent<PlayerController>().PlayerNum);
            collision.collider.transform.parent.GetComponent<Animator>().SetBool("Won", true);

            StartCoroutine(ReturnToStart());
        }
    }

    private IEnumerator ReturnToStart() {
        yield return new WaitForSeconds(returnDelay);
        SceneManager.LoadScene("Start");
    }

    private void OnDestroy() {
        AlreadyCompleted = false;
    }

}