using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rewardmenu : MonoBehaviour {
	public GameObject win;
	public GameObject lose;
	public Image fillamount;
	public Button loseback;
	public Button wonback;
	// Use this for initialization
	void Start () {
		loseback.onClick.AddListener (() => backfunc ());
		wonback.onClick.AddListener (() => backfunc ());

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void backfunc()
	{
		mainuicanvas.maincan.adscript.playable ();
		mainuicanvas.maincan.click.Play ();

		win.gameObject.SetActive (false);
		lose.gameObject.SetActive (false);
		mainuicanvas.stagecollect.gameObject.SetActive (true);
		mainuicanvas.maincan.gameObject.GetComponent<Image> ().enabled = true;
		mainuicanvas.stagecollect.btnarrange ();
		mainuicanvas.maincan.playerpos.gyrobutton = false;
	}
}
