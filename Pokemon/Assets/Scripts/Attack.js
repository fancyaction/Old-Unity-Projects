#pragma strict

class Attack {

	var name : Move;
	var damage : float;
	var type : AttackType;
}

enum AttackType {

grass,
psychic,
water,
fire,
electric,
metal

}

enum Move {

vine,
tackle,
smash,
shock,
charge

}