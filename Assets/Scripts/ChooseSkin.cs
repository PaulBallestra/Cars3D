using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseSkin : MonoBehaviour
{
    Dropdown choixSkins; //Création du dropdown pour les choix de l'user

    void Start(){

        //rend = GetComponent<Renderer>();
        choixSkins = GetComponent<Dropdown>(); //on chope le composant
        choixSkins.value = PlayerPrefs.GetInt("Skin");

        //Procédure lancée a chaque fois que la valeur du dropdown a changé
        choixSkins.onValueChanged.AddListener(delegate{
            valueChanged(choixSkins); //appel de la procédure
        });

    }

    // Update is called once per frame
    void Update(){
            //rend.material.SetTexture("Skins", skins[2]); //on change la texture
    }

    //Procédure qui stocke le num du skin choisi par l'user
    void valueChanged(Dropdown change){
        PlayerPrefs.SetInt("Skin", change.value); //On enregistre sa pref
    }
}
