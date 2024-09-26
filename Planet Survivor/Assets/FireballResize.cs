using UnityEngine;

public class FireballResize : MonoBehaviour
{
    public CircleCollider2D fireballCollider;  // Reference to the CircleCollider2D
    public SpriteRenderer spriteRenderer;      // Reference to the SpriteRenderer

    // Size to set the CircleCollider2D's diameter (set this in the Inspector)
    public float colliderDiameter = 1f;

    void Start()
    {
        // Set the CircleCollider2D's radius based on the colliderDiameter (diameter = 2 * radius)
        fireballCollider.radius = colliderDiameter / 2f;

        // Get the size of the fireball sprite (assuming it's a square or circular sprite)
        Vector2 spriteSize = spriteRenderer.sprite.bounds.size;

        // Calculate the scaling factor for the fireball to match the collider size
        float scaleFactor = colliderDiameter / Mathf.Max(spriteSize.x, spriteSize.y);

        // Adjust the scale of the fireball sprite to match the collider size
        transform.localScale = new Vector3(scaleFactor, scaleFactor, 1);
    }
}
