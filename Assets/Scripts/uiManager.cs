using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiManager : MonoBehaviour
{
    public GameObject Panel_3rdScene;

    public void Continue_3rdScene()
    {
        Panel_3rdScene.SetActive(false);
    }
}
