using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSpacePractice : MonoBehaviour {

    public Button button;
    public Text buttonText;
    //public Image buttonSprite;
    public TutorialController gameController;
    //public List<string> pL= new List<string>() {"EmptyGridSpace29", "EmptyGridSpace28", "EmptyGridSpace27"};

    public void SetSpace() {
        gameController.EnableAllBoardButtons();
        print("target: " + gameController.currenttargettool);
        print("space tag " + button.tag);
        //if (button.tag == gameController.currenttargettile || (button.tag == gameController.currenttargettool)){
        if (button.tag == gameController.currenttargettile){
            button.image.sprite = gameController.GetToolSprite ();
		    TagSelectedTileWithToolType ();
            if (gameController.phase == 1){
                 gameController.DisplayNofication_FirstToolPlacementConfirmation();
            }
            else if (gameController.phase == 2){
                gameController.DisplayNofication_SecondToolPlacementConfirmation();
            }
            else if (gameController.phase == 3){
                gameController.DisplayNofication_ThirdToolPlacementConfirmation();
            }
            //gameController.DisplayNofication_FirstToolPlacementConfirmation();
        
            gameController.StartTrialBtn.interactable = true;
            //gameController.EnableAllBoardButtons();
            gameController.ResetWaitingBools();
            gameController.waitingforstart = true; 
        }
        else{
            //FIXME: UNCOMMENT IF SELECT CORRECT GRID SPACE MESSAGE NEEDED;
            //gameController.DisplayNofication_PlaceBlackSquare();
            //if tool placed == false (blue highlighter still there) display please display blue highlight notification otherwaise display press start notification
            if (gameController.waitingforstart == false){
                gameController.DisplayNotification_BlueHiglightNotification();

            }else{
                gameController.DisplayNotification_PressStartBeforeAnotherToolPlacement();
            }
           
    
        }
        

    }
        

    public void SetGameControllerReference(TutorialController controller) {
        gameController = controller;
    }
    public void TagSelectedTileWithToolType(){
        if (gameController.GetSelection() == 0)
        {
            button.gameObject.tag = "BlackCircleTool";
        }
        else if (gameController.GetSelection() == 1)
        {
            button.gameObject.tag = "WhiteCircleTool" ;
        }
        else if (gameController.GetSelection() == 2)
        {
            button.gameObject.tag = "BlackTriangleTool";
        }
        else if (gameController.GetSelection() == 3)
        {
            button.gameObject.tag = "WhiteTriangleTool";
        }
        else if (gameController.GetSelection() == 4)
        {
            button.gameObject.tag = "BlackSquareTool";
        }
        else if (gameController.GetSelection() == 5)
        {
            button.gameObject.tag = "WhiteSquareTool";
        }

    }


   

   
}
