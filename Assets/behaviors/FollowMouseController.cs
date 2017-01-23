using UnityEngine;
using System.Collections;

public class FollowMouseController : MonoBehaviour {

    void Update () {
        var worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var relPos = worldMousePos - transform.position;
        var relPos2D = new Vector2(relPos.x, relPos.y);
        if (relPos2D == Vector2.zero)
        {
            return;
        }

        SendMessage("SetDirection", relPos2D);
    }
}
