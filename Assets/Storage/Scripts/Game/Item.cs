using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Item : MonoBehaviour {
	public static int Q_item;
	public static int Q_state_item;
	public GameObject[] itens;
	public Text Keys;
	public static bool Getallkeys ;

	// Use this for initialization
	void Start () {
		Q_state_item = 0;
        Getallkeys = false;
        itens = GameObject.FindGameObjectsWithTag("item");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Keys.text = Q_state_item.ToString () + "/" + itens.Length.ToString ();

		for (int i = 0; i < itens.Length; i++) {
			Q_item = i;
		}
		if (Q_state_item >= itens.Length)
			Getallkeys = true;
		}

}
