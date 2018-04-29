#pragma strict

//NPC dialog
var talkMessage : String[];

//what text to display from talkMessage
var displayText : String;

var showText : boolean;

function OnGUI () {
	if(showText) {
		GUI.Label (Rect (Screen.width/2, Screen.height/2, 500, 20), "" + displayText);
	}
}

function Start () {

}

function Update () {

}


function talk () {
	var other : PlayerStats;
	other = gameObject.Find("Player").GetComponent(PlayerStats);
	
	other.disableMovement = true;
	
	showText = true;
	//for loop (space bar = next in array) self typing text)
	for(var i=0;i < talkMessage.Length;i++) {
		displayText = talkMessage[i];
		yield WaitForSeconds(3);
	}
		showText = false;
		other.disableMovement = false;
}
	