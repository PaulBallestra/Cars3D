using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckpointScript : MonoBehaviour
{

    //Collider pour le checkpoint
    Collider chkPtCollider; //Création du collider du checkpoint pour faire les changements pour les prochains tours
    
    //Animations
    Animation animBrancheT2; //Création de l'anim de la branche pour le tour 2
    Animation animTruckT2; //Création de l'anim du truck pour le tour 2

    //Gameobjects
    public GameObject arbreFall1; //GO de la branche qui va tomber
    public GameObject truck1; //Go du truck

    public int numTour = 1; //création de la variable qui va contenir le numéro du tour actuel

    // Start is called before the first frame update
    void Start(){
        
        animBrancheT2 = arbreFall1.GetComponent<Animation>(); //On récupère son anim
        animTruckT2 = truck1.GetComponent<Animation>(); //on récupère le go du truck
    }

    // Update is called once per frame
    void Update(){

    }

    //Méthode qui va faire qqchose lorsque le joueur passe le checkpoint
    private void OnTriggerEnter(Collider other){

        GameObject g = GameObject.Find(other.name); //On chope le go du other

        if(other.name == "Player"){ //Si c'est le Player qui triggerEnter

            if(numTour == 1){ //Si on commence le tour 2 (==1 car la méthode est lancée plusieurs fois)
                animBrancheT2.Play("FallTree"); //Lancement de l'animation de la branche
                animTruckT2.Play("TruckAnim"); //lancement de l'animation du truck
            }

            if(numTour == 2){ //Si on commence le tour 3
                Debug.Log("Tour 3");
            }

            if(numTour == 3){ //Si il fini la course
                Debug.Log("Gagné ! ");
            }

            numTour++; //on incrémente le numTour
        }
    }

    void OnGUI(){
        GUI.Label(new Rect(10, 75, 100, 20), "Tours : " + numTour + "/3"); //Texte qui affiche la touche pour retourner sur le menu
    }
}
