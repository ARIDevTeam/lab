using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

//check this here

public class TutorialController : MonoBehaviour {
    public GameObject MessageBoxPanel;
    public Button BeginExerciseBtn;
    public Button StartPracticTrialBtn;
    public Button StartTrialBtn;
    public Button ResetBtn;
    public Text StartFirstTrialMsg;
    public Text SuccessfulAttemptMsg;
    public Text FailedAttemptMsg;
    public Text TooManyStepsMsg;
    public Text TimeAllottedExpiredMsg;
    public Text XGridSpaceMsg;
    public Text CheckGridSpaceMsg;
    public Text CompletedExerciseMsg;
    public Text StartPracticeTrialMsg;
    public Text FirstStepPracticeMsg;
    public Text SelectBlackSquarePracticeMsg;
    public Text BlackSquarePlacementPracticeMsg;
    public Text FirstToolConfirmationPracticeMsg;
    public Text RemovalButtonPracticeMsg;
    public Text SelectWhiteCirclePracticeMsg;
    public Text WhiteCirclePlacementPracticeMsg;
    public Text SecondToolConfirmationPracticeMsg;
    public Text OneMoreToolPracticeMsg;
    public Text ResetButtonPracticeMsg;
    public Text ThirdToolConfirmtionPracticeMsg;
    public Text BlackCirclePlacmentPracticeMsg;
    public Text SelectBlackSquareBeforeAnotherToolMsg;
    public Text SelectBlueBoxMsg;
    public Text ClickStartPracticeMsg;
    public Text WhiteToolNeededPracticeMsg;
    public Text SelectBlackCirclePracticeMsg;
    public Text PleasePlaceBlackSquareMsg;
    public Text PleasePlaceWhiteCircleMsg;
    public Text PleasePlaceBlackCircleMsg;
    public Text ClickStartBeforeNextPlacementPracticeMsg;
    
    public Button[] gridSpaces;
    public Sprite[] boardToolSprite;
    public Sprite toolSprite;
    public GameObject BB1;
    public GameObject BB2;
    public GameObject WB1;
    public GameObject WB2;
    public MovementScriptPractice movementScript_bb1;
    public MovementScriptPractice movementScript_bb2;
    public MovementScriptPractice movementScript_wb1;
    public MovementScriptPractice movementScript_wb2;
    Vector2 initialPosition_BB1;
	Vector2 initialPosition_BB2;
	Vector2 initialPosition_WB1;
	Vector2 initialPosition_WB2;

    public Player blackCircleLegendTile;
    public Player whiteCircleLegendTile;
    public Player blackSquareLegendTile;
    public Player whiteSquareLegendTile;
    public Player blackTriangleLegendTile;
    public Player whiteTriangleLegendTile;
    public Player removeTool;
    public int phase;
    public int selection;
    public int targetselection;
    public int target;
    public int winLevelCondition;
    public string currenttargettile;
    public string currenttargettool;
    public bool completedcurrentphase;
    public bool waitingforyoutoplaceblacksquaretool;
    public bool waitingforyoutoplacewhitecircletool;
    public bool waitingforyoutoplaceblackcircletool;
    public bool waitingforstart;
   // public string targettool;
    List<int> xTiles = new List<int>() { 0, 1, 2, 5, 6, 7, 8, 16, 24, 32, 40, 48, 56, 57, 58, 60, 62, 63, 55, 47, 39, 31, 23, 15, 7,64,65,66,67};
    List<int> checkTiles = new List<int>() {59, 61};
    public List<string> blackList = new List <string>(){"blackball", "whiteball", "EmptyGridSpace" };
    public List<string> pL= new List<string>() {"EmptyGridSpace28", "EmptyGridSpace29", "EmptyGridSpace27"};
    public List<string> newTagList= new List<string>() {"BlackSquareTool", "WhiteCircleTool", "BlackCircleTool"};
   // public List<int> targettoolint = new List<int>(){4, 1, 0}

    
    //public Text AttemptFailedPracticeMsg;
    // Use this for initialization
    void Start () {
        MessageBoxPanel.gameObject.SetActive(false);
        BeginExerciseBtn.gameObject.SetActive(false);
        StartPracticTrialBtn.gameObject.SetActive(true);
        StartTrialBtn.gameObject.SetActive(false);
        ResetBtn.gameObject.SetActive(false);
        phase = 0;
        target = 28;
        currenttargettile = pL[0];
        currenttargettool = newTagList[0];
        selection = -1;
        SetGameControllerReferenceOnButtons();
        winLevelCondition = 0;
        completedcurrentphase = false;
        waitingforyoutoplaceblacksquaretool = false;
        waitingforyoutoplacewhitecircletool = false;
        waitingforyoutoplaceblackcircletool = false;
        waitingforstart = false;

        initialPosition_BB1 = BB1.gameObject.transform.position;
		initialPosition_BB2 = BB2.gameObject.transform.position;
		initialPosition_WB1 = WB1.gameObject.transform.position;
		initialPosition_WB2 = WB2.gameObject.transform.position;
    }
    
