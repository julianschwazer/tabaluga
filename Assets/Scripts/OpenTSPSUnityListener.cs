/**
 * OpenTSPS + Unity3d Extension
 * Created by James George on 11/24/2010
 * 
 * This example is distributed under The MIT License
 *
 * Copyright (c) 2010 James George
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */


using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TSPS;
using System;

public class OpenTspsUnityListener : MonoBehaviour, OpenTSPSListener  {
	
	public int port = 12000; // set this from the UI to change the port
	
	private OpenTSPSReceiver _receiver;
	
	// a place to hold game objects that we attach to people, maps person ID => their object
	private Dictionary<int,GameObject> _peopleCubes = new Dictionary<int,GameObject>();
	
	// game engine stuff for the example
	public GameObject floor; // put the people on this plane
	public GameObject peopleIndicator; // used to represent people moving about in our example
	
	void Start() {
		_receiver = new OpenTSPSReceiver( port );
		_receiver.addPersonListener( this );
		
		// Security.PrefetchSocketPolicy("localhost",8843);
		_receiver.connect();
		Debug.Log("created receiver on port " + port);
	}
			
	void Update () {
		// call this to receiver messages
		_receiver.update();
	}

	void OnGUI() {
		if( _receiver.isConnected() ) {
			GUI.Label( new Rect( 10, 10, 500, 100), "Connected to TSPS on Port " + port );
		}
	}
	
	public void personEntered(OpenTSPSPerson person){
		Debug.Log("person entered with ID " + person.id);
		GameObject personObject = (GameObject)Instantiate(peopleIndicator, positionForPerson(person), Quaternion.identity);
		_peopleCubes[person.id] = personObject;
	}

	public void personUpdated(OpenTSPSPerson person) {
		personMoved(person);
	}

	public void personMoved(OpenTSPSPerson person){
		Debug.Log("Person updated with ID " + person.id);
		if(_peopleCubes.ContainsKey(person.id)){
			GameObject cubeToMove = _peopleCubes[person.id];
			cubeToMove.transform.position = positionForPerson(person);
			// cubeToMove.transform.position = Vector3.Lerp(transform.position, positionForPerson(person), Time.deltaTime * 0.1);
		}
	}

	public void personWillLeave(OpenTSPSPerson person){
		Debug.Log("Person leaving with ID " + person.id);
		if(_peopleCubes.ContainsKey(person.id)){
			GameObject cubeToRemove = _peopleCubes[person.id];
			_peopleCubes.Remove(person.id);
			// delete it from the scene	
			Destroy(cubeToRemove);
		}
	}
	
	// maps the OpenTSPS coordinate system into one that matches the size of the bodenfl�che
	private Vector3 positionForPerson(OpenTSPSPerson person){
		Bounds meshBounds = floor.GetComponent<Renderer>().bounds;
		return new Vector3( (float)(.5 - person.centroidX) * meshBounds.size.x, 0.25f, (float)(person.centroidY - .5) * meshBounds.size.z );
	}
}
