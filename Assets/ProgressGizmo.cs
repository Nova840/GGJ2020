using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressGizmo : MonoBehaviour
{

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(transform.position, transform.localScale);
    }
}
