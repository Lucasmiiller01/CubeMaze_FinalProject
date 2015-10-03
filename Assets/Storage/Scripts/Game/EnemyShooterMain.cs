using UnityEngine;
using System.Collections;

public class EnemyShooterMain : MonoBehaviour {
	
	public static EnemyShooterMain reference;
	private CustomGravity customGravity;
	public string ainDirection;
	
	private Vector3 direction = Vector3.right;
	public GameObject shoot;
	private GameObject shooter;
	
	#region Get/Set
	public Vector3 Direction
	{
		get
		{
			return direction;
		}
		set
		{
			direction = value;
			if (direction == Vector3.left)
				transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, 270, transform.rotation.eulerAngles.z));
			else if (direction == Vector3.right)
				transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, 90, transform.rotation.eulerAngles.z));
			else if (direction == Vector3.back)
				transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, 180, transform.rotation.eulerAngles.z));
			else
				transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, 0, transform.rotation.eulerAngles.z));
		}
	}
	#endregion
	
	void Awake()
	{
		reference = this;
	}
	
	void Start () {
		switch (ainDirection.ToLower ())
		{
		case "left":
			Direction = Vector3.left;
			break;
			
		case "right":
			Direction = Vector3.right;
			break;
			
		case "forward":
		case "up":
		case "front":
			Direction = Vector3.forward;
			break;
			
		case "back":
		case "backwards":
		case "down":
			Direction = Vector3.back;
			break;
		default:
			Direction = Vector3.back;
			break;
			
		}
		customGravity = GetComponent<CustomGravity>();
		StartCoroutine(AI());
	}
	
	void GameOver() 
	{
		Application.LoadLevel ("GameOver");
	}

	#region AI Code
	IEnumerator AI()
	{
		shooter = (GameObject) Instantiate(shoot, this.transform.position, this.transform.rotation);
		shooter.GetComponent<ShootBehaviour>().enabled = true;
		yield return new WaitForSeconds(1f);
		StartCoroutine(AI());
	}
	#endregion
}
