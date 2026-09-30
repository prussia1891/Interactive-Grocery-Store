using UnityEngine;

public class ColorInteraction : Interactable
{
    public Color interactionColor = Color.yellow;

    private Renderer objectRenderer;
    private Color originalColor;
    private bool changed = false;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();

        if (objectRenderer != null)
        {
            originalColor =
                objectRenderer.material.color;
        }
    }

    public override void Interact()
    {
        if (objectRenderer == null)
        {
            return;
        }

        changed = !changed;

        objectRenderer.material.color =
            changed
                ? interactionColor
                : originalColor;
    }
}