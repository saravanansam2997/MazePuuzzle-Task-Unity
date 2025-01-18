using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private List<Button> _RotButtonList;
     [SerializeField]
    private List<Button> _GateSWList;
    [SerializeField]
    private List<bool> _GateSWListBol;
    // private bool[,,,] _GateLineList= new bool[2,2,2,2]
    // {{
    //     {{false,true,true},{true,false,false}},
    //                                                   {{true,true,false},{false,false,true}},
    //                                                   {{true,true,true,false,false},{false,false,false,true,true}},
    //                                                   {{true,false,false,true,true},{false,true,true,false,false}}
    //                                                   }};
     private bool[,,] _GateLineList = new bool[4, 2, 5]
    {
        { // First group
            
                { false, true, true, false, false }, 
                { true, false, false, false, false }
            
        },
        { // Second group
                { true, true, true, false, false }, 
                { false, false, false, true, true }
        },
        { // Third group
                { true, true, true, false, false }, 
                { false, false, false, true, true }
        },
        { // Fourth group
                { true, true, true, true, true }, 
                { false, false, false, false, false }
        }
        };
      [SerializeField]
    private GameObject _PuzzleviewParent;
    [SerializeField]
    private List<GameObject> _BallsList;
    [SerializeField]
    private List<Vector3> _BallsListStartTF;
      [SerializeField]
    private Dictionary<string,Transform> _GatesLineTFArr=new Dictionary<string,Transform>() ;
      [SerializeField]
    private GameObject _GameOverView;
    private bool _IsGameOver=false;
    private bool _IsStartGame=false;
     private float puzzlerotationangle=0f;
    
    void PuzzlerotAnim(int rotbuttonnum){
        //float rotationangle=0f;
        
        
         if(rotbuttonnum==0){
        puzzlerotationangle+=90f;
         }
         else{
             puzzlerotationangle-=90f;
         }
         if (puzzlerotationangle > 360)
        {
            puzzlerotationangle = 0;
        }
        // if(rotbuttonnum==0){
        // if(_PuzzleviewParent.transform.rotation.z==0f||_PuzzleviewParent.transform.rotation.z==360f){
        //     rotationangle=90f;
        // }
        // else  if(_PuzzleviewParent.transform.rotation.z==90f){
        //    rotationangle=180f;
        // }
        // else  if(_PuzzleviewParent.transform.rotation.z==180f){
        //    rotationangle=270f;
        // }
        // else  if(_PuzzleviewParent.transform.rotation.z==270f){
        //    rotationangle=360f;
        // }
        
        // }
        // else{
        //      if(_PuzzleviewParent.transform.rotation.z==0f||_PuzzleviewParent.transform.rotation.z==360f){
        //     rotationangle=270f;
        // }
        // else  if(_PuzzleviewParent.transform.rotation.z==270f){
        //    rotationangle=180f;
        // }
        // else  if(_PuzzleviewParent.transform.rotation.z==180f){
        //    rotationangle=90f;
        // }
        // else  if(_PuzzleviewParent.transform.rotation.z==90f){
        //    rotationangle=0f;
        // }
        
        // }
        Debug.Log("-------------rotationangle----------"+puzzlerotationangle);
       _PuzzleviewParent.transform.DORotate(new Vector3(_PuzzleviewParent.transform.rotation.x,_PuzzleviewParent.transform.rotation.y,puzzlerotationangle),1f);
//_PuzzleviewParent.transform.rotation=Quaternion.Euler(new Vector3(_PuzzleviewParent.transform.rotation.x,_PuzzleviewParent.transform.rotation.y,rotationangle));
    }
    void PuzzleSw_GateAnim(int swbuttonnum){
         bool istoggle=false;
         float rotationangle=0f;
         if(_GateSWListBol[swbuttonnum]){
             istoggle=false;
             rotationangle=0;
             _GateSWListBol[swbuttonnum]=istoggle;
         }
         else{
            istoggle=true;
              rotationangle=180;
             _GateSWListBol[swbuttonnum]=istoggle;
         }
       _GateSWList[swbuttonnum].transform.rotation=Quaternion.Euler(new Vector3(_GateSWList[swbuttonnum].transform.rotation.x,_GateSWList[swbuttonnum].transform.rotation.y,rotationangle));
       puzzleSw_GateUpdate();

    }
    void puzzleSw_GateUpdate(){
        
        // if(_PuzzleviewParent.GetComponent<Transform>().FindW)
for (int i = 0; i < _GateLineList.GetLength(0); i++)
        {
           // Console.WriteLine($"Group {i + 1}:");
        //    for (int j = 0; j < _GateLineList.GetLength(1); j++)
          //  {
               // Console.WriteLine($"  Layer {j + 1}:");
               // for (int k = 0; k < _GateLineList.GetLength(2); k++)
               // {
                    //Console.Write("    Row: ");
                    for (int l = 0; l < _GateLineList.GetLength(2); l++)
                    {
                        if(_GatesLineTFArr.ContainsKey(("gate"+i+l).ToString())==true){
                        //Console.Write(_GateLineList[i, j, k, l] + " ");
                        if(_GatesLineTFArr.ContainsKey(("gate"+i+l).ToString())&&_GateSWListBol[i]==true){
                            if(_GateLineList[i,1,l]){
                        _GatesLineTFArr[("gate"+i+l).ToString()].GetComponent<SpriteRenderer>().color=new Color( _GatesLineTFArr[("gate"+i+l).ToString()].GetComponent<SpriteRenderer>().color.r, _GatesLineTFArr[("gate"+i+l).ToString()].GetComponent<SpriteRenderer>().color.g, _GatesLineTFArr[("gate"+i+l).ToString()].GetComponent<SpriteRenderer>().color.b,1f);
                             _GatesLineTFArr[("gate"+i+l).ToString()].GetComponent<PolygonCollider2D>().enabled=true;
                    }
                            else{
                        _GatesLineTFArr[("gate"+i+l).ToString()].GetComponent<SpriteRenderer>().color=new Color( _GatesLineTFArr[("gate"+i+l).ToString()].GetComponent<SpriteRenderer>().color.r, _GatesLineTFArr[("gate"+i+l).ToString()].GetComponent<SpriteRenderer>().color.g, _GatesLineTFArr[("gate"+i+l).ToString()].GetComponent<SpriteRenderer>().color.b, 0.5f);
                              _GatesLineTFArr[("gate"+i+l).ToString()].GetComponent<PolygonCollider2D>().enabled=false;
                               }
                         
                          Debug.Log("_GatesLineTFArrss"+"gate"+i+l);
                        }
                        else if(_GatesLineTFArr.ContainsKey("gate"+i+l)&&_GateSWListBol[i]==false){
                               if(_GateLineList[i,0,l]){
                        _GatesLineTFArr[("gate"+i+l).ToString()].GetComponent<SpriteRenderer>().color=new Color( _GatesLineTFArr[("gate"+i+l).ToString()].GetComponent<SpriteRenderer>().color.r, _GatesLineTFArr[("gate"+i+l).ToString()].GetComponent<SpriteRenderer>().color.g, _GatesLineTFArr[("gate"+i+l).ToString()].GetComponent<SpriteRenderer>().color.b,1f);
                               _GatesLineTFArr[("gate"+i+l).ToString()].GetComponent<PolygonCollider2D>().enabled=true;
                               }
                            else{
                        _GatesLineTFArr[("gate"+i+l).ToString()].GetComponent<SpriteRenderer>().color=new Color( _GatesLineTFArr[("gate"+i+l).ToString()].GetComponent<SpriteRenderer>().color.r, _GatesLineTFArr[("gate"+i+l).ToString()].GetComponent<SpriteRenderer>().color.g, _GatesLineTFArr[("gate"+i+l).ToString()].GetComponent<SpriteRenderer>().color.b, 0.5f);
                              _GatesLineTFArr[("gate"+i+l).ToString()].GetComponent<PolygonCollider2D>().enabled=false;
                               }
                           // _GatesLineTFArr[("gate"+j+l).ToString()].gameObject.SetActive(_GateLineList[i,j,0,l]);
                            Debug.Log("_GatesLineTFArrsss"+"gate"+i+l+"===boll"+_GateLineList[i,0,l]);
                        }
                          //Debug.Log("_GatesLineTFArrsss"+_GatesLineTFArr[("gate"+j+l).ToString()]);
                          Debug.Log("ssssssiiiiis"+i);
                         // Debug.Log("ssssssjjjjjjs"+j);
                        Debug.Log("ssssssllllls"+l);
                        }
                    }
                    //Console.WriteLine();
                //}
            //}
        }
    }
    
   void PuzzleButtonsAddEvent(){
    foreach(Button tmprot in _RotButtonList){
     tmprot.onClick.AddListener(() => PuzzleButtonClick(tmprot.name));
    }
    foreach(Button tmpgate in _GateSWList){
     tmpgate.onClick.AddListener(() => PuzzleButtonClick(tmpgate.name));
    }
   } 
    void PuzzleButtonClick(string tmpbuttonstr){
      if (tmpbuttonstr == "Sw_Btn0")
        {
         PuzzleSw_GateAnim(0);
        }
        else if (tmpbuttonstr == "Sw_Btn1") {
PuzzleSw_GateAnim(1);
        }
        else if (tmpbuttonstr == "Sw_Btn2") {
PuzzleSw_GateAnim(2);
        }
        else if (tmpbuttonstr == "Sw_Btn3") {
PuzzleSw_GateAnim(3);
        }
        else if (tmpbuttonstr == "Rot_button0") {
PuzzlerotAnim(0);
        }
        else if (tmpbuttonstr == "Rot_button1") {
PuzzlerotAnim(1);
        }
    }
    void puzzleAnsCheck(){
        int AnsChecknum=0;
        for(int i=0;i<_BallsList.Count;i++){
       if(_BallsList[i].GetComponent<PuzzlePieceBallHandler>()._IsFixBall){
        AnsChecknum++;
       }
        }
        if(AnsChecknum==_BallsList.Count){ 
     _IsGameOver=true;
        }
        if(_IsGameOver){
        _GameOverView.SetActive(true);
        }
    }
    void Start()
    {
        _IsStartGame=true;
        _GatesLineTFArr.Clear();
        _GateSWListBol=new List<bool>(){false,false,false,false};
        puzzlerotationangle=0f;
        GameObject[] tmpGatesLineTFArr=GameObject.FindGameObjectsWithTag("GatesLine"); 
        foreach(GameObject gate in tmpGatesLineTFArr){
            _GatesLineTFArr.Add(gate.name.ToString(),gate.transform);
        }
        PuzzleButtonsAddEvent();
        puzzleSw_GateUpdate();
    }
   public void puzzleReplay()
   {
SceneManager.LoadScene("PUzzle");
   
   }

    // Update is called once per frame
    void Update()
    {
        if(_IsStartGame&&!_IsGameOver){
        puzzleAnsCheck();
        }
    }
}