    public void StartPraticeTrial(){
        phase = 1;
        StartPracticTrialBtn.gameObject.SetActive(false);
        StartTrialBtn.gameObject.SetActive(true);
        StartTrialBtn.interactable = false;
        ResetBtn.gameObject.SetActive(true);
        MessageBoxPanel.gameObject.SetActive(true);
        MakeAllTextInvisible();
        FirstStepPracticeMsg.gameObject.SetActive(true);
        EnableLegendToolSelectionButtons();
        SetUpBoard();
        
    }

    public void StartTrial(){
        //GameStateOn = true;
        waitingforstart = false;
		movementScript_bb1.destination = transform.position;
		movementScript_bb2.destination = transform.position;
		movementScript_wb1.destination = transform.position;
		movementScript_wb2.destination = transform.position;
		//ms.destination = transform.position;

		movementScript_bb1.direction = "down";
		movementScript_bb2.direction = "down";
		movementScript_wb1.direction = "down";
		movementScript_wb2.direction = "down";
		//ms.direction = "down";

		movementScript_bb1.keepMoving = true;
		movementScript_bb2.keepMoving = true;
		movementScript_wb1.keepMoving = true;
		movementScript_wb2.keepMoving = true;
		//ms.keepMoving = true;



        //DisableStartTrialBtn();
        //StartTrialBtn.gameObject.SetActive(false);
        StartTrialBtn.interactable = false;
        DisableAllThumbnails();
        DisableLegendToolSelectionButtons();

    }

    public void ResetTrial(){
        DisplayNotification_ResetButtonFunctionality();
    }

    public void RetsetPhase(){
        if (phase == 1){
            MessageBoxPanel.gameObject.SetActive(true);
            MakeAllTextInvisible();
            ResetButtonPracticeMsg.gameObject.SetActive(true);
        }
        else if (phase == 2){

            MessageBoxPanel.gameObject.SetActive(true);
            MakeAllTextInvisible();
            WhiteToolNeededPracticeMsg.gameObject.SetActive(true);
            //DemoSelectBlackSquare();  
        }
        else if (phase == 3){

            MessageBoxPanel.gameObject.SetActive(true);
            MakeAllTextInvisible();
            OneMoreToolPracticeMsg.gameObject.SetActive(true);
            //DemoSelectBlackSquare();  
        }


        //SetUpBoard();
        winLevelCondition = 0;
		MovePlayersToStartingPosition();
        movementScript_bb1.keepMoving = false;
        movementScript_bb2.keepMoving = false;
        movementScript_wb1.keepMoving = false;
        movementScript_wb2.keepMoving = false;

		movementScript_bb1.turn = 0;
		movementScript_bb2.turn = 0;
		movementScript_wb1.turn = 0;
		movementScript_wb2.turn = 0;

		movementScript_bb1.rb.velocity = Vector2.zero;
		movementScript_bb2.rb.velocity = Vector2.zero;
		movementScript_wb1.rb.velocity = Vector2.zero;
		movementScript_wb2.rb.velocity = Vector2.zero;

        EnableAllThumbnails();
        EnableLegendToolSelectionButtons();
        
        //EnableStartTrialBtn();
        //StartTrialBtn.gameObject.SetActive(false);
        StartTrialBtn.interactable = false;
        //MovePlayersToStartingPosition();

    }
    public void SetUpBoard(){
        for (int i = 0; (i < 68); i++)
        {

            if (xTiles.Contains(i))
            {
                gridSpaces[i].image.sprite = boardToolSprite[9];
                gridSpaces[i].tag = "XTile";
            }
            else if (checkTiles.Contains(i))
            {
                gridSpaces[i].image.sprite = boardToolSprite[8];
                gridSpaces[i].tag = "CheckTile";
            }
            else
            {
                gridSpaces[i].image.sprite = boardToolSprite[10];
				gridSpaces [i].tag = "EmptyGridSpace";
            }
        }

    }

