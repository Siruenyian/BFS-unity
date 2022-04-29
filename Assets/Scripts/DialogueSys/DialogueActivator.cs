using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Script untuk handle aktivasi dialog*/
public class DialogueActivator : MonoBehaviour, Iinteractable
{
    public NPC nPC;
    private SpriteRenderer npcSr;
    private SpriteRenderer bgSr;
    private DialogueObj dialogueObj { get; set; }

    public GameObject background;
    private void Start()
    {
        bgSr = background.GetComponent<SpriteRenderer>();
        npcSr = GetComponent<SpriteRenderer>();
        //dialogueObj = nPC.npcDialogue;
        //Debug.Log(nPC.name);
        //Debug.Log(dialogueObj);

    }
    public void UpdateDialogueObject(NPC nPC)
    {
        dialogueObj = nPC.npcDialogue;
        dialogueObj.Dialoguepic = nPC.npcDialogue.Dialoguepic;
        //sDebug.Log(dialogueObj, dialogueObj.Dialoguepic);
    }

    /*function bdy dari interface*/
    public void Interact(Player player)
    {
        //Debug.Log("Interacted"+dialogueObj);

        if (TryGetComponent(out DialogueResponseEvent responseEvent)&&responseEvent.DialogueObj==dialogueObj)
        {
            player.DialogueUI.AddResponseEvents(responseEvent.Events);
        }

        player.DialogueUI.showDialogue(dialogueObj, dialogueObj.Dialoguepic);
    }

  
}
