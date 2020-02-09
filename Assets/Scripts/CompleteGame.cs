using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteGame : MonoBehaviour {

    [SerializeField]
    private GameObject winCanvas = null;

    [SerializeField]
    private GameObject fireworkPrefab;
    [SerializeField]
    private int minFireworks = 5, maxFireworks=15;
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

            print(fireworkPrefab);
            if (fireworkPrefab != null)
            {
                StartCoroutine(PlayFireworks(transform.parent, collision.collider.transform.parent));
            }
            StartCoroutine(ReturnToStart());
        }
    }

    private IEnumerator ReturnToStart() {

        yield return new WaitForSeconds(returnDelay);
        SceneManager.LoadScene("Start");
    }

    private IEnumerator PlayFireworks(Transform One, Transform Two)
    {
        Transform active;
        int fireWorksCount = Random.Range(minFireworks, maxFireworks);
        int PlayerOrigin = Random.Range(1, 2);
        for (int i = 0; i < fireWorksCount; i++)
        {
            float x, y,r, g, b;

            x = Random.Range(-2f, 2f);
            y = Random.Range(-2f, 2f);
            if (PlayerOrigin %2 == 1)
            {
                active = One;
            }
            else
            {
                active = Two;
            }
            GameObject fw = Instantiate(fireworkPrefab, new Vector3(active.position.x + x, active.position.y + y, active.position.z), Quaternion.identity, active);

            r = Random.Range(100/255, 1f);
            g = Random.Range(100/255, 1f);
            b = Random.Range(100/255, 1f);
            fw.GetComponentInChildren<SpriteRenderer>().color = new Color(r, g, b);

            PlayerOrigin++;
            yield return new WaitForSeconds(returnDelay / fireWorksCount);
        }

    }
        private void OnDestroy() {
        AlreadyCompleted = false;
    }

}