    void MakeAllTextInvisible(){

        StartFirstTrialMsg.gameObject.SetActive (false);
        SuccessfulAttemptMsg.gameObject.SetActive (false);
        FailedAttemptMsg.gameObject.SetActive (false);
        TooManyStepsMsg.gameObject.SetActive (false);
        TimeAllottedExpiredMsg.gameObject.SetActive (false);
        XGridSpaceMsg.gameObject.SetActive (false);
        CheckGridSpaceMsg.gameObject.SetActive (false);
        CompletedExerciseMsg.gameObject.SetActive (false);

        //Make practice text invisible
        StartPracticeTrialMsg.gameObject.SetActive(false);
        FirstStepPracticeMsg.gameObject.SetActive(false);
        SelectBlackSquarePracticeMsg.gameObject.SetActive(false);
        BlackSquarePlacementPracticeMsg.gameObject.SetActive(false);
        FirstToolConfirmationPracticeMsg.gameObject.SetActive(false);
        //WhiteCirclePlacementPracticeMsg.gameObject.SetActive(false);
        RemovalButtonPracticeMsg.gameObject.SetActive(false);
        SelectWhiteCirclePracticeMsg.gameObject.SetActive(false);
        //WhiteCirclePlacementPracticeMsg.gameObject.SetActive(false);
        WhiteCirclePlacementPracticeMsg.gameObject.SetActive(false);
        SecondToolConfirmationPracticeMsg.gameObject.SetActive(false);
        OneMoreToolPracticeMsg.gameObject.SetActive(false);
        ResetButtonPracticeMsg.gameObject.SetActive(false);
        ThirdToolConfirmtionPracticeMsg.gameObject.SetActive(false);
        BlackCirclePlacmentPracticeMsg.gameObject.SetActive(false);
        StartFirstTrialMsg.gameObject.SetActive(false);
        SelectBlackSquareBeforeAnotherToolMsg.gameObject.SetActive(false);
        SelectBlueBoxMsg.gameObject.SetActive(false);
        ClickStartPracticeMsg.gameObject.SetActive(false);
        WhiteToolNeededPracticeMsg.gameObject.SetActive(false);
        SelectBlackCirclePracticeMsg.gameObject.SetActive(false);
        PleasePlaceBlackCircleMsg.gameObject.SetActive(false);
        PleasePlaceBlackSquareMsg.gameObject.SetActive(false);
        PleasePlaceWhiteCircleMsg.gameObject.SetActive (false);
        ClickStartBeforeNextPlacementPracticeMsg.gameObject.SetActive(false);
    

    }
    public bool DetermineActionRequiredStatus(){
        if ((waitingforyoutoplaceblackcircletool == true) || (waitingforyoutoplaceblacksquaretool == true) || (waitingforyoutoplacewhitecircletool == true)){
           return true;
        }else{
            return false;
        }
    }
    // public void TriggerActionRequiredNotification(){
    //     if (DetermineActionRequiredStatus() == true){
    //         DisplayNotification_ActionNeededToolPlacement(); 
    //     }
    // }
    public void DemoSelectBlackCircle(){
        if (waitingforstart == true){
            DisplayNotification_PressStartBeforeAnotherToolSelection();
        }else{
            if (phase == 1){
                if (DetermineActionRequiredStatus() == true){
                    DisplayNotification_ActionNeededToolPlacement(); 
                }else{
                    SelectedFirstToolInsteadNotification();
                }
                
            }
            else if (phase == 2){
                if (DetermineActionRequiredStatus() == true){
                    DisplayNotification_ActionNeededToolPlacement(); 
                }else{
                    SelectSecondToolInsteadNotification();
                }
            }
            else if (phase == 3){
                if (DetermineActionRequiredStatus() == false){
                    //ThirdToolConfirmationNotification();
                    SelectedThirdToolConfirmationNotification();
                    HighlightTile(target); 
                    DisableAllThumbnails();
                    blackCircleLegendTile.thumbnail.enabled = true;
                    toolSprite = boardToolSprite[0];
                    //DisableAllButTargetButton(target);
                    ChangeTagOfTargetTileButton();
                    selection = 0;
                    waitingforyoutoplaceblackcircletool = true;
                }
            } 
        }
        
        
    }
    public void DemoSelectWhiteCircle(){
         if (waitingforstart == true){
            DisplayNotification_PressStartBeforeAnotherToolSelection();
        }else{
            if (phase == 1){
                    if (DetermineActionRequiredStatus() == true){
                    DisplayNotification_ActionNeededToolPlacement(); 
                    }else{
                        SelectedFirstToolInsteadNotification();
                    }
                    
                }
                else if (phase == 2){
                    if (DetermineActionRequiredStatus() == false){
                        //SecondToolConfirmationNotification();
                        SelectedSecondToolConfirmationNotification();
                        HighlightTile(target); 
                        DisableAllThumbnails();
                        //whiteCicleLegendTile.thumbnail.enabled = true;
                        whiteCircleLegendTile.thumbnail.enabled = true;
                        toolSprite = boardToolSprite[1];
                        //DisableAllButTargetButton(target);
                        ChangeTagOfTargetTileButton();
                        selection = 1;
                        waitingforyoutoplacewhitecircletool = true;
                    }
            
                }
                else if (phase == 3){
                    if (DetermineActionRequiredStatus() == true){
                    DisplayNotification_ActionNeededToolPlacement(); 
                    }else{
                        SelectThirdToolInsteadNotification();
                    }
                    
                }  
        }
        
        
    }
    public void DemoSelectBlackSquare(){
         if (waitingforstart == true){
            DisplayNotification_PressStartBeforeAnotherToolSelection();
        }else{
            if (phase == 1){
                //phase+=1;
                if (DetermineActionRequiredStatus() == false){
                    //DisplayNotification_ActionNeededToolPlacement(); 
                    //SelectSecondToolInsteadNotification();
                    SelectedFirstToolConfirmationNotification();
                    //FirstToolConfirmationNotification();
                    HighlightTile(target);
                    blackSquareLegendTile.thumbnail.enabled = true;
                    toolSprite = boardToolSprite[4];
                    //DisableAllButTargetButton(target);
                    ChangeTagOfTargetTileButton();
                    selection = 4;
                    waitingforyoutoplaceblacksquaretool = true;
                }
                
            }
            else if (phase == 2){
                if (DetermineActionRequiredStatus() == true){
                    DisplayNotification_ActionNeededToolPlacement(); 
                }else{
                    SelectSecondToolInsteadNotification();
                }
            }
            else if (phase == 3){
                if (DetermineActionRequiredStatus() == true){
                    DisplayNotification_ActionNeededToolPlacement(); 
                }else{
                    SelectThirdToolInsteadNotification();
                }          
            }  
        }
        
        
    }
    public void DemoSelectWhiteSquare(){ 
         if (waitingforstart == true){
            DisplayNotification_PressStartBeforeAnotherToolSelection();
        }else{
            if (phase == 1){
                if (DetermineActionRequiredStatus() == true){
                    DisplayNotification_ActionNeededToolPlacement(); 
                }else{
                    SelectedFirstToolInsteadNotification();
                }  
            }else if (phase == 2){
                if (DetermineActionRequiredStatus() == true){
                    DisplayNotification_ActionNeededToolPlacement(); 
                }else{
                    SelectSecondToolInsteadNotification();
                }
            }else if (phase == 3){
                if (DetermineActionRequiredStatus() == true){
                    DisplayNotification_ActionNeededToolPlacement(); 
                }else{
                    SelectThirdToolInsteadNotification();
                }
            }
        }  
    }
    public void DemoSelectBlackTriangle(){
         if (waitingforstart == true){
            DisplayNotification_PressStartBeforeAnotherToolSelection();
        }else{
            if (phase == 1){
                if (DetermineActionRequiredStatus() == true){
                    DisplayNotification_ActionNeededToolPlacement(); 
                }else{
                    SelectedFirstToolInsteadNotification();
                }  
            }else if (phase == 2){
                if (DetermineActionRequiredStatus() == true){
                    DisplayNotification_ActionNeededToolPlacement(); 
                }else{
                    SelectSecondToolInsteadNotification();
                }
            }else if (phase == 3){
                if (DetermineActionRequiredStatus() == true){
                    DisplayNotification_ActionNeededToolPlacement(); 
                }else{
                    SelectThirdToolInsteadNotification();
                }
                    
            }  
        }
        
        
    }
    public void DemoSelectWhiteTriangle(){ 
        if (waitingforstart == true){
            DisplayNotification_PressStartBeforeAnotherToolSelection();
        }else{
            if (phase == 1){
                if (DetermineActionRequiredStatus() == true){
                    DisplayNotification_ActionNeededToolPlacement(); 
                }else{
                    SelectedFirstToolInsteadNotification();
                }  
            }else if (phase == 2){
                if (DetermineActionRequiredStatus() == true){
                    DisplayNotification_ActionNeededToolPlacement(); 
                }else{
                    SelectSecondToolInsteadNotification();
                }
            }else if (phase == 3){
                if (DetermineActionRequiredStatus() == true){
                    DisplayNotification_ActionNeededToolPlacement(); 
                }else{
                    SelectThirdToolInsteadNotification();
                }        
            }  
        }
        
       
    }
    public void DemoSelectRemoveTool(){
         if (waitingforstart == true){
            DisplayNotification_PressStartBeforeAnotherToolSelection();
        }else{
            if (phase == 1){
                if (DetermineActionRequiredStatus() == true){
                    DisplayNotification_ActionNeededToolPlacement(); 
                }else{
                    SelectedFirstToolInsteadNotification();
                }  
            }else if (phase == 2){
                if (DetermineActionRequiredStatus() == true){
                    DisplayNotification_ActionNeededToolPlacement(); 
                }else{
                    SelectSecondToolInsteadNotification();
                }
            }else if (phase == 3){
                if (DetermineActionRequiredStatus() == true){
                    DisplayNotification_ActionNeededToolPlacement(); 
                }else{
                    SelectThirdToolInsteadNotification();
                }    
            }  
        }
        
        
    }
    void SelectedFirstToolConfirmationNotification(){
        MessageBoxPanel.SetActive(true);
        MakeAllTextInvisible();
        BlackSquarePlacementPracticeMsg.gameObject.SetActive(true);

    }
    void SelectedSecondToolConfirmationNotification(){
        MessageBoxPanel.SetActive(true);
        MakeAllTextInvisible();
        WhiteCirclePlacementPracticeMsg.gameObject.SetActive(true);

    }
    void SelectedThirdToolConfirmationNotification(){
        MessageBoxPanel.SetActive(true);
        MakeAllTextInvisible();
        BlackCirclePlacmentPracticeMsg.gameObject.SetActive(true);

    }
    void FirstToolConfirmationNotification(){
        MessageBoxPanel.SetActive(true);
        MakeAllTextInvisible();
        FirstToolConfirmationPracticeMsg.gameObject.SetActive(true);

    }
    void SecondToolConfirmationNotification(){
        MessageBoxPanel.SetActive(true);
        MakeAllTextInvisible();
        SecondToolConfirmationPracticeMsg.gameObject.SetActive(true);

    }
    void ThirdToolConfirmationNotification(){
        MessageBoxPanel.SetActive(true);
        MakeAllTextInvisible();
        ThirdToolConfirmtionPracticeMsg.gameObject.SetActive(true);

    }
    void SelectedFirstToolInsteadNotification(){
        MessageBoxPanel.SetActive(true);
        MakeAllTextInvisible();
        SelectBlackSquarePracticeMsg.gameObject.SetActive(true); 
    }
    void SelectSecondToolInsteadNotification(){
        MessageBoxPanel.SetActive(true);
        MakeAllTextInvisible();
        SelectWhiteCirclePracticeMsg.gameObject.SetActive(true);
        //SelectBlackSquarePracticeMsg.gameObject.SetActive(true); 
    }
     void SelectThirdToolInsteadNotification(){
        MessageBoxPanel.SetActive(true);
        MakeAllTextInvisible();
        SelectBlackCirclePracticeMsg.gameObject.SetActive(true);
        //SelectBlackSquarePracticeMsg.gameObject.SetActive(true); 
    }
    public void HideUserNotificationPanel(){
		MakeAllTextInvisible ();
        MessageBoxPanel.SetActive(false);
        if (completedcurrentphase == true){
            RetsetPhase();
            completedcurrentphase = false;
        }
		
	}
    void HighlightTile(int tileNum){
        for (int i = 0; (i < 68); i++){
            if(gridSpaces[i] == gridSpaces[tileNum]){
                gridSpaces[i].image.sprite = boardToolSprite[11];
                //gridSpaces[i].gameObject.tag = "EmptyGridSpace29";
             }
        }
    }

