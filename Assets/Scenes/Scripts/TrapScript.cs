using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapScript : MonoBehaviour
{   

    HealthScript lifePlayer; //Pour récuperer le script qui gère les points du joueur

    public AudioClip trapSound; //Son du piege qui va faire perdre des points au joueur
    public AudioClip deathSound; //Son de mort du joueur (fin de partie)
    
    // Start is called before the first frame update
    void Start(){   
    }

    void Update(){
    }

    private void OnTriggerEnter(Collider other){

        GameObject g = GameObject.Find(other.name); //On récupère le go du joueur
        lifePlayer = g.GetComponent<HealthScript>(); //On chope le script des vies du joueur

        if(other.name == "Player"){
            
            lifePlayer.life--; //On retire une vie a chaque fois qu'il se prend un piege

            g.GetComponent<AudioSource>().PlayOneShot(trapSound, 1f); //On joue le son du trap

            if(lifePlayer.life == 0){
                g.GetComponent<AudioSource>().PlayOneShot(deathSound, 1f); //On joue le son de mort du joueur
            }

        }

    }
}

