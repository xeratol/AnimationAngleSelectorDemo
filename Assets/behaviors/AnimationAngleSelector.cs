using UnityEngine;
using System.Collections;

public class AnimationAngleSelector : MonoBehaviour {

    public GameObject up;
    public GameObject upRight;
    public GameObject right;
    public GameObject downRight;
    public GameObject down;
    public GameObject downLeft;
    public GameObject left;
    public GameObject upLeft;
    private GameObject lastActive = null;

    private Vector2 dir = Vector2.up;

    public void SetDirection(Vector2 direction)
    {
        dir = direction.normalized;
        UpdateVisual();
    }

    public void DisableAll ()
    {
        DisableGameObject(up);
        DisableGameObject(upRight);
        DisableGameObject(right);
        DisableGameObject(downRight);
        DisableGameObject(down);
        DisableGameObject(downLeft);
        DisableGameObject(left);
        DisableGameObject(upLeft);
    }

    void UpdateVisual () {
        var toBeActive = lastActive;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg / 45.0f;
        switch (Mathf.RoundToInt(angle) % 8)
        {
            case 0:
                toBeActive = right;
                break;
            case 1:
            case -7:
                toBeActive = upRight;
                break;
            case 2:
            case -6:
                toBeActive = up;
                break;
            case 3:
            case -5:
                toBeActive = upLeft;
                break;
            case 4:
            case -4:
                toBeActive = left;
                break;
            case 5:
            case -3:
                toBeActive = downLeft;
                break;
            case 6:
            case -2:
                toBeActive = down;
                break;
            case 7:
            case -1:
                toBeActive = downRight;
                break;
            default:
                var val = Mathf.RoundToInt(angle) % 8;
                Debug.Assert(false, "should never reach this (" + val + ")", this);
                break;
        }

        if (toBeActive != null && lastActive != toBeActive)
        {
            DisableAll();
            toBeActive.SetActive(true);
            lastActive = toBeActive;
        }
    }

    void DisableGameObject(GameObject o)
    {
        if (o) o.SetActive(false);
    }
}
