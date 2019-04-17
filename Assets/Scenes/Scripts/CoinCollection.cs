using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollection : MonoBehaviour
{   

    public int coins = 0; //Nombre de points de base du joueur lorsqu'il commence la partie 

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }

    private void OnGUI(){
        GUI.Label(new Rect(10,10,100, 20), "Coins : " + coins); //texte en haut a gauche de l'écran pour afficher le nombre de piece du joueur
    }
}
