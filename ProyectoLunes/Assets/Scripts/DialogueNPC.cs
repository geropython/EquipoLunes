using UnityEngine.InputSystem;
using UnityEngine;

public class DialogueNPC : MonoBehaviour
{
    public DialogueLine[] dialogueLines;
    private bool playerInRange = false;
    public bool dialogueStarted = false;
    [Header("Input")]
    public InputActionReference interactAction;

    private void OnEnable()
    {
        if (interactAction != null) interactAction.action.Enable();
    }

    private void OnDisable()
    {
        if (interactAction != null) interactAction.action.Disable();
    }
    // Update is called once per frame
    private void Update()
    {
        if (playerInRange && !dialogueStarted && interactAction != null && interactAction.action.WasPressedThisFrame())
        {
            DialogueManager.instance.StartDialogue(dialogueLines);
            dialogueStarted = true;
        }
        if (dialogueStarted && DialogueManager.instance.dialogueFinished) dialogueStarted = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) playerInRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) playerInRange = false;
    }
}
