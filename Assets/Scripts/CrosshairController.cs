using UnityEngine;

public class CrosshairController : MonoBehaviour
{
    [Header("Crosshair Movement")]
    public float moveSpeed = 400f;

    [Header("Interaction")]
    public Camera mainCamera;
    public float interactionDistance = 100f;

    private RectTransform rectTransform;
    private RectTransform canvasRect;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        Canvas canvas = GetComponentInParent<Canvas>();

        if (canvas != null)
        {
            canvasRect = canvas.GetComponent<RectTransform>();
        }

        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    void Update()
    {
        MoveCrosshair();

        if (Input.GetKeyDown(KeyCode.E))
        {
            TryInteract();
        }
    }

    void MoveCrosshair()
    {
        float horizontal = 0f;
        float vertical = 0f;

        if (Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.LeftArrow))
        {
            horizontal -= 1f;
        }

        if (Input.GetKey(KeyCode.D) ||
            Input.GetKey(KeyCode.RightArrow))
        {
            horizontal += 1f;
        }

        if (Input.GetKey(KeyCode.W) ||
            Input.GetKey(KeyCode.UpArrow))
        {
            vertical += 1f;
        }

        if (Input.GetKey(KeyCode.S) ||
            Input.GetKey(KeyCode.DownArrow))
        {
            vertical -= 1f;
        }

        Vector2 direction =
            new Vector2(horizontal, vertical);

        if (direction.magnitude > 1f)
        {
            direction.Normalize();
        }

        rectTransform.anchoredPosition +=
            direction * moveSpeed * Time.deltaTime;

        ClampToCanvas();
    }

    void ClampToCanvas()
    {
        if (canvasRect == null)
        {
            return;
        }

        Vector2 position =
            rectTransform.anchoredPosition;

        float halfWidth =
            canvasRect.rect.width / 2f;

        float halfHeight =
            canvasRect.rect.height / 2f;

        position.x = Mathf.Clamp(
            position.x,
            -halfWidth,
            halfWidth
        );

        position.y = Mathf.Clamp(
            position.y,
            -halfHeight,
            halfHeight
        );

        rectTransform.anchoredPosition = position;
    }

    void TryInteract()
    {
        if (mainCamera == null)
        {
            return;
        }

        Vector2 screenPosition =
            RectTransformUtility.WorldToScreenPoint(
                null,
                rectTransform.position
            );

        Ray ray =
            mainCamera.ScreenPointToRay(screenPosition);

        if (Physics.Raycast(
            ray,
            out RaycastHit hit,
            interactionDistance))
        {
            Debug.Log(
                "Selected: " +
                hit.collider.gameObject.name
            );

            Interactable interactable =
                hit.collider.GetComponentInParent<Interactable>();

            if (interactable != null)
            {
                interactable.Interact();
            }
        }
    }
}