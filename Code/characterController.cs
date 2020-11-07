using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class characterController : MonoBehaviour
{
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    public float posX = 5.8f;
    public float posY=3f;
    public float posZ =0.4f;

    public Text countPoints;
    public Text lifeText;
    public Text life;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    private int points=50;
    private int points1 = 50;
    private int lifes;

    private int Destroyclicks=0;
    private int Buildclicks = 0;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        
        gameObject.transform.position = new Vector3(posX, posY, posZ);
        points = 50;
        lifes = 3;
        countPoints.text = "Points: " + points.ToString();
        //lifeText.text = "";
        life.text = "";
        SetCountText();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            gameObject.transform.position = new Vector3(20 / 2, 0.8f, 20 / 2);

        }
        if (controller.isGrounded)
        {
            

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection = moveDirection * speed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        if (controller.transform.position.y == 6.687355f)//an ftasei se sugekrimeno upsos pairnei 100 points kai mia zwh
        {          
            points1 = points1 + 10;
            SetCountText();
        }

        if (controller.transform.position.y <= -0.5f)//an pesei ap to floor xanei mia zwh
        {
            lifes = 1;
            SetCountText();
        }
        if (points+points1 < 0)
        {
           
            lifes = lifes - 1;//an oi podoi pane katw apo 0 xaneis mia zwh
            SetCountText();
        }
        
        Destroyclicks = ClickOnFaceScript.DClicks();//kathe click 10 monades
         points = Destroyclicks * 10;
         SetCountText();

         Buildclicks = ClickOnFaceScript.BClicks();//me kathe xtisimo afairoudai 5 monades
         points = points-Buildclicks * 5;
         SetCountText();


        moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);

     
        controller.Move(moveDirection * Time.deltaTime);
    }

    private void SetCountText()
    {

        if (points + points1 < 0) { 
            points = 0;
            points1 = 0;
            lifes = 2;
    }
        int finalp = points + points1;//points apo gremismata kai apo megisto upsos
        countPoints.text = "Points: " + finalp.ToString();
        
        life.text = "Life: " + lifes.ToString();

        //if (finalp == 100 || finalp == 200 || finalp == 300)//kathe 100 points
        if (finalp >= 200)
            {
                if (lifes <= 3)// megistes zwes 5
                {
                    //lifeText.text = ">>> Kerdises 1 Zwh <<<";
                    lifes += 1;
                }
            }
            else if (finalp <= 0 && lifes == 0)
            {
                lifes = 0;
                life.text = "Life: " + lifes.ToString();
        }
        

    }


}