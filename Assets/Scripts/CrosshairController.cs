using UnityEngine;

public class CrosshairController : MonoBehaviour
{
    [Header("Crosshair Movement")]
    public float moveSpeed = 400f;

    [Header("Interaction")]
    public Camera mainCamera;
    public float interactionDistance = 100f;

    private RectTransform rectTransform;
    private Canvas canvas;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();

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
            CheckObject();
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

        Vector2 direction = new Vector2(horizontal, vertical);

        if (direction.magnitude > 1f)
        {
            direction.Normalize();
        }

        rectTransform.anchoredPosition +=
            direction * moveSpeed * Time.deltaTime;

        ClampToScreen();
    }

    void ClampToScreen()
    {
        RectTransform canvasRect =
            canvas.GetComponent<RectTransform>();

        Vector2 position = rectTransform.anchoredPosition;

        float halfWidth = canvasRect.rect.width / 2f;
        float halfHeight = canvasRect.rect.height / 2f;

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

    void CheckObject()
    {
        Vector2 screenPosition =
            RectTransformUtility.WorldToScreenPoint(
                null,
                rectTransform.position
            );

        Ray ray =
            mainCamera.ScreenPointToRay(screenPosition);

        RaycastHit hit;

        if (Physics.Raycast(
            ray,
            out hit,
            interactionDistance))
        {
            Debug.Log(
                "Crosshair selected: " +
                hit.collider.gameObject.name
            );
        }
        else
        {
            Debug.Log("No object selected.");
        }
    }
}