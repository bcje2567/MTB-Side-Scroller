using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Moving : MonoBehaviour
{
    public float speed = 0;
    [Range(0,100f)]
    public float rotationspeed = 0;
    public float speedlimit = 4000;
    private float rotation;
    public float b;
    private Rigidbody2D rb; 
    public WheelJoint2D frontwheel;
    public WheelJoint2D backwheel;
    private JointMotor2D frontmotor;
    private JointMotor2D backmotor;
    public GameObject finishLine;
    private bool canmove = true;
    public SpriteRenderer spriteRenderer;
    
    public void MoveLeft(){
        if (speed >= -speedlimit){
            speed -= 100;
        }
    }
    
    public void MoveRight(){
        if (speed <= speedlimit){
            speed += 100;
        }
    }
    
    public void MoveUp(){
        //rb.AddForce(new Vector3 (0,5,0), ForceMode2D.Impulse);
    }
    // this variable determines the speed of the square
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        string color = PlayerPrefs.GetString("carType");
        if (color == "Red") {
            spriteRenderer.color = Color.red;
            Debug.Log("Car Type Set");
        }

        else if (color == "White") {
            spriteRenderer.material.color = Color.red;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        frontmotor.motorSpeed = speed;
        backmotor.motorSpeed = speed;
        backmotor.maxMotorTorque = 10000;
        frontmotor.maxMotorTorque = 10000;
        frontwheel.motor = frontmotor;
        backwheel.motor = backmotor;
        if (canmove) {

            
            speed = (Input.GetAxisRaw("Vertical") * -speedlimit);
            rotation = (Input.GetAxisRaw("Horizontal")*-rotationspeed);
            rb.AddTorque(rotation, ForceMode2D.Force);
            
            /*
            if (Input.GetKeyDown(KeyCode.RightArrow)){
                rb.AddTorque(-rotationspeed, ForceMode2D.Force);
            } 

            if (Input.GetKeyDown(KeyCode.LeftArrow)){
                rb.AddTorque(rotationspeed, ForceMode2D.Force);
            }
            */
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
            if (collision.gameObject.CompareTag("Finish")) {
                finishLine.SetActive(true);
                canmove = false;

            }
    }

}