using UnityEngine;

public class TerminalAreaEffect2D : MonoBehaviour
{
    // Public variables to allow customization from the Unity Inspector
    public float radius = 5f; // Radius of the area effect (size of the circle)
    public int segments = 30; // Number of segments used to create the circle (more segments = smoother circle)
    public Color circleColor = Color.yellow; // Color of the circle
    public string sortingLayerName = "Default"; // Sorting layer for the LineRenderer to control what appears in front
    public int orderInLayer = 0; // Order within the sorting layer (higher values appear on top)

    private LineRenderer lineRenderer; // Component to visually draw the circle
    private CircleCollider2D circleCollider; // Reference to the CircleCollider2D component

    private void Start()
    {
        // Adding a LineRenderer component dynamically to this GameObject to draw the circle
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.positionCount = segments + 1; // +1 ensures the circle closes (first and last point are the same)
        lineRenderer.startWidth = 0.1f; // Thickness of the circle's start
        lineRenderer.endWidth = 0.1f;   // Thickness of the circle's end

        // The LineRenderer requires a material. We use a basic 2D shader to ensure the color is rendered correctly.
        lineRenderer.material = new Material(Shader.Find("Sprites/Default")); // Default shader for 2D objects
        lineRenderer.startColor = circleColor; // Set the start color of the circle
        lineRenderer.endColor = circleColor;   // Set the end color of the circle (same as start for solid color)

        lineRenderer.loop = true; // Makes the line loop to form a closed circle
        lineRenderer.useWorldSpace = false; // Uses local space so the circle moves with the object

        // Set the sorting layer and order for the LineRenderer so it renders in the correct layer
        lineRenderer.sortingLayerName = sortingLayerName; // Assigns the sorting layer (determines where it appears)
        lineRenderer.sortingOrder = orderInLayer; // Order within the layer (higher values appear in front of lower ones)

        lineRenderer.enabled = false; // Hide the circle initially until we trigger it (player enters terminal area)

        // Call method to calculate and draw the circle points based on the radius and segment count
        DrawCircle();

        // Retrieve the CircleCollider2D component attached to the GameObject (if it exists)
        circleCollider = GetComponent<CircleCollider2D>();
        if (circleCollider == null)
        {
            // Log an error if no CircleCollider2D is found, as the script depends on it
            Debug.LogError("No CircleCollider2D found on the terminal object!");
        }
    }

    // Called whenever variables in the Unity Inspector are changed (for real-time updating in the editor)
    private void OnValidate()
    {
        if (lineRenderer != null)
        {
            // Update the circle parameters when the values change in the Inspector
            lineRenderer.positionCount = segments + 1;
            lineRenderer.startColor = circleColor;
            lineRenderer.endColor = circleColor;
            DrawCircle(); // Redraw the circle with updated values
        }
    }

    private void Update()
    {
        // Optional: Toggle the visibility of the circle when the "E" key is pressed
        if (Input.GetKeyDown(KeyCode.E))
        {
            ToggleCircle();
        }
    }

    // Toggles the circle's visibility by enabling/disabling the LineRenderer
    private void ToggleCircle()
    {
        lineRenderer.enabled = !lineRenderer.enabled; // Switches between showing and hiding the circle
    }

    // This method generates the points that form the circle based on the radius and segments
    private void DrawCircle()
    {
        float angle = 0f; // Initial angle for the first point
        float angleStep = 360f / segments; // The angle between each point on the circle

        // Loop through all segments to calculate and place the points
        for (int i = 0; i <= segments; i++)
        {
            float x = Mathf.Cos(angle * Mathf.Deg2Rad) * radius; // Calculate the x-coordinate of the point
            float y = Mathf.Sin(angle * Mathf.Deg2Rad) * radius; // Calculate the y-coordinate of the point
            lineRenderer.SetPosition(i, new Vector3(x, y, 0));   // Set the position of the point on the circle

            angle += angleStep; // Move to the next point in the circle by increasing the angle
        }
    }

    // Called when a 2D collider (such as the player) enters the trigger zone
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"Triggered by: {other.name}"); // Log the name of the object that triggered the event

        // If the object that entered has the "Player" tag, we toggle the circle visibility and adjust the collider size
        if (other.CompareTag("Player"))
        {
            ToggleCircle();     // Show the circle around the terminal
            AdjustColliderRadius(); // Adjust the CircleCollider2D to match the visual circle's radius
        }
    }

    // Called when a 2D collider (such as the player) exits the trigger zone
    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log($"Exited by: {other.name}"); // Log the name of the object that exited the trigger zone

        // If the object leaving has the "Player" tag, we hide the circle and (optionally) reset the collider size
        if (other.CompareTag("Player"))
        {
            ToggleCircle();      // Hide the circle around the terminal
            ResetColliderRadius(); // Optional: Reset the collider to a default size after the player exits
        }
    }

    // Adjust the radius of the CircleCollider2D to match the visual effect's radius
    private void AdjustColliderRadius()
    {
        if (circleCollider != null)
        {
            // Set the CircleCollider2D's radius to match the visual effect radius
            circleCollider.radius = radius + 1f;
            Debug.Log($"Collider radius adjusted to: {radius}");
        }
    }

    // Optionally reset the collider radius after the player exits the trigger area
    private void ResetColliderRadius()
    {
        if (circleCollider != null)
        {
            // Reset the collider's radius to a default value (e.g., 1f)
            circleCollider.radius = 2f;
            Debug.Log("Collider radius reset.");
        }
    }
}
