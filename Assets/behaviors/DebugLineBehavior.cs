using UnityEngine;
using System.Collections;

[RequireComponent(typeof(LineRenderer))]
public class DebugLineBehavior : MonoBehaviour {

    LineRenderer lineRenderer;

    void Start ()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update () {
        var worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        worldMousePos.z = -1;
        lineRenderer.SetPosition(1, worldMousePos);
    }
}
