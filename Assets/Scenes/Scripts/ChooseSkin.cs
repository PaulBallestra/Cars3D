using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseSkin : MonoBehaviour
{
    Dropdown choixSkins;

    void Start(){

        //rend = GetComponent<Renderer>();
        choixSkins = GetComponent<Dropdown>();

        choixSkins.onValueChanged.AddListener(delegate{
            valueChanged(choixSkins);
        });

    }

    // Update is called once per frame
    void Update(){
            //rend.material.SetTexture("Skins", skins[2]); //on change la texture
    }

    void valueChanged(Dropdown change){
        PlayerPrefs.SetInt("Skin", change.value); //On enregistre sa pref
    }
}
