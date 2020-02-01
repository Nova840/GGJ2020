using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGChanger : MonoBehaviour
{
    [SerializeField]
    private Sprite[] BGSteps;

    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>(); 
    }

    public void StepUp(int step)
    {
        sr.sprite = BGSteps[step];
    }

    
}
