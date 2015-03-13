﻿#pragma strict


 var startPosition : Vector3;
 startPosition =  GameObject.FindGameObjectWithTag("Worm").transform.position;    //The starting position in world space
 var endPosition : Vector3 = Vector3(0,0,-25);    //The ending position in world space
 var bending : Vector3 = Vector3.up;                //Bend factor (on all axes)
 var timeToTravel : float = 5.0;                //The total time it takes to move from start- to end position
 
 function Update () {
     MoveToPosition();
 }
 
 function MoveToPosition () {
     var timeStamp : float = Time.time;
     while (Time.time<timeStamp+timeToTravel) {
         var currentPos : Vector3 = Vector3.Lerp(startPosition, endPosition, (Time.time - timeStamp)/timeToTravel);
         
         currentPos.x += Mathf.Sin(transform.position.z);
         currentPos.y += bending.y*Mathf.Sin(Mathf.Clamp01((Time.time - timeStamp)/timeToTravel) * Mathf.PI);
         currentPos.z += bending.z*Mathf.Sin(Mathf.Clamp01((Time.time - timeStamp)/timeToTravel) * Mathf.PI);
         
         transform.position = currentPos;
         
         yield;
     }
     
 }