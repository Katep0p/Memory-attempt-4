using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeinHandler : MonoBehaviour {

	//public List<Vector3> AllCardPositions = new List<Vector3>();
	public GameObject[] AllSingleCards;

	public int gridWidth;
	public int gridHeight;

	public string lastPressedID;


	// Use this for initialization
	void Start () {
		GatheringAllCards ();
		GettingCardsInPosition();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	public void GatheringAllCards(){
		
		AllSingleCards = GameObject.FindGameObjectsWithTag("card");
		for (int i = 0; i < AllSingleCards.Length; i++) {
			//Debug.Log (AllSingleCards [i]);
		}
	}
		
	public void GettingCardsInPosition(){

		Vector3 gridPos = new Vector3(1, 1, 0);
		int widthPos = 1;
		int heightPos = 1;

		for (int i = 0; i < gridHeight*gridWidth; i++)
		{
			if (widthPos > gridWidth)
			{
				widthPos = 1;
				heightPos++;
			}
			gridPos.x = widthPos;
			gridPos.y = heightPos;

			AllSingleCards [i].transform.position = gridPos;

			widthPos++;
		}
	}
}