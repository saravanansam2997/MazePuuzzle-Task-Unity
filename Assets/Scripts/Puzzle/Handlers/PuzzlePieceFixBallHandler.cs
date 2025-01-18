using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzlePieceFixBallHandler : MonoBehaviour
{
    public int ballNum;
    public bool _IsFixBall=false;
    // Start is called before the first frame update
    void Start()
    {
   //       Init( ballNum);
    }
    void Init(int tmpballNum){
       //ballNum=tmpballNum;
     //  this.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
      Debug.Log("FixBall"+other.tag);
        if(other.tag=="FixBall"){
             if(other.gameObject.GetComponent<PuzzlePieceBallHandler>().ballNum==ballNum){
               //   other.gameObject.GetComponent<CircleCollider2D>().enabled=false;
              //other.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
             // other.gameObject.GetComponent<Rigidbody2D>().bodyType=RigidbodyType2D.Static;
               other.gameObject.GetComponent<Rigidbody2D>().simulated = false;
                other.gameObject.GetComponent<SpriteRenderer>().color=new Color(other.gameObject.GetComponent<SpriteRenderer>().color.r,other.gameObject.GetComponent<SpriteRenderer>().color.g,other.gameObject.GetComponent<SpriteRenderer>().color.b,0.5f);
               other.gameObject.GetComponent<PuzzlePieceBallHandler>()._IsFixBall=true;
                other.gameObject.transform.position =this.gameObject.transform.position;
             } 
        }
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}
