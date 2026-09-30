using UnityEngine;

public class ScaleInteraction : Interactable
{
    public float scaleMultiplier = 1.5f;
    public float scaleSpeed = 5f;

    private Vector3 originalScale;
    private Vector3 enlargedScale;
    private bool enlarged = false;

    void Start()
    {
        originalScale = transform.localScale;

        enlargedScale =
            originalScale * scaleMultiplier;
    }

    void Update()
    {
        Vector3 targetScale =
            enlarged
                ? enlargedScale
                : originalScale;

        transform.localScale =
            Vector3.Lerp(
                transform.localScale,
                targetScale,
                scaleSpeed * Time.deltaTime
            );
    }

    public override void Interact()
    {
        enlarged = !enlarged;
    }
}