using UnityEngine;
using TMPro;

public class WellInteraction : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private GameObject interactionMessage;
    [SerializeField] private GameObject completeMessage;

    private bool playerInRange = false;
    private bool levelCompleted = false;

    private void Start()
    {
        interactionMessage.SetActive(false);
        completeMessage.SetActive(false);
    }

    private void Update()
    {
        //Validate requirements and run interaction
        if (playerInRange && !levelCompleted &&
            Input.GetKeyDown(KeyCode.E))
        {
            levelCompleted = true;

            interactionMessage.SetActive(false);
            completeMessage.SetActive(true);

            Debug.Log("Level Complete!");
        }
        //Validate requirements and run Escape
        if (levelCompleted && Input.GetKeyDown(KeyCode.Escape))
        {
            levelCompleted = false;

            if (playerInRange)
            {
                interactionMessage.SetActive(true);
            }

            completeMessage.SetActive(false);

            Debug.Log("Interaction Reset.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !levelCompleted)
        {
            playerInRange = true;
            interactionMessage.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            interactionMessage.SetActive(false);
        }
    }
}