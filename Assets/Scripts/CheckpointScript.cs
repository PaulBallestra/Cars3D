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
    Animation animCrane; //Création de l'animation de la grue
    Animation animTanker;

    //Gameobjects
    public GameObject arbreFall1; //GO de la branche qui va tomber
    public GameObject truckDumper; //Go du truck
    public GameObject brancheCamion; //branche
    public GameObject crane; //Grue
    public GameObject tanker;
    public GameObject truckBleu;

    Transform transDumper;

    public int numTour = 1; //création de la variable qui va contenir le numéro du tour actuel

    // Start is called before the first frame update
    void Start(){
        
        animBrancheT2 = arbreFall1.GetComponent<Animation>(); //On récupère son anim
        animTruckT2 = truckDumper.GetComponent<Animation>(); //on récupère le go du truck
        animCrane = crane.GetComponent<Animation>(); //on récupère son anim
        animTanker = tanker.GetComponent<Animation>();

        transDumper = truckDumper.GetComponent<Transform>();

    }

    //Méthode qui va faire qqchose lorsque le joueur passe le checkpoint
    private void OnTriggerEnter(Collider other){

        if(this.name == "EndCheckpoint"){
            GameObject g = GameObject.Find(other.name); //On chope le go du other

            if(other.name == "Player"){ //Si c'est le Player qui triggerEnter

                if(numTour == 1){ //Si on commence le tour 2 (==1 car la méthode est lancée plusieurs fois)
                    animBrancheT2.Play("FallTree"); //Lancement de l'animation de la branche
                    animTruckT2.Play("TruckAnim"); //lancement de l'animation du truck
                }

                if(numTour == 2){ //Si on commence le tour 3
                    
                    //ON place bien le camion qui va prendre le bout de bois
                    brancheCamion.transform.localPosition = new Vector3(-328, 8,278); //on met la branche dans le camion
                    brancheCamion.transform.localRotation = Quaternion.Euler(-178,-90,-197); //Rotation de la branche
                    brancheCamion.transform.SetParent(transDumper); //On le met en child du truckDumper

                    //On deplace le camion avec la branche dedans
                    truckDumper.transform.localPosition = new Vector3(-56, 4, 265);
                    truckDumper.transform.localRotation = Quaternion.Euler(0,64,0);


                    Debug.Log("Tour 3");
                }

                if(numTour == 3){ //Si il fini la course
                    
                }

                numTour++; //on incrémente le numTour
            }
        }else if(this.name == "T3Checkpoint"){ //Pour le 2eme checkpoint du t3
            
            //Lancement de l'anim
            animCrane.Play("craneAnim");
            animTanker.Play("tankerAnim");

            truckBleu.transform.localPosition = new Vector3(148,5,403);
            truckBleu.transform.localRotation = Quaternion.Euler(0, 128, 0);

        }
    }

    void OnGUI(){
        GUI.Label(new Rect(10, 75, 100, 20), "Tours : " + numTour + "/3"); //Texte qui affiche la touche pour retourner sur le menu
    }
}
