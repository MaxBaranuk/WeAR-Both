using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UIManager : MonoBehaviour 
{
	public static UIManager instance;

	public GameObject house;

	public GameObject next;
	public GameObject prev;

	public Texture[] currentMode;
	public Color[] currentColor;

	public Texture[] _brick;
	public Texture[] _mainDore;
	public Texture[] _tiles;
	public Texture[] _concrete;

	public Color[] _doreCase;
	public Color[] _metalColor;
	public Color[] _windowFrame;

	public int clickCount = -1;


	void Start () 
	{
		if (instance == null) 
		{
			instance = this;
		}
		_brick = new Texture[5];
		_tiles = new Texture[5];
		_concrete = new Texture[5];
		_mainDore = new Texture[5];

		_doreCase = new Color[5];
		_metalColor = new Color[5];


		_metalColor [0] = new Color (0.2f, 0.3f, 0.4f, 0.5f);
		_metalColor [1] = new Color (0.1f, 0.2f, 0.5f, 0.5f);
		_metalColor [2] = new Color (0.3f, 0.750f, 0.25f, 0.5f);
		_metalColor [3] = new Color (0.85f, 0.10f, 0.645f, 0.5f);
		_metalColor [4] = new Color (0.4f, 0.5f, 0.7f, 0.5f);

		_doreCase [0] = new Color (0.106f, 0.051f, 0.039f);
		_doreCase [1] = new Color (0.740f, 0.740f, 0.740f);
		_doreCase [2] = new Color (0.324f, 0.185f, 0.098f);
		_doreCase [3] = new Color (0.434f, 0.104f, 0.002f);
		_doreCase [4] = new Color (0.381f, 0.106f, 0.106f);

		for (int i = 0; i < 5; i++) 
		{
			_concrete [i] = Resources.Load ("concrete" + "_" + i.ToString ()) as Texture2D;
			_brick[i] = Resources.Load("brick" + "_" + i.ToString()) as Texture2D;
			_mainDore [i] = Resources.Load ("door" + "_" + i.ToString ()) as Texture2D;
			_tiles [i] = Resources.Load ("tile" + "_" + i.ToString ()) as Texture;
		}

		next.SetActive (false);
		prev.SetActive (false);
		StateManager.instance.StartState ();

	}

	public void ResetPosition()
	{
		house.transform.rotation = Quaternion.identity;
	}



	public void ChangeTexturesButton()
	{
		switch (StateManager.instance.states) 
		{
		case States.Brick:
			
			var brick = GameObject.Find ("brick");
			brick.GetComponent<MeshRenderer> ().material.mainTexture = _brick [clickCount];
			break;
		case States.Tiles:
			var tiles = GameObject.Find ("tiles");
			tiles.GetComponent<MeshRenderer> ().material.mainTexture = _tiles[clickCount];
			break;
		case States.Concrete:
			var concrete = GameObject.Find ("concrete");
			concrete.GetComponent<MeshRenderer> ().material.mainTexture = _concrete [clickCount];
			break;
		case States.DoreColor:
			var doreColor = GameObject.Find ("door_case");
			doreColor.GetComponent<MeshRenderer> ().material.color = _doreCase [clickCount];
			break;
		case States.DoreTexture:
			var doreTexture = GameObject.Find ("main_door");
			doreTexture.GetComponent<MeshRenderer> ().material.mainTexture = _mainDore [clickCount];
			break;
		case States.MetalColor:
			var metalColor = GameObject.Find ("metal");
			metalColor.GetComponent<MeshRenderer> ().material.color = _metalColor [clickCount];
			break;
		case States.WindowFrame:
			var windowFrame = GameObject.Find ("window_frames");
			windowFrame.GetComponent<MeshRenderer> ().material.color = _doreCase [clickCount];
			break;
		}


	}

	public void ClickNext()
	{
		prev.SetActive (true);
		clickCount ++;
		if (clickCount >= currentMode.Length-1 && clickCount >= currentColor.Length - 1) 
		{
			next.SetActive(false);
			Debug.Log (clickCount);
		}

	}

	public void ClickPrew()
	{
		next.SetActive (true);
		clickCount--;
		if (clickCount == 0) 
		{
			prev.SetActive(false);
			Debug.Log (clickCount);
		}
	}

	public void Exit()
	{
		Application.Quit ();
	}
}
