using UnityEngine;
using System.Collections;

public class DoorBehavior : MonoBehaviour {
	private SaveScript SaveObject;
	// Use this for initialization
	void Start () {
		SaveObject = GameObject.Find("SaveObject").GetComponent<SaveScript> ();
	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnCollisionEnter (Collision col){

		if(Item.Getallkeys == true){
            SaveObject.SaveLevel += 1;
            PlayerPrefs.SetInt("LevelSaved", SaveObject.SaveLevel + 1);
            Application.LoadLevel(Application.loadedLevel + 1);
		}
	}
}
