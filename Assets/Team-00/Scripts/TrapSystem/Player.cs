using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //public Main Main;
    //[SerializeField] private float speed = 0.1f;
    public Animator animator;
    AnimatorStateInfo stateInfo;//判斷動畫狀態
    public SpriteRenderer Sprite;
    public  bool IsLadder;
    public Collider2D Collider2D;

    public Vector3 GoalPos;
    public Vector2 CurrentPos;

    public int cdtime = 0;
    //private Spawner CanSpawn;
    public static Player instance;
    //private Spawner setTrap.poistion;
     bool Switch;//private
     //bool Walk;
     private bool Built;
     public bool isPlaying;
    int X = 0;

    private void Start()
    {
        instance = this;
        //isLaunch = false;
        GoalPos = transform.position;       //定位
        /*this.*/animator = gameObject.GetComponent<Animator>();
        //Switch = GameData.Switch;
        Built = GameData.Built;
        //CanSpawn = Spawner.instance;
        //setTrap = Spawner.instance;
        /*Switch = false;
        Walk = true;
        Built = false;*/
    }

    /*internal void MoveTo(Vector2 pos, string animation)
    {
        GoalPos = pos;
        Animator.Play(animation);           //動畫
        //Debug.Log("1");
        
    }*/

    private void Update()
    {   
        stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        isAniEnd();
        Info();
        /*else if(Built == false)
        {
            
        }*/
        //Switch = GameData.Switch;        
        /*else if(Built == false)
        {
            animator.SetBool("Building", false);
        }*/
        Move();
        //Build();
        //Debug.Log("Player.Switch="+GameData.Switch);
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
    void Move()//暗部移動
    {               
            if(Input.GetKey(KeyCode.A))
            {
                {
                    animator.SetBool("Walking", true);
                    gameObject.transform.position += new Vector3(-0.05f,0,0);                    
                    Sprite.flipX = false;
                }                                  
            }
            if(Input.GetKey(KeyCode.D))
            {
                {
                    animator.SetBool("Walking", true);
                    gameObject.transform.position += new Vector3(0.05f,0,0);
                    Sprite.flipX = true;
                }
            }
            if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                animator.SetBool("Walking", false);
            }
            
            if (gameObject.transform.position.x > 96 
            && gameObject.transform.position.y == 21 )
            {//移動至下層樓right
                gameObject.transform.position = new Vector3(-99f, -19f, 0);
        
            }

            if (gameObject.transform.position.x < -99 
            && gameObject.transform.position.y == -19 )
            {//移動至上層樓
                gameObject.transform.position = new Vector3(96f, 21f, 0);
                
            }        
    }

    void Info()//冷卻調用
    {
        if(IsLadder == true)
            if(Input.GetKey(KeyCode.Space))
            {
                animator.SetTrigger("Built");
                //GameData.Built = Built;         
            }
        //Debug.Log(Built + "01");
    }

    private void isAniEnd()//動畫狀態判斷
    {
        if (stateInfo.IsName("Player@Build") && stateInfo.normalizedTime >= 1.0f)
	    {
            Built = true;
            GameData.Built = Built; 
	    }
	    else if (stateInfo.IsName("Player@Build") && stateInfo.normalizedTime <= 0.0f)
	    {
            Built = false;
            GameData.Built = Built; 
	    }
    }
    /*void Build()//建造動畫
    {
            if(IsLadder == true)
            {
                if(Input.GetKey(KeyCode.Space))
                {
                    animator.SetTrigger("Built");
                    //Built = true;
                }
            }
    }*/

    /*public void Coldtime()
    {
        // IDK_HOW_CD_SYSTEM_WORK_AND_WHAT_DATA_I_SHOULD_USE = true;

        // MAY_BE_IS_TIME -= 1;
    }*/

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("CanSpawn"))
        {   
            IsLadder = true; 
        }

        
        

        // 碰到 觸發

    //if (isLaunch)
        

        // if (other.tag == "Trap05")
        // {
        //     fearBar.instance.DarktrapBuild();
        //     Debug.Log("觸發dark");


        // }
        // if (other.tag == "Trap06")
        // {
        //     fearBar.instance.BigtrapBuild();
        //     Debug.Log("觸發大規模");


        // }
        // if (other.tag == "Trap01")
        // {
        //     fearBar.instance.BigtrapBuild();
        //     Debug.Log("觸發尖刺");


        // }


    }
}
