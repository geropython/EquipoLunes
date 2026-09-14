using UnityEngine.InputSystem;
using UnityEngine;

public class DialoguePlayer : MonoBehaviour
{
    public DialogueLine[] dialogueLines;
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
    private void Start()
    {
        DialogueManager.instance.StartDialogue(dialogueLines);
        dialogueStarted = true;
    }

    private void Update()
    {
        if (dialogueStarted && DialogueManager.instance.dialogueFinished) dialogueStarted = false;
    }
}
