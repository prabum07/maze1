using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using System;

public class admanager : MonoBehaviour {

	public string apid;
	public string bannerid;
	public string rewardid;
	Coroutine rewardfillroutine;

	public string stringid;
	public string rewardunity;
	public string videounity;

//	public event changeeventhandler changeevent;

	// Use this for initialization
	void Start () {
		Advertisement.Initialize (stringid);




	}



	public void playres(ShowResult ssss)
	{
		
	}
	public bool playable()
	{

		if (Advertisement.IsReady ()) {

			Advertisement.Show (videounity, new ShowOptions { resultCallback = playres });
			return true;
		} else {

			return false;
		}

	}





	public bool rewardbasedvideofunc()
	{

		if (Advertisement.IsReady ()) {
						mainuicanvas.maincan.adevent.text = "ready";

			Advertisement.Show (rewardunity, new ShowOptions { resultCallback = showhandleresult });
			return true;
		} else {
			mainuicanvas.maincan.adevent.text = "ready";

			return false;
		}




	
	}
	

	public void showhandleresult(ShowResult ssss)
	{
		if(ssss==ShowResult.Finished)
		{
					mainuicanvas.maincan.checkpos.rewardedbool = true;
					mainuicanvas.maincan.lockedstage.play.gameObject.SetActive (true);
					mainuicanvas.maincan.lockedstage.watchad.gameObject.SetActive (false);
					mainuicanvas.maincan.checkpos.timetext.text = 30.ToString ();
					mainuicanvas.maincan.enemybug.speed = 0.5f;
					mainuicanvas.maincan.adfunc.text = "adsucess";


		}else if(ssss==ShowResult.Skipped)
		{
					mainuicanvas.maincan.adfunc.text = "skip";

		}else if(ssss==ShowResult.Failed)
		{
					mainuicanvas.maincan.adfunc.text = "fail";

		}
		
	}
}
