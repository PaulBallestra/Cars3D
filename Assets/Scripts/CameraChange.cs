using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{   

    public Camera interieurVue; //On crée les objets qui vont contenir les cameras 
    public Camera exterieurVue; 

    private bool changeCam = false; //booléen pour le changement de camèra

    // Start is called before the first frame update
    void Start(){

        //Au depart, c'est la caméra intérieur qui est utilisée
        interieurVue.gameObject.SetActive(true);
        exterieurVue.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update(){

        //Si l'user appui sur la touche R alors on change de caméra
        if(Input.GetKeyDown(KeyCode.C)){

            changeCam = !changeCam; //on inverse le bool

            interieurVue.gameObject.SetActive(changeCam);
            exterieurVue.gameObject.SetActive(!changeCam);

        }
        
    }
}
