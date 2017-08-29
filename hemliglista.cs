using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class hemliglista : MonoBehaviour {
	public List <GameObject> idList;
	public string lastClickedId;
	public GameObject Card1;
	public GameObject Card2;
	public GameObject Card3;
	public GameObject Card4;
	public GameObject Card5;
	public GameObject Card6;
	public GameObject Card7;
	public GameObject Card8;
	public GameObject Card9;
	public GameObject Card10;
	public GameObject Card11;
	public GameObject Card12;
	public GameObject Card13;
	public GameObject Card14;
	public GameObject Card15;
	public GameObject Card16;
	public List <GameObject> imSorryForMakingThisProbablyUselessList;
	public bool canClick = true;

	public GameObject[] AllSingleCards;
		
	public int gridWidth;
	public int gridHeight;
	public int tries = 0;
	public int randomPosition;

	void Start () {
		GatheringAllCards ();
		GettingCardsInPosition();
		
	}

	void Update()
	{
		RestartingGame ();
	}
	

	public void GatheringAllCards()
	{
		idList.Add (Card1.gameObject);
		idList.Add (Card2.gameObject);
		idList.Add (Card3.gameObject);
		idList.Add (Card4.gameObject);
		idList.Add (Card5.gameObject);
		idList.Add (Card6.gameObject);
		idList.Add (Card7.gameObject);
		idList.Add (Card8.gameObject);
		idList.Add (Card9.gameObject);
		idList.Add (Card10.gameObject);
		idList.Add (Card11.gameObject);
		idList.Add (Card12.gameObject);
		idList.Add (Card13.gameObject);
		idList.Add (Card14.gameObject);
		idList.Add (Card15.gameObject);
		idList.Add (Card16.gameObject);

		ShuffleList (idList);

	}
				

	public void GettingCardsInPosition(){

		Vector3 gridPos = new Vector3(1, 1, 3);
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


			idList [i].transform.position = gridPos;



			widthPos++;
		}
	}
			
	void OnGUI ()
	{
		GUI.color = Color.white;
		GUI.skin.label.fontSize = 40;
		GUILayout.Label (" Tries: " + tries.ToString ());
	}
		
	public void RestartingGame()
	{
		if (idList.Count == 0)
			Application.LoadLevel(Application.loadedLevel);

	}

	public void ShuffleList(List<GameObject> usedList)
	{
		List<GameObject> tempList = new List<GameObject>();
		int origLength = idList.Count;

		for(int i = 0; i < origLength; i++)
		{
			int randomIndex = Random.Range (0, idList.Count);
			tempList.Add(idList[randomIndex]);
			idList.RemoveAt (randomIndex);
		}
		foreach (GameObject g in tempList) 
		{
			idList.Add (g);
		}
		tempList.Clear ();
	}
}

	
