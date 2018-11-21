using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
		/*Random order chooser*/
		var num = Random.Range (1, 5);
		print ("num is " + num);
		var size = Random.Range (0, 3);
		print ("size is " + size);
		/*Orders to be generated*/
		string string1 = "Latte:espresso:steamed milk:very little foam";
		string string2 = "Cappuccino:espresso:steamed milk:mostly foam";
		string string3 = "Americano:hot water:espresso";
		string string4 = "Flat White:risretto shots";
		string latteSize = "1:2:2";
		string cappuccinoSize = "1:2:2";
		string americanoSize = "2:3:3";
		string flatwhiteSize = "2:3:4";
		/*Action to be taken per order*/
		switch (num) {
		case 1:
			print (string1);
			string[] order1 = string1.Split (':'); //split order string at ':' delimiter
			drink = order1 [0];
			print ("drink is " + drink);
			break;
		case 2:
			print (string2);
			string[] order2 = string2.Split (':'); //split order string at ':' delimiter
			drink = order2[0];
			print ("drink is " + drink);
			break;
		case 3:
			print (string3);
			string[] order3 = string3.Split (':'); //split order string at ':' delimiter
			drink = order3[0];
			print ("drink is " + drink);
			break;
		case 4:
			print (string4);
			string[] order4 = string4.Split (':'); //split order string at ':' delimiter
			drink = order4[0];
			print ("drink is " + drink);
			break;
		default:
			break;
		
		}
	}
}
