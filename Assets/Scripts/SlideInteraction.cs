using UnityEngine;

public class SlideInteraction : Interactable
{
    public Vector3 slideOffset =
        new Vector3(0f, 0f, 0.5f);

    public float moveSpeed = 2f;

    private Vector3 closedPosition;
    private Vector3 openPosition;
    private bool isOpen = false;

    void Start()
    {
        closedPosition = transform.localPosition;
        openPosition = closedPosition + slideOffset;
    }

    void Update()
    {
        Vector3 targetPosition =
            isOpen ? openPosition : closedPosition;

        transform.localPosition =
            Vector3.Lerp(
                transform.localPosition,
                targetPosition,
                moveSpeed * Time.deltaTime
            );
    }

    public override void Interact()
    {
        isOpen = !isOpen;
    }
}