using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCrane : MonoBehaviour
{

    CheckpointScript chkScript;//On récupere ce script afin de jauger les animations
    public GameObject checkPoint; //go du joueur pour récuperer le num de son tour

    public float speed; //Vitesse de rotation de la grue

    // Start is called before the first frame update
    void Start(){
        
        chkScript = checkPoint.GetComponent<CheckpointScript>(); //On chope son script pour choper le num du tour auquel il est

    }

    // Update is called once per frame
    void Update(){
        
        //On fait la rotation tant que le joueur n'est pas au 3eme tour
        if(chkScript.numTour != 3){
            transform.Rotate(0, Mathf.Sin(Time.time * speed), 0, Space.Self); //rotation de la grue
        }
    }
}
