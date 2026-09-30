using UnityEngine;
using System.Collections;

public class CashierInteraction : Interactable
{
    [Header("Message")]
    public GameObject cashierMessage;

    public float displayTime = 2f;

    public override void Interact()
    {
        if (cashierMessage == null)
        {
            Debug.LogWarning("Cashier message is not assigned.");
            return;
        }

        StopAllCoroutines();
        StartCoroutine(ShowMessage());
    }

    private IEnumerator ShowMessage()
    {
        cashierMessage.SetActive(true);

        yield return new WaitForSeconds(displayTime);

        cashierMessage.SetActive(false);
    }
}