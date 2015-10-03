using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SaveScript : MonoBehaviour 
{
	public static SaveScript instance;
	private SaveScript SaveObject;
	private int LevelSave;
	private Button[] Botoes;
	public int SaveLevel
	{
		get
		{
			return this.LevelSave;
		}
		set
		{
			if(LevelSave < 1)
			{
				this.LevelSave = 1;
			}
			else
			{
				this.LevelSave = value;
			}
		}
	}
	void Awake()
	{
		instance = this;
	}
	void Start () 
	{
		try
		{
			SaveObject = GameObject.Find("SaveObject").GetComponent<SaveScript>();	
			SaveObject.SaveLevel = PlayerPrefs.GetInt("LevelSaved");
		}
		catch
		{
		
		}
		DontDestroyOnLoad(transform.gameObject);
		Botoes = new Button[10];
	}
	
	void Update () 
	{

        Debug.Log(SaveObject.LevelSave);
		try
		{
			if(SaveObject.LevelSave != PlayerPrefs.GetInt("LevelSaved"))
			{
				PlayerPrefs.SetInt("LevelSaved",SaveObject.LevelSave);
			}
			for(int i = 0; i < 10; i++)
			{
				Botoes[i] = GameObject.Find("Fase"+(i+1)).GetComponent<Button>();
			}
			for(int i = 1; i < 10; i++)
			{
				if(i < SaveObject.SaveLevel)
				{
					Botoes[i].interactable = true;
				}
				else
				{
					Botoes[i].interactable = false;
				}
			}
		}
		catch
		{
			
		}
	}
	public void OnClicked()
	{
		try
		{
			Application.LoadLevel(gameObject.name);
		}
		catch
		{
		
		}
	}
}
