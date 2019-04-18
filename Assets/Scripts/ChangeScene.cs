using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    
    public void onClick_Levels(){
        Application.LoadLevel("Road1");
    }

    public void onClick_Skins(){
        Application.LoadLevel("Options");
    }

    public void onClick_Retour(){
        Application.LoadLevel("Menu");
    }

}
