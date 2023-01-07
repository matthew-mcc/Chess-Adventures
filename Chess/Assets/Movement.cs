using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject blackPieces;
    [SerializeField] GameObject whitePieces;

    Vector3 worldPos;
    Transform selectedPiece = null;



    bool pieceSelected = false;
    bool firstClick = false;
    //FEN starting position --> White to move
    public string gameState = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";
    

    void Start()
    {

        
        //Init board
        
        
        
        //Debug.Log(gameObject.name);

        // Debug.Log(whitePieces.transform.childCount);
        // foreach(Transform child in whitePieces.transform){
        //     Debug.Log(child.name);
        // }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        

        // ON CLICK
        if(Input.GetMouseButtonDown(0)){
            

            Transform targetSquare = gameObject.transform.transform;
            //Transform currSquare = gameObject.transform;

            Vector3 mousePos = Input.mousePosition;
            //mousePos.z = Camera.main.nearClipPlane;
            mousePos.z = 1;
            worldPos = Camera.main.ScreenToWorldPoint(mousePos);

            //Debug.Log(worldPos);

            
            
            // Check white pieces against mouse pos
            foreach(Transform child in whitePieces.transform){
                float xDiff = Mathf.Abs(child.position.x - worldPos.x);
                float yDiff = Mathf.Abs(child.position.y - worldPos.y);

                if(xDiff <= 0.5 && yDiff <= 0.5){
                    //Debug.Log(child.name);
                    if(selectedPiece != null && selectedPiece == child){
                        selectedPiece = null;
                    }
                    else{
                        selectedPiece = child;
                        pieceSelected = true;
                    }

                }
                // else if (selectedPiece.name == child.name){
                //     selectedPiece = null;
                // }
            }

            // Check black pieces against mouse pos
            foreach(Transform child in blackPieces.transform){
                float xDiff = Mathf.Abs(child.position.x - worldPos.x);
                float yDiff = Mathf.Abs(child.position.y - worldPos.y);

    
                if(xDiff <= 0.5 && yDiff <= 0.5){
                    
                    if(selectedPiece != null && selectedPiece == child){
                        selectedPiece = null;
                    }
                    else{
                        selectedPiece = child;
                        pieceSelected = true;
                    }

                    
                    
                }
                // else if (selectedPiece == child){
                //     selectedPiece = null;
                // }

            }

            if(pieceSelected){
                foreach(Transform child in gameObject.transform){

                    foreach(Transform rowChild in child.transform){

                        float xDiff = Mathf.Abs(rowChild.position.x - worldPos.x);
                        float yDiff = Mathf.Abs(rowChild.position.y - worldPos.y);

                        if(xDiff <= 0.5 && yDiff <= 0.5){

                            if(selectedPiece!=null){
                                selectedPiece.position = rowChild.position;
                                //pieceSelected = false;

                                //selectedPiece = null;
                            }

                            
                            //pieceSelected = false;
                            //selectedPiece = null;
                        }

                    }
                }
                
            }

            // Check tiles against mouse pos
            // foreach(Transform child in gameObject.transform){
            //     foreach(Transform rowChild in child.transform){
            //         float xDiff = Mathf.Abs(rowChild.position.x - worldPos.x);
            //         float yDiff = Mathf.Abs(rowChild.position.y - worldPos.y);
            //         if(xDiff <= 0.5 && yDiff <= 0.5){
            //             currSquare = rowChild;
            //         }
            //         //Debug.Log(rowChild.name);
            //     }
            // }
            

            if(selectedPiece != null){
                Debug.Log(selectedPiece.name);

            }
            else{
                Debug.Log("No piece selected");
            }
            //Debug.Log(pieceSelected);
            //Debug.Log(currSquare.name);
            
        }
        
        
    }

    
}
