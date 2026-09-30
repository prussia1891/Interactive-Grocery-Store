using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DropInteraction : Interactable
{
    private Rigidbody rb;
    private bool dropped = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.useGravity = false;
        rb.isKinematic = true;
    }

    public override void Interact()
    {
        if (dropped)
        {
            return;
        }

        dropped = true;

        rb.isKinematic = false;
        rb.useGravity = true;
    }
}