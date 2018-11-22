using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*var drinkName = UnityEngine.UI.Text;
var drinkIngred1 = "none";
var drinkIngred2 = "none";
var DrinkSize = 0;
var ingred1Shots = 0;
var ingred2Shots = 0;*/

public class generateOrder : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void generateNum(){
		string drink;
		string ingredient1;
		string ingredient2;
		string drinksize;
		string numShots;
		/*Random order chooser*/
		var num = Random.Range (1, 5);
		var size = Random.Range (0, 3);
		/*Orders to be generated*/
		string string1 = "Latte:Espresso:Steamed Milk";
		string string2 = "Cappuccino:Espresso:Steamed Milk";
		string string3 = "Americano:Hot Water:Espresso";
		string string4 = "Flat White:Risretto Shots:None";
		string latteShots = "1:2:2";
		string[] LatteShots = latteShots.Split (':');
		string cappuccinoShots = "1:2:2";
		string[] CappuccinoShots = cappuccinoShots.Split (':');
		string americanoShots = "2:3:3";
		string[] AmericanoShots = americanoShots.Split (':');
		string flatwhiteShots = "2:3:4";
		string[] FlatWhiteShots = flatwhiteShots.Split (':');
		/*Action to be taken per order*/
		switch (num) {
		case 1:
			string[] order1 = string1.Split (':'); //split order string at ':' delimiter
			drink = order1 [0];
			ingredient1 = order1 [1];
			ingredient2 = order1 [2];
			drinksize = determineSize (size);
			GameObject.Find ("firstText").GetComponent<Text> ().text = drink;//update ui chalkboard display
			GameObject.Find ("secondText").GetComponent<Text> ().text = ingredient1;
			GameObject.Find ("thirdText").GetComponent<Text> ().text = ingredient2;
			GameObject.Find ("fourthText").GetComponent<Text> ().text = drinksize;
			GameObject.Find ("fifthText").GetComponent<Text> ().text = LatteShots[size] + "Shot(s)";//select the correct num of shots based on size generated
			break;
		case 2:
			string[] order2 = string2.Split (':'); //split order string at ':' delimiter
			drink = order2[0];
			ingredient1 = order2 [1];
			ingredient2 = order2 [2];
			drinksize = determineSize (size);
			GameObject.Find ("firstText").GetComponent<Text> ().text = drink;  //update ui chalkboard display
			GameObject.Find ("secondText").GetComponent<Text> ().text = ingredient1;
			GameObject.Find ("thirdText").GetComponent<Text> ().text = ingredient2;
			GameObject.Find ("fourthText").GetComponent<Text> ().text = drinksize;
			GameObject.Find ("fifthText").GetComponent<Text> ().text = CappuccinoShots[size] + "Shot(s)";//select the correct num of shots based on size generated
			break;
		case 3:
			string[] order3 = string3.Split (':'); //split order string at ':' delimiter
			drink = order3[0];
			ingredient1 = order3 [1];
			ingredient2 = order3 [2];
			drinksize = determineSize (size);
			GameObject.Find ("firstText").GetComponent<Text> ().text = drink;//update ui chalkboard display
			GameObject.Find ("secondText").GetComponent<Text> ().text = ingredient1;
			GameObject.Find ("thirdText").GetComponent<Text> ().text = ingredient2;
			GameObject.Find ("fourthText").GetComponent<Text> ().text = drinksize;
			GameObject.Find ("fifthText").GetComponent<Text> ().text = AmericanoShots[size] + "Shot(s)";//select the correct num of shots based on size generated
			break;
		case 4:
			string[] order4 = string4.Split (':'); //split order string at ':' delimiter
			drink = order4[0];
			ingredient1 = order4 [1];
			ingredient2 = order4 [2];
			drinksize = determineSize (size);
			GameObject.Find ("firstText").GetComponent<Text> ().text = drink;//update ui chalkboard display **text objects MUST be named first, second, etc to work properly
			GameObject.Find ("secondText").GetComponent<Text> ().text = ingredient1;
			GameObject.Find ("thirdText").GetComponent<Text> ().text = ingredient2;
			GameObject.Find ("fourthText").GetComponent<Text> ().text = drinksize;
			GameObject.Find ("fifthText").GetComponent<Text> ().text = FlatWhiteShots[size] + "Shot(s)"; //select the correct num of shots based on size generated
			break;
		default:
			break;
		
		}
	}
	public string determineSize(int size){
		string drinksize;
	switch (size) {
	case 0:
		drinksize = "Small";
		return drinksize;
	case 1:
		drinksize = "Medium";
		return drinksize;
	case 2:
		drinksize = "Large";
		return drinksize;
	default:
		return null;
	}
	}
}
