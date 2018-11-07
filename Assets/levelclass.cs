using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelclass : MonoBehaviour {


	public float level1;
	public float level2;
	public float level3;
	public float levelres;
	public GameObject enemy;

	public bool currentactive;
	public string currentactivestring;
	public GameObject startpos;

	public GameObject target1;
	public GameObject target2;


	// Use this for initialization

	public void prefsset1()
	{
		if (PlayerPrefs.HasKey (level1.ToString ())) {
			print ("already");
			levelres = PlayerPrefs.GetFloat (level1.ToString ());
			currentactivestring = level1.ToString ();
		} else {
			print ("alreadyno");

			PlayerPrefs.SetInt (level1.ToString(),0);
			levelres = PlayerPrefs.GetFloat (level1.ToString());
			currentactivestring = level1.ToString ();

		}
	}
	public void prefsset2()
	{
		if (PlayerPrefs.HasKey (level2.ToString ())) {
			levelres = PlayerPrefs.GetFloat (level2.ToString ());
			currentactivestring = level2.ToString ();

		} else {
			PlayerPrefs.SetInt (level2.ToString(),0);
			levelres = PlayerPrefs.GetFloat (level2.ToString());
			currentactivestring = level2.ToString ();

		}
	}
	public void prefsset3()
	{
		if (PlayerPrefs.HasKey (level3.ToString ())) {
			levelres = PlayerPrefs.GetFloat (level3.ToString ());
			currentactivestring = level3.ToString ();

		} else {
			PlayerPrefs.SetInt (level3.ToString(),0);
			levelres = PlayerPrefs.GetFloat (level3.ToString());
			currentactivestring = level3.ToString ();

		}
	}
	void Start () {
		//StartCoroutine (enemylevel());
			
	}
	public	IEnumerator enemylevel()
	{		
		mainuicanvas.maincan.score.gameObject.SetActive (false);

		mainuicanvas.maincan.player.transform.position = startpos.transform.position;		
		mainuicanvas.maincan.enemybug.stop = false;
		mainuicanvas.maincan.targethit = false;
		StartCoroutine (mainuicanvas.maincan.enemybug.enemywalk());
		while (!mainuicanvas.maincan.targethit) {
			
			if(mainuicanvas.maincan.enemybug.stop)
			{
				mainuicanvas.maincan.rewardmenu.win.gameObject.SetActive (false);
				mainuicanvas.maincan.rewardmenu.lose.gameObject.SetActive (true);
				mainuicanvas.maincan.rewardmenu.fillamount.fillAmount = mainuicanvas.maincan.remainingsec;
				mainuicanvas.maincan.pausemenu.pausebtn.gameObject.SetActive (false);

				break;
			}
			if(mainuicanvas.maincan.pausemenu.homebtnbool)
			{
				break;
			}
			yield return null;
		}
		if (mainuicanvas.maincan.pausemenu.homebtnbool == false) {
			if (mainuicanvas.maincan.targethit) {
				PlayerPrefs.SetFloat (currentactivestring, 1);
				mainuicanvas.maincan.rewardmenu.win.gameObject.SetActive (true);
				mainuicanvas.maincan.rewardmenu.lose.gameObject.SetActive (false);
				mainuicanvas.maincan.rewardmenu.fillamount.fillAmount = 1;
				mainuicanvas.maincan.pausemenu.pausebtn.gameObject.SetActive (false);

			}	
		}mainuicanvas.maincan.targethit = false;
		mainuicanvas.maincan.enemybug.stop = false;
		mainuicanvas.maincan.enemybug.StopAllCoroutines ();
		mainuicanvas.maincan.pausemenu.homebtnbool = false;

		mainuicanvas.maincan.enemybug.transform.position = new Vector3 (1000,1000,mainuicanvas.maincan.enemybug.transform.position.z);
	}
	// Update is called once per frame
	public IEnumerator enemytime()

	{	mainuicanvas.maincan.player.transform.position = startpos.transform.position;
		mainuicanvas.maincan.score.gameObject.SetActive (true);
		mainuicanvas.maincan.pausemenu.homebtnbool = false;
		StartCoroutine (mainuicanvas.maincan.enemybug.enemywalk());
		mainuicanvas.maincan.enemybug.stop = false;
		mainuicanvas.maincan.targethit = false;
		while (mainuicanvas.maincan.totalsec != 0) {

			if(mainuicanvas.maincan.targethit)
			{
				mainuicanvas.maincan.remainingsec = mainuicanvas.maincan.totalsec*(1f/mainuicanvas.maincan.mainsec) ;
				mainuicanvas.maincan.remainingsec =Mathf.Clamp(mainuicanvas.maincan.remainingsec*2,0,1);


				if(mainuicanvas.maincan.remainingsec>levelres)
				{
					PlayerPrefs.SetFloat (currentactivestring,mainuicanvas.maincan.remainingsec);

				}



				break;
			}
			if(mainuicanvas.maincan.pausemenu.homebtnbool)
			{
				break;
			}
			if(mainuicanvas.maincan.enemybug.stop)
			{
				mainuicanvas.maincan.rewardmenu.win.gameObject.SetActive (false);
				mainuicanvas.maincan.rewardmenu.lose.gameObject.SetActive (true);
				mainuicanvas.maincan.enemybug.stop = false;
				break;
			}
			yield return new WaitForSeconds (1f);
			mainuicanvas.maincan.totalsec -= 1;
			mainuicanvas.maincan.score.clock.text = mainuicanvas.maincan.totalsec.ToString ();
		}
		if (mainuicanvas.maincan.pausemenu.homebtnbool == false) {
			if (!mainuicanvas.maincan.targethit) {

				mainuicanvas.maincan.rewardmenu.win.gameObject.SetActive (false);
				mainuicanvas.maincan.rewardmenu.lose.gameObject.SetActive (true);
				mainuicanvas.maincan.pausemenu.pausebtn.gameObject.SetActive (false);

			} else {
				mainuicanvas.maincan.rewardmenu.win.gameObject.SetActive (true);
				mainuicanvas.maincan.rewardmenu.lose.gameObject.SetActive (false);
				mainuicanvas.maincan.rewardmenu.fillamount.fillAmount = mainuicanvas.maincan.remainingsec;
				mainuicanvas.maincan.pausemenu.pausebtn.gameObject.SetActive (false);

			}
		}
		mainuicanvas.maincan.targethit = false;
		mainuicanvas.maincan.enemybug.stop = false;
		mainuicanvas.maincan.enemybug.StopAllCoroutines ();
		mainuicanvas.maincan.score.gameObject.SetActive (false);

		mainuicanvas.maincan.enemybug.transform.position = new Vector3 (1000,1000,mainuicanvas.maincan.enemybug.transform.position.z);
		mainuicanvas.maincan.pausemenu.homebtnbool = false;
	}
	//level1
	public IEnumerator levelstart()
	{
		
		mainuicanvas.maincan.player.transform.position = startpos.transform.position;
		mainuicanvas.maincan.score.gameObject.SetActive (true);

		mainuicanvas.maincan.targethit = false;
		while(mainuicanvas.maincan.totalsec!=0)
		{

			if(mainuicanvas.maincan.pausemenu.homebtnbool)
			{
				break;
			}
			if(mainuicanvas.maincan.targethit)
			{				mainuicanvas.maincan.rewardmenu.wonback.gameObject.SetActive (true);
				
				mainuicanvas.maincan.remainingsec = mainuicanvas.maincan.totalsec*(1f/mainuicanvas.maincan.mainsec) ;
				mainuicanvas.maincan.remainingsec =Mathf.Clamp(mainuicanvas.maincan.remainingsec*2,0,1);


				if(mainuicanvas.maincan.remainingsec>levelres)
				{
					PlayerPrefs.SetFloat (currentactivestring,mainuicanvas.maincan.remainingsec);

				}

				break;
			}
			yield return new WaitForSeconds (1f);
			mainuicanvas.maincan.totalsec -= 1;
			mainuicanvas.maincan.score.clock.text = mainuicanvas.maincan.totalsec.ToString ();

		}

	if(mainuicanvas.maincan.pausemenu.homebtnbool==false)
		{
		if (!mainuicanvas.maincan.targethit) {
			mainuicanvas.maincan.rewardmenu.win.gameObject.SetActive (false);
			mainuicanvas.maincan.rewardmenu.lose.gameObject.SetActive (true);
				mainuicanvas.maincan.pausemenu.pausebtn.gameObject.SetActive (false);

		} else {

			mainuicanvas.maincan.rewardmenu.win.gameObject.SetActive (true);
			mainuicanvas.maincan.rewardmenu.lose.gameObject.SetActive (false);
			mainuicanvas.maincan.rewardmenu.fillamount.fillAmount = mainuicanvas.maincan.remainingsec;
				mainuicanvas.maincan.pausemenu.pausebtn.gameObject.SetActive (false);

		}
		}
		mainuicanvas.maincan.score.gameObject.SetActive (false);

		
		mainuicanvas.maincan.targethit = false;
	mainuicanvas.maincan.pausemenu.homebtnbool = false;

		yield return null;
	}
}