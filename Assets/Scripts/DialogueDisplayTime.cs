using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueDisplayTime : MonoBehaviour
{
    public GameObject talkBtn;
    float startTime;
    void OnEnable()
    {
        Invoke("HideDialogueBox", 10f);
    }

    private void HideDialogueBox()
    {
        gameObject.SetActive(false);
        talkBtn.SetActive(true);
    }
}
