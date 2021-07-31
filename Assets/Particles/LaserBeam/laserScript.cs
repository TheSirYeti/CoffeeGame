using UnityEngine;
using System.Collections;

//TP Final - Juan Cruz Cristófalo
public class laserScript : MonoBehaviour {
	public Transform startPoint;
	public Transform endPoint;
	LineRenderer laserLine;


	void Start () {
		laserLine = GetComponentInChildren<LineRenderer> ();
		laserLine.SetWidth (.2f, .2f);
	}
	

	void Update () {
		laserLine.SetPosition (0, startPoint.position);
		laserLine.SetPosition (1, endPoint.position);

	}
}
