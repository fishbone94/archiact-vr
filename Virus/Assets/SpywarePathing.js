﻿ var upDown : float;
 var speed : int = 2;
 var hightDiv : int = 150;
 var t : float; 
 var prefab : GameObject;
 var startPosition : Vector3;
 var endPosition :  Vector3;    //The ending position in world space
 var bending : Vector3 = Vector3.up;                //Bend factor (on all axes)
 var timeToTravel : float = 10.0;                //The total time it takes to move from start- to end position
 var y : float = 10.0;

   
 function Start(){
 FindPosition();
 MoveToPosition();
 }

 function FindPosition(){
 startPosition =  prefab.transform.position;
 endPosition = Vector3(Random.Range(-25.0, 25.0), 10, Random.Range(-10.0, -15.0)); 
 }

 function MoveToPosition () {
     var timeStamp : float = Time.time;
     while (Time.time<timeStamp+timeToTravel) {
         var currentPos : Vector3 = Vector3.Lerp(startPosition, endPosition, (Time.time - timeStamp)/timeToTravel);
         
         currentPos.x += bending.x*Mathf.Sin(Mathf.Clamp01((Time.time - timeStamp)/timeToTravel) * Mathf.PI);
         currentPos.y += bending.y*Mathf.Sin(Mathf.Clamp01((Time.time - timeStamp)/timeToTravel) * Mathf.PI);
         currentPos.z += bending.z*Mathf.Sin(Mathf.Clamp01((Time.time - timeStamp)/timeToTravel) * Mathf.PI);
         
         transform.position = currentPos;
         
         yield;
     }
 }

 function Update () {
transform.Translate(Vector3.up * upDown); 
t += speed*(Time.deltaTime); 
upDown = (Mathf.Sin(t))/hightDiv;

}
