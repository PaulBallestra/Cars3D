using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{   

    public int life = 3;

    // Start is called before the first frame update
    void Start(){
    }

    // Update is called once per frame
    void FixedUpdate(){
        
        if(Input.GetKeyDown(KeyCode.R)){
            Application.LoadLevel("Menu"); //Chargement du menu
        }

    }

    private void OnGUI(){
        GUI.Label(new Rect(10, 25, 100, 20), "Life : " + life); //texte qui affiche la vie restante
        GUI.Label(new Rect(10, 50, 100, 20), "Menu :  R"); //Texte qui affiche la touche pour retourner sur le menu
    }
}
