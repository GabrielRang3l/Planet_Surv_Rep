using UnityEngine;

public class TerminalAreaEffect : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Triggered by: {other.name}"); // Log what triggered the collider
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log($"Exited by: {other.name}"); // Log when an object exits
    }
}