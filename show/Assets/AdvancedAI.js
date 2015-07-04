var Distance;
var Target : Transform;
var lookAtDistance = 25.0;
var chaseRange = 15.0;
var attackRange = 1.5;
var moveSpeed = 5.0;
var Damping = 6.0;
var attackRepeatTime = 1;

var TheDammage = 40;

private var attackTime : float;

var controller : CharacterController;
var gravity : float = 20.0;
private var MoveDirection : Vector3 = Vector3.zero;

function Start ()
{
	attackTime = Time.time;
}

function Update ()
{
	Distance = Vector3.Distance(Target.position, transform.position);
	
	if (Distance < lookAtDistance)
	{
		lookAt();
	}
	
	if (Distance > lookAtDistance)
	{
		GetComponent.<Renderer>().material.color = Color.green;
	}
	
	
	else if (Distance < chaseRange)
	{
		chase ();
	}
}

// Beobachtung!
function lookAt ()
{
	GetComponent.<Renderer>().material.color = Color.yellow; // gelbes Einfärben
	var rotation = Quaternion.LookRotation(Target.position - transform.position); // Ermittlung der Rotation zum Spieler
	transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * Damping); // Rotation!
}

// Verfolgung!
function chase ()
{
	GetComponent.<Renderer>().material.color = Color.red; //rotes Einfärben
	
	moveDirection = transform.forward; // Ermittelter Vektor zum Verfolgen des Spielers
	moveDirection *= moveSpeed; // Vergrößern der Vektorlänge für höhren Speed
	
	// Ausführen der Bewegung mittels ermitteltem Vektor!
	controller.Move(moveDirection * Time.deltaTime);
}
