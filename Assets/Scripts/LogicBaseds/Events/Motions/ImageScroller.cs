using UnityEngine;

class ImageScroller : Motion
{
    Material material;

    public override void Invoke()
    {
        material.mainTextureOffset += (Vector2)Velocity * Time.smoothDeltaTime;
    }
    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }
}