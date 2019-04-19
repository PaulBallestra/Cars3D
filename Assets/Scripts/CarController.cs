using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarController : MonoBehaviour
{

    public GameObject corpsVoiture;
    Renderer rend;

    public Texture[] skins;

    public GameObject roueAG; //On stocke les go des roues avants 
    public GameObject roueAD;

    public Rigidbody rb; //le rb de la voiture pour la faire avancer

    public float speed; //Vitesse de la voiture
    public float reculspeed; //Vitesse de la voiture au recul
    public float turnspeed; //Vitesse de tournage quand la voiture tourne

    Quaternion defaultRotation; //Variable qui stocke la position de base des roues

    private float rotationRoue = 0.0f; //Flotant pour continuer de faire tourner les roues lorsque la voiture tourne
    private float rotationRoueRecul = 0.0f; //Flotant pour continuer de faire tourner les roues lorsque la voiture tourne (au recul cette fois)

    void Start(){
        defaultRotation = roueAD.transform.localRotation; //On stocke la rotation de base des roues

        rend = corpsVoiture.GetComponent<Renderer>();
        int nbSkin = PlayerPrefs.GetInt("Skin");

        rend.material.SetTexture("Skins", skins[nbSkin]); //on change la texture

    }

    void Update(){
        
        if(Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene("Menu", LoadSceneMode.Single); //Chargement du menu
        }

        rotationRoue += Time.deltaTime * speed;
        rotationRoueRecul += Time.deltaTime * reculspeed * -0.5f;

        Mouvement();
    }

    void Mouvement(){

        if(Input.GetAxis("Vertical") > 0){ //Si on avance

            rb.AddForce(transform.forward * speed * 2f); //On fait avancer la voiture

            roueAD.transform.Rotate(rotationRoue,0,0, Space.Self); //Tournage des roues lorsque la voiture avance
            roueAG.transform.Rotate(rotationRoue,0,0, Space.Self); 

            if(Input.GetAxis("Horizontal") < 0){ //Si on va vers la gauche

                rb.transform.Rotate(new Vector3(0f, -turnspeed, 0f)); //Rotation de la voiture a gauche

                roueAD.transform.localRotation = Quaternion.Euler(rotationRoue, turnspeed + Input.GetAxis("Horizontal") * 15, 0); //Steer des roues vers gauche
                roueAG.transform.localRotation = Quaternion.Euler(rotationRoue, turnspeed + Input.GetAxis("Horizontal") * 15, 0);

            }

            if(Input.GetAxis("Horizontal") > 0){ //Si on va vers la droite

                rb.transform.Rotate(new Vector3(0f, turnspeed, 0f)); //Rotation de la voiture a droite

                roueAD.transform.localRotation = Quaternion.Euler(rotationRoue, turnspeed + Input.GetAxis("Horizontal") * 15, 0); //Steer des roues vers droite
                roueAG.transform.localRotation = Quaternion.Euler(rotationRoue, turnspeed + Input.GetAxis("Horizontal") * 15, 0);

            }

        }else if(Input.GetAxis("Vertical") < 0){ //Si on recule

            rb.AddForce(transform.forward * reculspeed * -1); //On fait reculer la voiture

            roueAD.transform.Rotate(rotationRoueRecul, 0, 0, Space.Self); //Tournage des roues lorsque la voiture recule
            roueAG.transform.Rotate(rotationRoueRecul, 0, 0, Space.Self);

            if(Input.GetAxis("Horizontal") < 0){ //Si on va vers la gauche en reculant, le steer des roues est inversé

                rb.transform.Rotate(new Vector3(0f, turnspeed, 0f)); //Rotation de la voiture a gauche

                roueAD.transform.localRotation = Quaternion.Euler(rotationRoueRecul, -turnspeed + Input.GetAxis("Horizontal") * 15, 0); //Steer des roues vers gauche
                roueAG.transform.localRotation = Quaternion.Euler(rotationRoueRecul, -turnspeed + Input.GetAxis("Horizontal") * 15, 0);

            }

            if(Input.GetAxis("Horizontal") > 0){ //Si on va vers la droite en reculant, le steer des roues est inversé aussi

                rb.transform.Rotate(new Vector3(0f, -turnspeed, 0f)); //Rotation de la voiture a gauche

                roueAD.transform.localRotation = Quaternion.Euler(rotationRoueRecul, turnspeed + Input.GetAxis("Horizontal") * 15, 0); //Steer des roues vers gauche
                roueAG.transform.localRotation = Quaternion.Euler(rotationRoueRecul, turnspeed + Input.GetAxis("Horizontal") * 15, 0);

            }

        }else{ //Si on ne fait rien la position des roues est normale

            roueAD.transform.localRotation = defaultRotation;
            roueAG.transform.localRotation = defaultRotation;   
            
        }

    }
}