var Bullet : Rigidbody;
var Spawn : Transform;
var BulletSpeed: float = 1000;

function Start () {

}

function Update () {
	if(Input.GetButtonDown("Fire1")){
	Fire();
	
	}
	}
	
	function Fire(){
	var bullet1 : Rigidbody = Instantiate(Bullet,Spawn.position,Spawn.rotation);
	bullet1.AddForce(transform.forward * BulletSpeed);
	}
	