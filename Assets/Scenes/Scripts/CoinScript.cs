using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{

    CoinCollection coinPlayer; //Pour récuperer le script du joueur pour augmenter ses points

    public AudioClip coinSound; //Création de la variable qui va stocker le son de la piece

    // Start is called before the first frame update
    void Start(){
    }

    void Update(){
        transform.Rotate(90 * Time.deltaTime, 0, 0); //Animation de la piece qui tourne
    }

    private void OnTriggerEnter(Collider other){
        
        GameObject g = GameObject.Find(other.name); //On récupere le go du player pour choper son script
        coinPlayer = g.GetComponent<CoinCollection>(); //On chope son script

        if(other.name == "Player"){ //Si le go qui a percuté la piece est nommé Player

            coinPlayer.coins++;//On ajoute une piece a chaque fois
            
            g.GetComponent<AudioSource>().PlayOneShot(coinSound, 1f); //On joue le son du ramassage de la piece dans l'audiosource du joueur

            Destroy(gameObject); //Desctruction de la piece
        }
    }
}
