using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChanger : MonoBehaviour
{
    [SerializeField]
    private Sprite[] BGSteps = null;
    [SerializeField]
    private bool isPermanent = false;

    private bool[] triggered;

    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        triggered = new bool[BGSteps.Length];
        sr = gameObject.GetComponent<SpriteRenderer>();
        for (int i = 0; i < triggered.Length; i++)
        {
            triggered[i] = false;
        }
    }

    public void StepUp(int step)
    {
        if (isPermanent && triggered[step] == false)
        {
            sr.sprite = BGSteps[step];
            triggered[step] = true;
        }else if (isPermanent == false)
        {
            sr.sprite = BGSteps[step];

        }
    }


}
