#pragma strict
import System.Collections.Generic;

//ALL monsters
var AllMonsters : monster[];

//Encountered monster
var enemyMonster : monster;

//equipped monster (fighting)
var monsterEquipped : monster;

function Start () {

//create a clone of a monster from AllMonsters to our monsterEquipped
copyMonster();

//add equipped monster
//monsterEquipped = AllMonsters[0];
}

function OnGUI() {
	var other : PlayerStats;
	other = gameObject.Find("Player").GetComponent(PlayerStats);
	
	if(other.isInCombat) {
		//Display monster during battle
		GUI.Label (Rect (50, 100, 200, 100), "" + enemyMonster.name);
		GUI.Label (Rect (50, 110, 200, 100), "" + enemyMonster.baseHp + "/ " + enemyMonster.curHp);
		GUI.DrawTexture(Rect(90, 150, 128,128), enemyMonster.image);
		
		for(var i=0;i<4;i++) {
			
			if (GUI.Button(Rect(150,100 + (i * 50),100,30),"" + monsterEquipped.attacks[i].name)) {
				Debug.Log("USED " + monsterEquipped.attacks[i].name + " ATTACK");
			}
		}
	}
}

function Update () {

}

function randomizeMonster () {

	var other : PlayerStats;
	other = gameObject.Find("Player").GetComponent(PlayerStats);
	
	var tempMonsters : List.<monster> = new List.<monster>();
	var randomNum : int = Random.Range(0,100);
	
	//Summons a rare monster, otherwise common
	if(randomNum == 20) {
		for(var i=0;i<AllMonsters.Length;i++) {
			if(AllMonsters[i].rarity == Rarity.rare && AllMonsters[i].regionLocated == other.region) {
			//Add each monster to a Temp List
			tempMonsters.Add(AllMonsters[i]);
			}
		
		}
	}
	else {
		for(var j=0;j<AllMonsters.Length;j++) {
			if(AllMonsters[j].rarity == Rarity.common && AllMonsters[j].regionLocated == other.region) {
				//Add each monster to a Temp List
				tempMonsters.Add(AllMonsters[j]);
			}
		}
	}
	
	var newRandom = Random.Range (0,tempMonsters.Count);
	enemyMonster = tempMonsters[newRandom];
}

function copyMonster () {
	
	var equipMonster = new monster();
	equipMonster = AllMonsters[0];
	monsterEquipped.name = equipMonster.name;
	monsterEquipped.curHp = equipMonster.curHp;
	monsterEquipped.baseAtk = equipMonster.baseAtk;
}
