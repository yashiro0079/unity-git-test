using UnityEngine;
using System.Collections;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;



public class TextMaker : Mover {
	public GUISkin Message_skin;
	//string s = "DOBON.NET";
	int FontPixelSize=0;
	SpriteRenderer sr;
	Vector2 drawSize = Vector2.zero;
	float width = 0;
	float height = 0;
	Rect rect;

	void Awake(){

	}

	// Use this for initialization
	void Start () {
		PictDate();
		Debug.Log(width);
		GetFontPixel("Arial",20);
		//GUIPos();

	}
	
	// Update is called once per frame
	void Update () {
	}

	
	void  OnGUI(){
		rect=new Rect(0,UnityEngine.Screen.height,UnityEngine.Screen.width,UnityEngine.Screen.height/2);
		rect.center=new Vector2(sr.bounds.center.x ,sr.bounds.center.y );
		//rect.center=new Vector2(UnityEngine.Screen.width/1.1f,UnityEngine.Screen.height/3.1f);
		Debug.Log(rect.center);
		GUI.skin = Message_skin;
		GUI.Label(rect,"SSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS","label");
		GUI.skin.label.fontSize=FontPixelSize;
	}

	//DllImport ("System.Drawing.dll",EntryPoint="DrawTextMaker")]

	/*protected void DrawTextMaker(){
		//string[]Message="";

		//A standard size 
		//float Def_VerticalLength=100.0f;
		//float Def_HorizontalLength=100.0f;
		//The character string to display //
		//string s = "DOBON.NET";
		canvas = new System.Drawing.Bitmap(strPic);

		//The size of a former picture in every direction is investigated. 
		width = canvas.Width;
		height = canvas.Height;
		
		System.Drawing.Bitmap bmpSrcHalf =new System.Drawing.Bitmap(canvas , width , height );
		//The Image object made into a drawing place is created. //
		//System.Drawing.Bitmap canvas = new System.Drawing.Bitmap(BoxSize.ToString());
		//System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(canvas);

	}*/
	protected void PictDate(){
		sr = GameObject.FindGameObjectWithTag("Message").GetComponent<SpriteRenderer>();
		Debug.Log(sr.bounds.center);
		width = sr.bounds.size.x;
		height = sr.bounds.size.y;
	}
	//protected Rect GUIPos(){
		//float xp=GameObject.FindGameObjectWithTag("Message").GetComponent<position.x>();
		//rect =new Rect(0,0,0,0);

		//rect.center=new Vector2(0,0);
		//rect.center=new Vector2(x_pos,y_pos);
	//	return rect;

	//}
	protected int GetFontPixel(string FontName,int PixelSize){
		System.Drawing.Font fnt = new System.Drawing.Font(FontName, PixelSize);
		FontPixelSize = (int)fnt.Size;
		return FontPixelSize;
	}

}
