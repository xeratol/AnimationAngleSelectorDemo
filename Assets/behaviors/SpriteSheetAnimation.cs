using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteSheetAnimation : MonoBehaviour {

    public Sprite[] sprites;
    public float fps = 30;
    private float frameDuration;
    private float timeSinceLastChange;
    private SpriteRenderer spriteRenderer;
    private int currentIndex = 0;

    public bool loop = true;

    void Start () {
        Debug.Assert(sprites.Length > 1, "sprites not set", this);
        frameDuration = 1.0f / fps;
        timeSinceLastChange = Time.time;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[currentIndex];
    }
    
    void Update () {
        if (Time.time > timeSinceLastChange + frameDuration)
        {
            IncrementIndex();
            UpdateVisual();
            timeSinceLastChange = Time.time;
        }
    }

    void IncrementIndex()
    {
        ++currentIndex;
        if (currentIndex >= sprites.Length)
        {
            if (loop)
            {
                currentIndex = 0;
            }
            else
            {
                enabled = false;
            }
        }
    }

    void UpdateVisual()
    {
        if (currentIndex < sprites.Length)
        {
            spriteRenderer.sprite = sprites[currentIndex];
        }
    }
}
