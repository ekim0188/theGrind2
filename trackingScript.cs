using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class trackingScript : MonoBehaviour {
	private float update; //
	string drinkToMake;
	string ingred1;
	string ingred2;
	string size;
	int sizeInt;
	int numShots;
	float largecupXstart, largecupYstart, mediumcupXstart, mediumcupYstart, smallcupXstart, smallcupYstart, metalPitcherXstart, metalPitcherYstart;
	string smallcupIngred1, smallcupIngred2, smallcupIngred3, smallcupIngred4, mediumcupIngred1, mediumcupIngred2, mediumcupIngred3, mediumcupIngred4, largecupIngred1, largecupIngred2, largecupIngred3, largecupIngred4;
	// Use this for initialization
	void Start () {
		drinkToMake = null;  //string
		ingred1 = null;      //string
		ingred2 = null;      //string
		size = null;         //string
		numShots = 0;        //int
		update = 0.0f;
		InvokeRepeating ("checkIn", 10.0f, 10.0f); //call checkIn every 10s to determine the order 'currently' on the chalkboard
		GameObject largeCup = GameObject.FindGameObjectWithTag("largeCup");
		largecupXstart = largeCup.transform.position.x;
		largecupYstart = largeCup.transform.position.y;
		largecupIngred1 = null;
		largecupIngred2 = null;
		largecupIngred3 = null;
		largecupIngred4 = null;
		GameObject mediumCup = GameObject.FindGameObjectWithTag("mediumCup");
		mediumcupXstart = mediumCup.transform.position.x;
		mediumcupYstart = mediumCup.transform.position.y;
		mediumcupIngred1 = null;
		mediumcupIngred2 = null;
		mediumcupIngred3 = null;
		mediumcupIngred4 = null;
		GameObject smallCup = GameObject.FindGameObjectWithTag("smallCup");
		smallcupXstart = smallCup.transform.position.x;
		smallcupYstart = smallCup.transform.position.y;
		smallcupIngred1 = null;
		smallcupIngred2 = null;
		smallcupIngred3 = null;
		smallcupIngred4 = null;
		GameObject metalPitcher = GameObject.FindGameObjectWithTag("metalPitcher");
		metalPitcherXstart = metalPitcher.transform.position.x;
		metalPitcherYstart = metalPitcher.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
	}
		
public void checkIn(){ //read the generated order from the chalkboard to determine what the player should be currently doing
	drinkToMake = GameObject.Find ("firstText").GetComponent<Text> ().text;
	ingred1 = GameObject.Find ("secondText").GetComponent<Text> ().text;
	ingred2 = GameObject.Find ("thirdText").GetComponent<Text> ().text;
	size = GameObject.Find ("fourthText").GetComponent<Text> ().text;
	print ("largecupXstart is " + largecupXstart + ", largecupYstart is " + largecupYstart);
	print ("mediumcupXstart is " + mediumcupXstart + ", mediumcupYstart is " + mediumcupYstart);
	print ("smallcupXstart is " + smallcupXstart + ", smallcupYstart is " + smallcupYstart);
	print ("metalPitcherXstart is " + metalPitcherXstart + ", metalPitcherYstart is " + metalPitcherYstart);
		if (ingred2 == "None") {
			GameObject.Find ("thirdText").GetComponent<Text> ().text = "Done!";
		}
	try{
		string test = GameObject.Find ("fifthText").GetComponent<Text> ().text[0].ToString();
	    int fixedtest = int.Parse(test);
	    numShots = fixedtest;
		}
	catch(FormatException e){
		var estr = e.ToString();
		print ("FormatException Error: " + estr + ". Correct this by pressing get order. ");
		}

		//track where the large cup is
		GameObject largeCup = GameObject.FindGameObjectWithTag("largeCup");
		float largecupX = largeCup.transform.position.x;
		float largecupY = largeCup.transform.position.y;
		print("largecupx is now " + largecupX);
		print ("largecupy is now " + largecupY);

		//track where the medium cup is
		GameObject mediumCup = GameObject.FindGameObjectWithTag("mediumCup");
		float mediumcupX = mediumCup.transform.position.x;
		float mediumcupY = mediumCup.transform.position.y;
		print("mediumcupx is now " + mediumcupX);
		print ("mediumcupy is now " + mediumcupY);

		//track where the small cup is
		GameObject smallCup = GameObject.FindGameObjectWithTag("smallCup");
		float smallcupX = smallCup.transform.position.x;
		float smallcupY = smallCup.transform.position.y;
		print("smallcupx is now " + smallcupX);
		print ("smallcupy is now " + smallcupY);

		//track if pitcher is snapped to machine
		GameObject metalPitcher = GameObject.FindGameObjectWithTag("metalPitcher");
		float metalpitcherX = metalPitcher.transform.position.x;
		float metalpitcherY = metalPitcher.transform.position.y;
		print("metalpitcherx is now " + metalpitcherX);
		print ("metalpitchery is now " + metalpitcherY);


		//track flags of DecafSingleButton, DecafDoubleButton, 1/2DecafDoubleButton, 1/2QuadButton, StopButton, RinseButton, LongButton, RisrettoButton, SingleButton, DoubleButton, TripleButton, QuadButton
		int decafsinglebuttonFlag = GameObject.Find("DecafSingleButton") .GetComponent<CustomButton>().flag;
		int decafdoublebuttonFlag = GameObject.Find ("DecafDoubleButton").GetComponent<CustomButton>().flag;
		int halfdecafdoublebuttonFlag = GameObject.Find ("1/2DecafDoubleButton").GetComponent<CustomButton>().flag;
		int halfquadbuttonFlag = GameObject.Find("1/2QuadButton").GetComponent<CustomButton>().flag;
		int stopbuttonFlag = GameObject.Find("StopButton").GetComponent<CustomButton>().flag;
		int rinsebuttonFlag = GameObject.Find ("RinseButton").GetComponent<CustomButton>().flag;
		int risrettobuttonFlag = GameObject.Find ("RisrettoButton").GetComponent<CustomButton>().flag;
		int longbuttonFlag = GameObject.Find ("LongButton").GetComponent<CustomButton>().flag;
		int singlebuttonFlag = GameObject.Find ("SingleButton").GetComponent<CustomButton>().flag;
		int doublebuttonFlag = GameObject.Find ("DoubleButton").GetComponent<CustomButton>().flag;
		int triplebuttonFlag = GameObject.Find ("TripleButton").GetComponent<CustomButton>().flag;
		int quadbuttonFlag = GameObject.Find ("QuadButton").GetComponent<CustomButton>().flag;

		//GameObject decafsinglebutton = GameObject.FindGameObjectWithTag("DecafSingleButton");
		//print("decafsinglebuttonFlag is " + decafsinglebuttonFlag);    
	
		//take these out at some point
		print(drinkToMake);
		print (ingred1);
		print (ingred2);
		print (size);
		print (numShots);
	
		/*check if pitcher is docked to espressoMachine*/
		if (metalpitcherX == 2.75) {
		updateProgressBar (5);
			//metalPitcher.transform.position.x = 6; //doesn't take pitcher off snapPoint like i thought
		}

		/*check drink size and whether corresponding cup is still on the shelf
		if cupSize == drinkSize still on the shelf, the progress points aren't updated*/
		if (size == "Small") {
			sizeInt = 0;
			if ((smallcupX != smallcupXstart) && (smallcupY != smallcupYstart)) {
				updateProgressBar (5);
				GameObject.Find ("fourthText").GetComponent<Text> ().text = "Done!";
			}
		}
		if (size == "Medium") {
			sizeInt = 1;
			if ((mediumcupX != mediumcupXstart) && (mediumcupY != mediumcupYstart)) {
				updateProgressBar (5);
				GameObject.Find ("fourthText").GetComponent<Text> ().text = "Done!";
			}
		}
		if (size == "Large") {
			sizeInt = 2;
			if ((largecupX != largecupXstart) && (largecupY != largecupYstart)) {
				updateProgressBar (5);
				GameObject.Find ("fourthText").GetComponent<Text> ().text = "Done!";
			}  
		}

		/*check the ingredients in the cup, if the 4(may need more) ingred slots in the cup have the right ingred in the right amount, add to total score*/
		//GameObject.Find ("SingleButton").GetComponent<CustomButton>().flag
		print (size);
		print ("sizeInt is " + sizeInt);
		/*check the flags of the buttons, if the correct ones have been pressed, add to the total score*/
		if (drinkToMake == "Latte"){//Espresso:Steamed Milk
			switch (sizeInt) {
			case 0://small latte 1 shot
				if (singlebuttonFlag == 1) {
					updateProgressBar (5);
					GameObject.Find ("SingleButton").GetComponent<CustomButton>().flag = 0;
					GameObject.Find ("fifthText").GetComponent<Text> ().text = "Done!";
				}
				break;
			case 1://2 shot
				if (doublebuttonFlag == 1) {
					updateProgressBar (5);
					GameObject.Find ("DoubleButton").GetComponent<CustomButton>().flag = 0;
					GameObject.Find ("fifthText").GetComponent<Text> ().text = "Done!";
				}
				break;
			case 2://2 shot
				if (doublebuttonFlag == 1) {
					updateProgressBar (5);
					GameObject.Find ("DoubleButton").GetComponent<CustomButton>().flag = 0;
					GameObject.Find ("fifthText").GetComponent<Text> ().text = "Done!";
				}
				break;
			default:
				break;

			}
		}
		if (drinkToMake == "Cappuccino") {//Espresso:Steamed Milk
			switch (sizeInt) {
			case 0://small Cappuccino 1
				if (singlebuttonFlag == 1) {
					updateProgressBar (5);
					GameObject.Find ("SingleButton").GetComponent<CustomButton>().flag = 0;
					GameObject.Find ("fifthText").GetComponent<Text> ().text = "Done!";
				}
				break;
			case 1://2
				if (doublebuttonFlag == 1) {
					updateProgressBar (5);
					GameObject.Find ("DoubleButton").GetComponent<CustomButton>().flag = 0;
					GameObject.Find ("fifthText").GetComponent<Text> ().text = "Done!";
				}
				break;
			case 2://2
				if (doublebuttonFlag == 1) {
					updateProgressBar (5);
					GameObject.Find ("DoubleButton").GetComponent<CustomButton>().flag = 0;
					GameObject.Find ("fifthText").GetComponent<Text> ().text = "Done!";
				}
				break;
			default:
				break;

			}	
		}
		if (drinkToMake == "Americano") {//Hot Water:Espresso
			switch (sizeInt) {
			case 0://smallAmericano 2
				if (doublebuttonFlag == 1) {
					updateProgressBar (5);
					GameObject.Find ("DoubleButton").GetComponent<CustomButton>().flag = 0;
					GameObject.Find ("fifthText").GetComponent<Text> ().text = "Done!";
				}
				break;
			case 1://3
				if (triplebuttonFlag == 1) {
					updateProgressBar (5);
					GameObject.Find ("TripleButton").GetComponent<CustomButton>().flag = 0;
					GameObject.Find ("fifthText").GetComponent<Text> ().text = "Done!";

				}
				break;
			case 2://3
				if (triplebuttonFlag == 1) {
					updateProgressBar (5);
					GameObject.Find ("TripleButton").GetComponent<CustomButton>().flag = 0;
					GameObject.Find ("fifthText").GetComponent<Text> ().text = "Done!";
				}
				break;
			default:
				break;

			}
		}
		if (drinkToMake == "Flat White") {//Risretto Shots:None
			switch (sizeInt) {
			case 0://smallFlat White 2
				if (doublebuttonFlag == 1) {
					updateProgressBar (5);
					GameObject.Find ("DoubleButton").GetComponent<CustomButton>().flag = 0;
					GameObject.Find ("fifthText").GetComponent<Text> ().text = "Done!";

				}
				break;
			case 1://3
				if (triplebuttonFlag == 1) {
					updateProgressBar (5);
					GameObject.Find ("TripleButton").GetComponent<CustomButton>().flag = 0;
					GameObject.Find ("fifthText").GetComponent<Text> ().text = "Done!";
				}
				break;
			case 2://4
				if (quadbuttonFlag == 1) {
					updateProgressBar (5);
					GameObject.Find ("QuadButton").GetComponent<CustomButton>().flag = 0;
					GameObject.Find ("fifthText").GetComponent<Text> ().text = "Done!";
				}
				break;
			default:
				break;

			}
		}
		checkIngredients (sizeInt);
	}

	public void updateProgressBar(int total){    //currently increments progress by 5 each time the get update is called
		int display = int.Parse (GameObject.Find ("progressText").GetComponent<Text> ().text);
		GameObject.Find ("progressText").GetComponent<Text> ().text = (display + total).ToString ();
	}

	public void checkIngredients(int drinkSizeInt){
		
		switch (drinkSizeInt) {
		case 0:
			UnityEngine.BoxCollider2D smallCupCollider = GameObject.Find ("smallCup").GetComponent<BoxCollider2D> ();
			UnityEngine.BoxCollider2D espressoCube1 = GameObject.Find ("espressoCube1").GetComponent<BoxCollider2D> ();
			UnityEngine.BoxCollider2D espressoCube2 = GameObject.Find ("espressoCube2").GetComponent<BoxCollider2D> ();
			UnityEngine.BoxCollider2D milkCube = GameObject.Find ("milkCube").GetComponent<BoxCollider2D> ();
			break;
		case 1:
			UnityEngine.BoxCollider2D mediumCupCollider = GameObject.Find ("mediumCup").GetComponent<BoxCollider2D> ();
			break;

		case 2:
			UnityEngine.BoxCollider2D largeCupCollider = GameObject.Find ("largeCup").GetComponent<BoxCollider2D> ();
			break;
		default:
			break;	  
		}
	}

	public void checkTotalScore(){

	}
}


/* collidera.distance(colliderb).isoverlapped */
/*Tracking a script flag
/*ScriptThatYouWant = GameObject.Find("[GameObjectName to which target script is attached]").GetComponent<[Name of target script]>();*/