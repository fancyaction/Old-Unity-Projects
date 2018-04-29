#pragma strict

//Moving Stats
var startPoint : Vector3;
var endPoint : Vector3;
var speed : float;
private var increment:float;
var isMoving : boolean;
var disableMovement : boolean;

//Walking Stats
var walkCounter : int;
var walkCounter2 : int;
var isInCombat : boolean;
var directionFacing : String;

//cameras
var CameraMain : GameObject;
var CombatCamera : GameObject;

//Teleport Locations
var teleportLoc : GameObject[];

//Regions
var region : String;

//Call functions in Main script
var MainScript : Main;

function Start () {

	startPoint = transform.position;
	endPoint = transform.position;

	walkCounter2 = Random.Range(5,15);
	
	region = "region1";
}

function Update () {

	if(Input.GetKeyDown("space") && !disableMovement) {
	
		talkToNpc();
	}

	var Sprite = gameObject.GetComponent(AnimatedSprite);
	
	if(increment <=1 && isMoving == true){
		increment += speed/100;
	}
	else {
		isMoving = false;
	}
	
	if(isMoving) {
	transform.position = Vector3.Lerp(startPoint,endPoint,increment);
	}
	else {
		Sprite.totalCells = 1;
	}
	
	if (!isInCombat && !disableMovement) {
		if(Input.GetKey("w") && isMoving == false) { 		//1
			Sprite.rowNumber = 3;
			Sprite.totalCells = 1;
			directionFacing = "north";
				
			var disableMove : boolean;
			var hit : RaycastHit;
			if (Physics.Raycast (transform.position, Vector3.forward, hit, 1.0)) {
				var distanceToGround = hit.distance;
				//Debug.Log("HIT");
				
				if(hit.collider.gameObject.tag == "collision" || "npc") {
					disableMove = true;
					//Debug.Log("TREE");
				}
			}
	
			if (!disableMove) {
				Sprite.rowNumber = 3;
				Sprite.totalCells = 4;
				calculateWalk ();
				increment = 0;
				isMoving = true;
				startPoint = transform.position;
				endPoint = new Vector3(transform.position.x,transform.position.y,transform.position.z + 1);
			}
			disableMove = false;
		}
		else if(Input.GetKey("s") && isMoving == false) {		//2
			Sprite.rowNumber = 4;
			Sprite.totalCells = 1;
			directionFacing = "south";
				
			var disableMove2 : boolean;
			var hit2 : RaycastHit;
			if (Physics.Raycast (transform.position, -Vector3.forward, hit2, 1.0)) {
				var distanceToGround2 = hit2.distance;
				//Debug.Log("HIT");
				
				if(hit2.collider.gameObject.tag == "collision" || "npc") {
					disableMove2 = true;
				//	Debug.Log("TREE");
				}
			}
			
			if (!disableMove2) {
				Sprite.rowNumber = 4;
				Sprite.totalCells = 4;
				calculateWalk ();
				increment = 0;
				isMoving = true;
				startPoint = transform.position;
				endPoint = new Vector3(transform.position.x,transform.position.y,transform.position.z - 1);
			}
			disableMove2 = false;
		}
			
		else if(Input.GetKey("a") && isMoving == false) {		//3
			
			var disableMove3 : boolean;
			var hit3 : RaycastHit;
			if (Physics.Raycast (transform.position, Vector3.left, hit3, 1.0)) {
				var distanceToGround3 = hit3.distance;
				//Debug.Log("HIT");
				
				if(hit3.collider.gameObject.tag == "collision" || "npc") {
					disableMove3 = true;
				//	Debug.Log("TREE");
				}
			}
			
			if (!disableMove3) {
				Sprite.rowNumber = 1;
				Sprite.totalCells = 4;
				calculateWalk ();
				increment = 0;
				isMoving = true;
				startPoint = transform.position;
				endPoint = new Vector3(transform.position.x - 1,transform.position.y,transform.position.z);
			}
			disableMove3 = false;
		}
		else if(Input.GetKey("d") && isMoving == false) {		//4
			
			var disableMove4 : boolean;
			var hit4 : RaycastHit;
			if (Physics.Raycast (transform.position, Vector3.right, hit4, 1.0)) {
				var distanceToGround4 = hit4.distance;
				//Debug.Log("HIT");
				
				if(hit4.collider.gameObject.tag == "collision" || "npc") {
					disableMove4 = true;
				//	Debug.Log("TREE");
				}
			}
			
			if (!disableMove4) {
				Sprite.rowNumber = 2;
				Sprite.totalCells = 4;
				calculateWalk ();
				increment = 0;
				isMoving = true;
				startPoint = transform.position;
				endPoint = new Vector3(transform.position.x + 1,transform.position.y,transform.position.z);
			}
			disableMove4 = false;
		}
	}
}

function talkToNpc () {
	if (directionFacing == "north") {
		var hit : RaycastHit;
		if (Physics.Raycast (transform.position, Vector3.forward, hit, 1.0)) {
			var distanceToGround = hit.distance;
			Debug.Log("HIT!"); 
			
			if(hit.collider.gameObject.tag == "npc") {
				hit.collider.SendMessage("talk");
			}
		}
	}
}

function calculateWalk () {
	yield WaitForSeconds(0.3);
	
	var hit : RaycastHit;
		if (Physics.Raycast (transform.position, -Vector3.up, hit, 100.0)) {
			var distanceToGround = hit.distance;
			//Debug.Log("HIT");
			if(hit.collider.gameObject.tag == "tallGrass") {
				walkCounter++;
			//	Debug.Log("TALL GRASS");
		}
	}
		
	if(walkCounter >= walkCounter2) {
		walkCounter2 = Random.Range(5,15);
		walkCounter = 0;
		enterCombat ();
	}
}

function enterCombat () {
	MainScript.randomizeMonster();
	CameraMain.active = false;
	CombatCamera.active = true;
	isInCombat = true;
	Debug.Log("You have entered COMBAT!");
}

function OnTriggerEnter(col : Collider) {
	if(col.gameObject.tag == "caveEntrance1") {
		region = "region3";
		Debug.Log("Region" + region);
		this.transform.position = teleportLoc[0].transform.position;
		this.transform.position.y += 1;
	}
	if(col.gameObject.tag == "caveExit1") {
		region = "region1";
		Debug.Log("Region" + region);
		this.transform.position = teleportLoc[1].transform.position;
		this.transform.position.y += 1;
	}
	if(col.gameObject.tag == "region1"){
		region = "region1";
		Debug.Log("Region" + region);
	}
	if(col.gameObject.tag == "region2"){
		region = "region2";
		Debug.Log("Region" + region);
	}

}












