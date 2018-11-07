using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyclass : MonoBehaviour {

	public GameObject target1;
	public GameObject target2;
	public bool stop;
	public Coroutine enemyroutine;
	public float speed;
	// Use this for initialization
	void Start () {
		speed = 1f;
	}
	
	// Update is called once per frame
	void Update () {
	//	transform.position = Vector2.Lerp (this.transform.position,target2.transform.position,0.01f);
	//	this.transform.position+=transform.up*0.01f;

	}
	public IEnumerator enemywalk()
	{
		this.transform.position = target1.transform.position;
		Vector3 tar1 = new Vector3 (target1.transform.position.x,target1.transform.position.y,this.transform.position.z);
		Vector3 tar2 = new Vector3 (target2.transform.position.x,target2.transform.position.y,this.transform.position.z);
		 
		while(Vector3.Distance(this.transform.position,target2.transform.position)>0.01f)
		{
			transform.position=Vector3.MoveTowards (this.transform.position,tar2,speed*Time.deltaTime);
			yield return null;
		}
		transform.position = tar2;
		while(Vector3.Distance(this.transform.position,target1.transform.position)>0.01f)
		{
			transform.position=Vector3.MoveTowards (this.transform.position,tar1,speed*Time.deltaTime);
			yield return null;
		}		transform.position = tar1;
		enemyroutine = StartCoroutine (enemywalk());
		yield return null;

	}void OnTriggerEnter2D(Collider2D col)
	{
		if(col.tag=="Player")
		{
			stop=true;
		}
		print(col.gameObject.name);
	}

}
