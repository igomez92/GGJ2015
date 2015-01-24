﻿using UnityEngine;
using System.Collections;

public class CharacterRotate : MonoBehaviour {
	public GameObject player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 targetDir = camera.ScreenToWorldPoint(Input.mousePosition) - player.transform.position;
		float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
		player.transform.rotation = Quaternion.AngleAxis(angle-90, Vector3.forward);
		//player.transform.rotation = Quaternion.FromToRotation (Vector3.up,(camera.ScreenToWorldPoint(Input.mousePosition) - player.transform.position).normalized);
	}
}