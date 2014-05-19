using UnityEngine;
using System.Collections;

public class CSingleton<T> : Mover where T : MonoBehaviour{

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	//=========================================================================
	// Move when the script is started
	//=========================================================================
	//protected void Awake ()
	//{
	//	CheckInstance();
	//}

	//=========================================================================
	// Check the validity of the instance
	//=========================================================================
/*	protected bool CheckInstance()
	{
		if (this == Instance){
			return true;
		}
		Destroy(this);
		return false;
	}*/
	
}
