// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Trap : MonoBehaviour
// {
//     public GameObject Trapexplo;

//     //產生黃色爆炸物件
//     void OnTriggerEnter2D(Collider2D col)
//     {
//         //Instantiate(explo, transform.position, transform.rotation);
//         if (col.tag == "Cat")
//         {
//             Instantiate( Trapexplo, col.gameObject.transform.position, col.gameObject.transform.rotation);
//         }
//     }
// }