    public void DisableLegendToolSelectionButtons()
    {

        blackCircleLegendTile.button.enabled = false;
        whiteCircleLegendTile.button.enabled = false;
        blackSquareLegendTile.button.enabled = false;
        whiteSquareLegendTile.button.enabled = false;
        blackTriangleLegendTile.button.enabled = false;
        whiteTriangleLegendTile.button.enabled = false;
        
    }
    void EnableLegendToolSelectionButtons()
    {
        blackCircleLegendTile.button.enabled = true;
        whiteCircleLegendTile.button.enabled = true;
        blackSquareLegendTile.button.enabled = true;
        whiteSquareLegendTile.button.enabled = true;
        blackTriangleLegendTile.button.enabled = true;
        whiteTriangleLegendTile.button.enabled = true;
    }
    
    void SetGameControllerReferenceOnButtons()
    {
        for (int i = 0; i < gridSpaces.Length; i++)
        {

            gridSpaces[i].GetComponentInParent<GridSpacePractice>().SetGameControllerReference(this);

        }
    }
    void DisableAllButTargetButton(int space_num)
    {
        for (int i = 0; i < gridSpaces.Length; i++)
        {
            if (gridSpaces[i] != gridSpaces[space_num]){
                gridSpaces[i].interactable = false;
            }
        }
    }
    void ChangeTagOfTargetTileButton()
    {
        for (int i = 0; i < gridSpaces.Length; i++)
        {
            if (gridSpaces[i] == gridSpaces[target]){

                gridSpaces[i].tag = currenttargettile; 
                
            }
        }
    }
    public void EnableAllBoardButtons()
    {
        for (int i = 0; i < gridSpaces.Length; i++)
        { 
            gridSpaces[i].interactable = true;
        }
    }
    public Sprite GetToolSprite()
    {
        return toolSprite;
    }
    public int GetTargetTile()
    {
        return target;
    }
    //DISPLAY NOTIFCATIONS HERE
    public void DisplayNofication_PlaceBlackSquare(){
        MessageBoxPanel.gameObject.SetActive(true);
        MakeAllTextInvisible();
        BlackSquarePlacementPracticeMsg.gameObject.SetActive(true);
    }
    public void DisplayNofication_FirstToolPlacementConfirmation(){
        MessageBoxPanel.gameObject.SetActive(true);
        MakeAllTextInvisible();
        FirstToolConfirmationPracticeMsg.gameObject.SetActive(true);
        //BlackSquarePlacementPracticeMsg.gameObject.SetActive(true);
    }
    public void DisplayNofication_SecondToolPlacementConfirmation(){
        MessageBoxPanel.gameObject.SetActive(true);
        MakeAllTextInvisible();
        SecondToolConfirmationPracticeMsg.gameObject.SetActive(true);
    }
     public void DisplayNofication_ThirdToolPlacementConfirmation(){
        MessageBoxPanel.gameObject.SetActive(true);
        MakeAllTextInvisible();
        ThirdToolConfirmtionPracticeMsg.gameObject.SetActive(true);
    }

