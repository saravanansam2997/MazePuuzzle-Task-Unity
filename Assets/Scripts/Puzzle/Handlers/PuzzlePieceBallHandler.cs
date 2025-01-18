using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzlePieceBallHandler : MonoBehaviour
{
    public int ballNum;
    public bool _IsFixBall=false;
    //public string ballnamestr;
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }
    void Init(){
       //ballNum=tmpballNum;
       this.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
    }
    void OnTriggerEnter(Collider other){
        

    }

    // Update is called once per frame
    // void Update()
    // {
        
    // }
}
