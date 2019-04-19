using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube : MonoBehaviour
{

    private Vector3 pos;
    public float speed;
    public float distance ;
    // Start is called before the first frame update
    void Start(){
        
        //pos = transform.position;

    }

    // Update is called once per frame
    void Update(){
       
        //pos.x += hFMathf.Sin(Time.time * speed) *  distance;
        //transform.position = pos;

        transform.Translate(Vector3.forward * Time.deltaTime * );
        transform.Rotate(0, Input.GetAxis("Horizontal"), 0, Space.Self);

    }
}