    // public void DisplayNotification_XGridSpace(){
	// 	MessageBoxPanel.SetActive (true);
    //     MakeAllTextInvisible();
	// 	XGridSpaceMsg.gameObject.SetActive (true);
	// }
	// public void DisplayNotification_CheckGridSpace(){
	// 	MessageBoxPanel.SetActive (true);
    //     MakeAllTextInvisible();
	// 	CheckGridSpaceMsg.gameObject.SetActive (true);
	// }
    void DisableAllThumbnails() {
        
        blackCircleLegendTile.thumbnail.enabled = false;
        whiteCircleLegendTile.thumbnail.enabled = false;
        blackSquareLegendTile.thumbnail.enabled = false;
        whiteSquareLegendTile.thumbnail.enabled = false;
        blackTriangleLegendTile.thumbnail.enabled = false;
        whiteTriangleLegendTile.thumbnail.enabled = false;
        removeTool.thumbnail.enabled = false;
    }
    void EnableAllThumbnails()
    {

        blackCircleLegendTile.thumbnail.enabled = true;
        whiteCircleLegendTile.thumbnail.enabled = true;
        blackSquareLegendTile.thumbnail.enabled = true;
        whiteSquareLegendTile.thumbnail.enabled = true;
        blackTriangleLegendTile.thumbnail.enabled = true;
        whiteTriangleLegendTile.thumbnail.enabled = true;
        removeTool.thumbnail.enabled = true;
    }
    public int GetSelection(){
        return selection;
    }
    public void DisplayNotification_FailedAttempt(){
		MessageBoxPanel.SetActive (true);
        MakeAllTextInvisible();
		FailedAttemptMsg.gameObject.SetActive (true);
		movementScript_bb1.keepMoving = false;
		movementScript_bb2.keepMoving = false;
		movementScript_wb1.keepMoving = false;
		movementScript_wb2.keepMoving = false;
	}
    public void DisplayNotification_SuccessfulAttempt(){
		MessageBoxPanel.SetActive (true);
        MakeAllTextInvisible();
		SuccessfulAttemptMsg.gameObject.SetActive (true);
	}
    public void DisplayNotification_PressStartBeforeAnotherToolSelection(){
        MessageBoxPanel.SetActive (true);
        MakeAllTextInvisible();
        ClickStartBeforeNextPlacementPracticeMsg.gameObject.SetActive(true);
    }
    public void DisplayNotification_PressStartBeforeAnotherToolPlacement(){
        MessageBoxPanel.SetActive (true);
        MakeAllTextInvisible();
        ClickStartPracticeMsg.gameObject.SetActive(true);
    }
    public void DisplayNotification_ResetButtonFunctionality(){
        MessageBoxPanel.SetActive (true);
        MakeAllTextInvisible();
        ResetButtonPracticeMsg.gameObject.SetActive(true);
    }
    public void DisplayNotification_RemoveButtonFunctionality(){
        MessageBoxPanel.SetActive (true);
        MakeAllTextInvisible();
        RemovalButtonPracticeMsg.gameObject.SetActive(true);
    }
     public void DisplayNotification_BlueHiglightNotification(){
        MessageBoxPanel.SetActive (true);
        MakeAllTextInvisible();
        SelectBlueBoxMsg.gameObject.SetActive(true);
    }
    public void DisplayNotification_ActionNeededToolPlacement(){
        MessageBoxPanel.SetActive (true);
        MakeAllTextInvisible();
        if (waitingforyoutoplacewhitecircletool == true){
            PleasePlaceWhiteCircleMsg.gameObject.SetActive(true);
            
            
        }
        else if (waitingforyoutoplaceblackcircletool == true){
            PleasePlaceBlackCircleMsg.gameObject.SetActive(true);
            
        }
        else if (waitingforyoutoplaceblacksquaretool == true){
            PleasePlaceBlackSquareMsg.gameObject.SetActive(true);
            //waitingforyoutoplaceblacksquarecircletool = false;
           

        }
    }
     public void CheckWinCondition(){
		winLevelCondition += 1;
        MakeAllTextInvisible();
		if (winLevelCondition == 4) {
            BeginExerciseBtn.gameObject.SetActive(true);
            ResetBtn.gameObject.SetActive (false);
            StartTrialBtn.gameObject.SetActive(false);
            DisplayNotification_SuccessfulAttempt();
            StartTrialBtn.interactable = false;
		}
	}
    public void MovePlayersToStartingPosition()
    {
        movementScript_bb1.rb.transform.position = initialPosition_BB1;
        movementScript_wb2.rb.transform.position = initialPosition_WB2;
        movementScript_wb1.rb.transform.position = initialPosition_WB1;
        movementScript_bb2.rb.transform.position = initialPosition_BB2;
    }
    public void BeginExercise(){
        SceneManager.LoadScene("ST_Exercise");
    }

    public void ResetWaitingBools(){
        waitingforyoutoplacewhitecircletool = false;
        waitingforyoutoplaceblackcircletool = false; 
        waitingforyoutoplaceblacksquaretool = false;
    }



}
