using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerclass : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//PlayerPrefs.SetInt ("prabu",7);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}void OnCollisionEnter2D(Collision2D col)
	{
		if(col.collider.tag=="target")
		{
			mainuicanvas.maincan.targethit=true;
		}
	}
}
