using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSkin : MonoBehaviour
{

    public GameObject corpsVoiture; //GO qui va contenir le corps de la caisse
    Renderer rend; //Création du renderer pour changer la texture

    public Texture[] skins; //Création d'un array pour stocker tous les différents skins

    void Awake(){
        
        rend = corpsVoiture.GetComponent<Renderer>(); //On chope le composant Renderer de l'objet sur lequel est posé le script
        int numSkin = PlayerPrefs.GetInt("Skin"); //création d'une variable nommée numSkin qui va contenir le num du skin choisi par le joueur

        rend.material.mainTexture = skins[numSkin]; //on change la texture

    }

    // Update is called once per frame
    void Update(){
    }
}