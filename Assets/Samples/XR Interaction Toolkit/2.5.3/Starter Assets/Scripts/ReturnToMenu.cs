using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMenu : MonoBehaviour
{
    // Start is called before the first frame update

    public void LoadMainScene() {
        
        SceneManager.LoadScene("Main Scene (1st)");
    
    }
}
