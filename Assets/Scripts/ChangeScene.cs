using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    
    public void onClick_Levels(){
        SceneManager.LoadScene("Road1", LoadSceneMode.Single);
    }

    public void onClick_Skins(){
        SceneManager.LoadScene("Options", LoadSceneMode.Single);
    }

    public void onClick_Retour(){
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

}
