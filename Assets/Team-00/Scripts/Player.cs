using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Main Main;
    [SerializeField] private float speed = 0.01f;
    public Animator Animator;
    public SpriteRenderer Sprite;
    public  bool IsLadder;
    public Collider2D Collider2D;

    public Vector3 GoalPos;
    public Vector2 CurrentPos;

    private void Start()
    {
        GoalPos = transform.position;       //定位
        
    }
    internal void MoveTo(Vector2 pos, string animation)
    {
        Animator.Play(animation);           //動畫
        GoalPos = pos;
        
    }
    private void Update()
    {
        Movement();
        //Debug.Log(CurrentPos.x);
        //Debug.Log(GoalPos.y);
        //Debug.Log()
    }

    private void Movement()
    {
        
                
        
            if (Vector2.Distance(transform.position, GoalPos) < 0.01f) { Stop(); return; }
                CurrentPos = transform.position;        //當前位置

                Sprite.flipX = true;
                if (CurrentPos.x > GoalPos.x) Sprite.flipX = false;
                Sprite.flipY = false;

                
                
            if ( 2.9f < CurrentPos.x && CurrentPos.x < 3.9f )
            {
                if (GoalPos.x > 3.9f) GoalPos.x = 3.9f;
                if (GoalPos.x < 2.9f) GoalPos.x = 2.9f;
                Collider2D.enabled = false;
                transform.position = Vector2.MoveTowards(new Vector3(CurrentPos.x,CurrentPos.y,0), new Vector3(GoalPos.x,GoalPos.y,0), speed);
                return;
                
            }
            else
            {
                Collider2D.enabled = false;
                transform.position = Vector2.MoveTowards(new Vector3(CurrentPos.x,CurrentPos.y,0), new Vector3(GoalPos.x,CurrentPos.y,0), speed);
            }
            
        
    }

    private void Stop()
    {
        Animator.Play("Player@Idle");
        Main.MoveCursor.SetActive(false);
        Collider2D.enabled = true;
    }

    void OnTriggerEnter2D(Collider2D other)//接觸梯子物件 
    {
        if (other != Main.Ladder) return;       //若非Ladder 返回
        IsLadder = true;        //IsLadder為真
        //transform.Translate(CurrentPos.y);

    }

    void OnTriggerExit2D(Collider2D other)//離開物件
    {
        if (other != Main.Ladder) return;
        IsLadder = false;       //IsLadder不為真
    }

}
