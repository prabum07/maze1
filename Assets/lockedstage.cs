using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lockedstage : MonoBehaviour {


	public Button watchad;
	public Button play;
	public Button backbtn;
	public GameObject menu;
	// Use this for initialization
	void Start () {
		watchad.onClick.AddListener (() => watchadfunc ());
		backbtn.onClick.AddListener (() => backfunc ());
		play.onClick.AddListener (() => playfunc ());

		
	}
	public void watchadfunc()
	{		mainuicanvas.maincan.click.Play ();
		
		if (mainuicanvas.maincan.adscript.rewardbasedvideofunc ()) {
			//mainuicanvas.maincan.adscript.rewardbasedvideo.Show ();
			mainuicanvas.maincan.adscript.rewardbasedvideofunc ();

		} else {

		}


//		if (mainuicanvas.maincan.adscript.rewardbasedvideo.IsLoaded ()) {
//			mainuicanvas.maincan.adscript.rewardbasedvideo.Show ();
//
//		} else {
//		}
		watchad.gameObject.SetActive (false);
	}
	public void backfunc()
	{		mainuicanvas.maincan.click.Play ();
		
		watchad.gameObject.SetActive (true);
		play.gameObject.SetActive (false);
		mainuicanvas.stagecollect.gameObject.SetActive(true);
		menu.SetActive (false);


	}
	public void playfunc()
	{		mainuicanvas.maincan.click.Play ();
		
		watchad.gameObject.SetActive (true);
		play.gameObject.SetActive (false);
		menu.gameObject.SetActive (false);
		mainuicanvas.maincan.StartCoroutine (mainuicanvas.maincan.playerpositioncheck());

	}


	// Update is called once per frame
	void Update () {


	}
}
