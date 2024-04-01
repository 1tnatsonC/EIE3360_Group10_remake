using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuManager : MonoBehaviour
{
    public Transform head;
    public Transform origin;
    public Transform pos1;
    public Transform pos2;
    public Transform pos3;
    public void SelectBtn1()
    {
        Vector3 offset = head.position - origin.position;
        origin.position = pos2.position - offset;
        head.rotation = pos2.rotation;
        origin.rotation = pos2.rotation;
    }
    public void SelectBtn2()
    {
        Vector3 offset = head.position - origin.position;
        origin.position = pos3.position - offset;
        head.rotation = pos3.rotation;
        origin.rotation = pos3.rotation;
    }
    public void BackBtn()
    {
        Vector3 offset = head.position - origin.position;
        origin.position = pos1.position - offset;
        head.rotation = pos1.rotation;
        origin.rotation = pos1.rotation;
    }
    public void StartBtn1()
    {
        SceneManager.LoadScene("2nd Scene");
    }
    public void StartBtn2()
    {
        SceneManager.LoadScene("3rd Scene(Shooting)");
    }
}
