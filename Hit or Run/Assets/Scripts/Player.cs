﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	public Rigidbody2D Bullet;
	public Vector3 playerPosition;
	public float speed=10;
	public int bulletsFired = 0;
	public float timer = 0;
	private Animator anim;
	private bool reloading = false;

	public bool canPunch, canShoot, canThrow = true;

	public GameObject hitBox;
	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator> ();
		//hitBox = GetComponentInChildren<SpriteRenderer> ();
	}

	//Use FixedUpdate for frame-independent physics activities
	void FixedUpdate(){
		//alternative character control
		//make your life easier with this instead of setting each of wasd keys
		rigidbody2D.velocity = new Vector2 (Input.GetAxis ("Horizontal")*speed, Input.GetAxis ("Vertical")*speed);

		/*
		playerPosition = transform.position;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit = new RaycastHit ();

		if (Physics.Raycast (ray, out hit, 100)) 
		{
			Vector3 hitPoint = hit.point;
			Vector3 targetDir = hitPoint - transform.position;
			
			float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		}
		*/
	}

	// Update is called once per frame
	void Update () 
	{

		if(rigidbody2D.velocity!=Vector2.zero)
			anim.SetBool("walk",true);
		
		else
			anim.SetBool("walk",false);

		if(Input.GetKeyDown(KeyCode.Mouse1))
		   StartCoroutine(attackAnim());
		//Character Controls
		/*
		if (Input.GetKey (KeyCode.A))
			controller.Move (Vector3.left * Time.deltaTime * 5);
		if (Input.GetKey (KeyCode.D))
			controller.Move (Vector3.right * Time.deltaTime * 5);
		if (Input.GetKey (KeyCode.W))
			controller.Move (Vector3.up * Time.deltaTime * 5);
		if (Input.GetKey (KeyCode.S))
			controller.Move (Vector3.down * Time.deltaTime * 5);
			*/
		//transform.RotateAround (transform.position, Vector3.forward, .1f);

		//Create bullet with Left Click
		if (Input.GetKeyDown (KeyCode.Mouse0) && !reloading) 
		{
			if(canShoot)
			{
				Rigidbody2D clone;
				clone = Instantiate(Bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation) as Rigidbody2D;
				clone.velocity = transform.TransformDirection(Vector3.up * 10);
				bulletsFired++;
				if (bulletsFired % 5 == 0)
					reloading = true;
			}
			
		}
		if (bulletsFired % 5 == 0  && reloading)
		{
			timer += Time.deltaTime;
			if(timer >= 3)
			{
				reloading = false;
				timer = 0;
			}
		}


		
	}
	
	IEnumerator attackAnim(){
		anim.SetBool ("swag", true);
		yield return new WaitForSeconds(.25f);
		anim.SetBool ("swag", false);
	}	

	void hurt()
	{
		//Destoy (this.gameObject);
	}
}
