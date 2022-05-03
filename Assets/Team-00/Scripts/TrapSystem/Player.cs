using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    public Main Main;
    //[SerializeField] private float speed = 0.1f;
    Animator animator;
    public SpriteRenderer Sprite;
    public bool IsLadder;
    //public bool Istbox;
    //public bool Isbbox; 
    public Collider2D Collider2D;

    public Vector3 GoalPos;
    public Vector2 CurrentPos;

    public bool isLaunch;

    private void Start()
    {
        instance = this;
        isLaunch = false;
        GoalPos = transform.position;       //定位
        this.animator = GetComponent<Animator>();
    }
    /*internal void MoveTo(Vector2 pos, string animation)
    {
        GoalPos = pos;
        Animator.Play(animation);           //動畫
        //Debug.Log("1");
        
    }*/
    private void Update()
    {
        Move();

        //Movement();
        //Debug.Log(CurrentPos.x);
        //Debug.Log(transform.position.y);
        //Debug.Log()
    }

    /*void LateUpdate()
    {
        if(transform.position.y > 16)
        {
            gameObject.transform.position -= new Vector3(0,1f,0);
        }
    }*/
    private void Move()
    {
        if (!Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
        {
            if (gameObject.transform.position.x <= 85.5 && gameObject.transform.position.x >= -90.5)
                if (Input.GetKey(KeyCode.A) && gameObject.transform.position.x > -89)
                {
                    gameObject.transform.position += new Vector3(-0.9f, 0, 0);
                    animator.Play("Player@Walk");
                    Sprite.flipX = false;
                }
            if (Input.GetKey(KeyCode.D) && gameObject.transform.position.x < 85)
            {
                gameObject.transform.position += new Vector3(0.9f, 0, 0);
                animator.Play("Player@Walk");
                Sprite.flipX = true;
            }
            if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                animator.Play("Player@Idle");
            }
        }


        if (IsLadder == true)
        {
            if (gameObject.transform.position.y <= 16.2 && gameObject.transform.position.y >= -20.5)
            {
                if (Input.GetKey(KeyCode.W) && gameObject.transform.position.y < 16)
                {
                    gameObject.transform.position += new Vector3(0, 0.07f, 0);
                    animator.Play("Player@Climb");
                    //if(transform.position.y >= 14.1)
                    //gameObject.transform.position += new Vector3(0,0,0);
                    //Debug.Log("1");
                }
                if (Input.GetKey(KeyCode.S) && gameObject.transform.position.y > -20)
                {
                    gameObject.transform.position += new Vector3(0, -0.07f, 0);
                    animator.Play("Player@Climb");
                    //if(transform.position.y <= -18.8)
                    //gameObject.transform.position += new Vector3(0,0,0);
                    //Debug.Log("2");
                }
            }
        }

        /*if(!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            animator.Play("Player@Idle");
        }*/
    }

    private void Stop()
    {
        animator.Play("Player@Idle");
        //Main.MoveCursor.SetActive(false);
        Collider2D.enabled = true;
    }

    public void LaunchTrap()
    {

        isLaunch = true;

    }

    

    public void OnTriggerEnter2D(Collider2D other)//接觸梯子物件 
    {
        // if (other != Main.Ladder) return;       //若非Ladder 返回
        // IsLadder = true;        //IsLadder為真

        // if (other = Main.Ladder)
        // {
        //     IsLadder = true;
        // }
        //transform.Translate(CurrentPos.y);
        /*if(other.gameObject.CompareTag("Cat"))
        {
            Collider2D.enabled = false;
        }*/
        //if (other.gameObject.CompareTag ("tbox"))
        /*if (other != Main.tbox) return;
        Istbox = true;*/

        //if (other.gameObject.CompareTag ("bbox"))
        /*if (other != Main.bbox) return;
        Isbbox = true;*/

        // 碰到 觸發

    if (isLaunch)
    {
        

        if (other.tag == "Mg_LandimineTrap")
        {

            fearBar.instance.MgmineBuild();
            Debug.Log("觸發mine");


        }

        if (other.tag == "DarkTrap")
        {
            fearBar.instance.DarktrapBuild();
            Debug.Log("觸發dark");


        }
        if (other.tag == "Trap-05")
        {
            fearBar.instance.BigtrapBuild();
            Debug.Log("觸發大規模");


        }
        if (other.tag == "SpikedTrap")
        {
            fearBar.instance.BigtrapBuild();
            Debug.Log("觸發尖刺");


        }
        if (other.tag == "Cat")
        {

            //  Debug.Log("cattttttt");            

        }

    }


    }


    void OnTriggerExit2D(Collider2D other)//離開物件
    {
        if (other != Main.Ladder) return;
        IsLadder = false;       //IsLadder不為真 

        /*if (other != Main.tbox) return;
        Istbox = false;*/

        /*if (other != Main.bbox) return;
        Isbbox = false;*/
    }

}
