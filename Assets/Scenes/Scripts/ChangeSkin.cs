using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSkin : MonoBehaviour
{

    Renderer rend;

    public Texture[] skins;

    void Start(){

        rend = GetComponent<Renderer>();
        int nbSkin = PlayerPrefs.GetInt("Skin");

        rend.material.SetTexture("Skins", skins[1]); //on change la texture

    }

    // Update is called once per frame
    void Update(){
    }
}
