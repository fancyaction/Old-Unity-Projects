#pragma strict

class monster {

	var name : String;
	var image : Texture2D;
	var type : Type;
	var baseHp : float;
	var curHp : float;
	var baseAtk : float;
	var curAtk : float;
	var baseDef : float;
	var curDef : float;
	var speed : float;
	var rarity : Rarity;
	var regionLocated : String;
	var attacks : Attack[];
	
}


enum Type {

grass,
psychic,
water,
fire,
electric,
metal



}

enum Rarity {

//rolling rare number picks rare monster
common,
rare
}