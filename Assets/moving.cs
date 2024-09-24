using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class moving : MonoBehaviour
{
    public float speed;
    public float b;
    public void Moveleft(){
        transform.position += new Vector3(-0.5f,0,0);
    }
    public void Moveright(){
        transform.position += new Vector3(0.5f,0,0);
    }
    
    // this variable determines the speed of the square
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position+=new Vector3(0,0,0.000000001f);
    }
}