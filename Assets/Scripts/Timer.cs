using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour{   

    public Text txtTimer; //Text du timer qui va devoir changer 
    public Text txtDebTimer; //Text du compte a rebours

    public AudioClip compteAReboursSound; //Création du son de compte a rebours
    public AudioClip finCompteAReboursSound; //Création du son de fin du compte a rebours

    CarController carsScript; //Script de controle de la voiture

    bool isFinished = false; //Booléen qui stocke si le joueur a fini le parcours ou non
    public float temps = 120.0f; //float qui contient le temps max
    public float compteARebours = 4.0f; //int qui contient le compte a rebours

    bool played3 = false, played2 = false, played1 = false, played0 = false; //Booléen pour lancer les sons pour chaque secondes du compte a rebours

    int mins, secs; //Variables de type int qui vont contenir le timer au format minutes et secondes

    // Start is called before the first frame update
    void Start(){

        txtDebTimer.enabled = true; //Activation du compte a rebours
        txtTimer.enabled = false; //désactivation du premier timer
        txtDebTimer.text = "Depart : " + compteARebours.ToString(); //Affichage du compte a rebours

        carsScript = GetComponent<CarController>(); //on chope le script du carcontroller 
        carsScript.enabled = false; //on le désactive pour éviter que la voiture parte pendant le compte a rebours

    }

    // Update is called once per frame
    void Update(){
        
        compteARebours -= Time.deltaTime; //Diminition du compte a rebours
        txtDebTimer.text = "Depart : " + Mathf.RoundToInt(compteARebours).ToString(); //Affichage du compte a rebours (on le traduit en int pour un meilleur affichage)

        //Play du son du compte a rebours 
        switch (Mathf.RoundToInt(compteARebours)){ //en fonction de chaque nombre on joue un son
            case 3: 
                if(played3 == false){
                    GetComponent<AudioSource>().PlayOneShot(compteAReboursSound, 0.5f); //on lance le son
                    played3 = true; //on met son booléen a true pour éviter de le jouer plusieurs fois
                }
                break;
            case 2:
                if(played2 == false){
                    GetComponent<AudioSource>().PlayOneShot(compteAReboursSound, 0.5f);
                    played2 = true;
                }
                break;
            case 1:
                if(played1 == false){
                    GetComponent<AudioSource>().PlayOneShot(compteAReboursSound, 0.5f);
                    played1 = true;
                }
                break;
        }

        if(compteARebours <= 1){ //si le compte a rebour atteint 0 on lance la course

            //On réactive le script du controle de la voiture
            carsScript.enabled = true;

            //On désactive le compte a rebours et on active le timer
            txtDebTimer.enabled = false;
            txtTimer.enabled = true;

            temps -= Time.deltaTime; //on diminue le timer a chaque seconde

            mins = Mathf.RoundToInt(temps)/60; //calcul des minutes restantes
            secs = Mathf.RoundToInt(temps) - mins*60; //calcul des secondes restantes
            
            //juste pour etre vraiment maniaque sur l'affichage du timer
            if(mins < 10 && secs < 10){
                txtTimer.text = "0" + mins + " : " + "0" + secs; //On met a jour le texte qui affiche le timer
            }else if(mins < 10 && secs >= 10){
                txtTimer.text = "0" + mins + " : " + secs; //On met a jour le texte qui affiche le timer
            }else{
                txtTimer.text = mins + " : " + secs; //On met a jour le texte qui affiche le timer
            }

            //Si on commence la course alors on lance le son correspondant
            if(played0 == false){
                GetComponent<AudioSource>().PlayOneShot(finCompteAReboursSound, 0.5f); //Changement de son pour indiquer le début de la course
                played0 = true; //on met son booléen a true pour éviter de le jouer plusieurs fois
            }

            if(temps <= 0.0f){ //Si le timer atteint 0
                finDePartie(false);//Appel de la méthode qui finira la partie
            }
        }
    }

    //Procédure qui affiche si le joueur a gagné ou non
    void finDePartie(bool win){

        if(win){ //Si le joueur a gagné
            txtTimer.text = "Gagné !";
        }else{
            txtTimer.text = "Perdu !";
        }

    }
}
