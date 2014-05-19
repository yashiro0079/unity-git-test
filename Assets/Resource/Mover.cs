using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Mover : MonoBehaviour {
	float CenterScale_X;
	float CenterScale_Y;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	protected int Minimum(int w_X,int h_Y){
		CenterScale_X=(float)w_X / 1080f*50f;
		CenterScale_Y=(float)h_Y/ 1920*50f;
		return (((int)CenterScale_X <= (int)CenterScale_Y)?  (int)CenterScale_X : (int)CenterScale_Y);
	}
	protected float C_Pos_X=(float)Screen.width / 1080f;
	protected float C_Pos_Y=(float)Screen.height / 1920f;


	#region Raycast
	public bool RayCast(out Vector3 wold_position,Vector3 input_position){
		bool hit = false;
		float depth;
		wold_position=Vector3.zero;
		
		GameObject back_ground = GameObject.FindGameObjectWithTag("BackGround");
		GameObject camera =GameObject.FindGameObjectWithTag("MainCamera");
		
		if(back_ground == null|| camera == null)return hit;
		
		Plane plane = new Plane(new Vector3(0.0f,0.0f,-1.0f),back_ground.transform.position);
		Ray ray = camera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
		
		if(plane.Raycast(ray,out depth)){
			wold_position=ray.origin + ray.direction*depth;
			hit=true;
		}else{
			wold_position=Vector3.zero;
		}
		return hit;
	}
	#endregion

	#region Position
	protected Vector3 Position{
		set { this.transform.position = value; }
		get { return this.transform.position; }
	}
	//PositionX
	protected float PositionX{
		set { Position = new Vector3(value, Position.y, Position.z); }
		get { return this.transform.position.x; }
	}
	//PositionY
	protected float PositionY{
		set { Position = new Vector3(Position.x, value, Position.z); }
		get { return this.transform.position.y; }
	}
	//PositionZ
	protected float PositionZ{
		set { Position = new Vector3(Position.x, Position.y, value); }
		get { return this.transform.position.z; }
	}
	#endregion

	#region Rotation
	protected Quaternion Rotation{
		set { this.transform.rotation = value; }
		get { return this.transform.rotation; }
	}
	//PositionX
	protected float RotationX{
		set { Rotation = new Quaternion(value, Rotation.y, Rotation.z,Rotation.w); }
		get { return Rotation.x; }
	}
	//PositionY
	protected float RotationY{
		set { Rotation = new Quaternion(Rotation.x, value, Rotation.z,Rotation.w); }
		get { return Rotation.y; }
	}
	//PositionZ
	protected float RotationZ{
		set { Rotation = new Quaternion(Rotation.x, Rotation.y, value,Rotation.w); }
		get { return Rotation.z; }
	}
	#endregion

	#region Scale
	protected Vector3 Scale{
		set { this.transform.localScale = value; }
		get { return this.transform.localScale; }
	}
	//PositionX
	protected float ScaleX{
		set { Scale = new Vector3(value, Scale.y, Scale.z); }
		get { return this.transform.localScale.x; }
	}
	//PositionY
	protected float ScaleY{
		set { Scale = new Vector3(Scale.x, value, Scale.z); }
		get { return this.transform.localScale.y; }
	}
	//PositionZ
	protected float ScaleZ{
		set { Scale = new Vector3(Scale.x, Scale.y, value); }
		get { return this.transform.localScale.z; }
	}
	
	#endregion

	#region velocity
	
	// Velocity
	protected Vector3 Velocity = Vector3.zero;
	
	// get the velocity
	public Vector3 GetVelocity ()
	{
		return Velocity;
	}
	
	// set the velocity
	public void SetVelocity (Vector3 v)
	{
		Velocity = v;
	}
	
	#endregion

	#region type
	
	// Type
	protected int Type = 0;
	
	// set the type
	protected void SetType (int type)
	{
		Type = type;
	}
	
	// get the type
	public new int GetType (){
		return Type;
	}
	
	#endregion

	#region hit
	
	// judge the hit by circle
	protected bool HitCircle (GameObject a, GameObject b, float adjustment )
	{
		//adjustment=1f;
		
		float pLength = (a.transform.position - b.transform.position).magnitude;
		float sLength = (a.transform.localScale.x + b.transform.localScale.x) / 1.0f * adjustment;
		return (pLength < sLength);
	}
	
	#endregion

	#region apply
	
	// apply, can write like this
	protected void Apply(string tagName, Action<GameObject, GameObject> apply)
	{
		GameObject[] objs = GameObject.FindGameObjectsWithTag(tagName);
		
		for (int i = 0; i < objs.Length; ++i)
		{
			apply(this.gameObject, objs[i]);
		}
	}	
	#endregion
}
