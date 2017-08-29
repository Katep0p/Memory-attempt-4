using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CardScript : MonoBehaviour {

	public bool isShowingFrontSide = true;
	public int id;
	public string pairId;
	public Material backSide;
	public Material frontSide;
	public MeshRenderer renderer;
	public GameObject hemligListaObject;



	void Start () {
		renderer = GetComponent<MeshRenderer>();
		renderer.material = backSide;


	}

	void OnMouseOver ()
	{
		if (hemligListaObject.GetComponent<hemliglista>().canClick == true) {
			if (Input.GetMouseButtonDown (0) && !hemligListaObject.GetComponent<hemliglista> ().imSorryForMakingThisProbablyUselessList.Contains (this.gameObject)) {
				isShowingFrontSide = !isShowingFrontSide;
				renderer.material = frontSide;
				AddingGameobjectsToClickedList ();

				if (string.IsNullOrEmpty (hemligListaObject.GetComponent<hemliglista> ().lastClickedId)) {

					hemligListaObject.GetComponent<hemliglista> ().lastClickedId = pairId;

				} 

				else if (hemligListaObject.GetComponent<hemliglista> ().lastClickedId == pairId) {

					ClearClickedId ();

					hemligListaObject.GetComponent<hemliglista>().canClick = false;
					Invoke ("RemoveCardsFromScreen", 1);

					
				} else {

					ClearClickedId ();
					hemligListaObject.GetComponent<hemliglista>().canClick = false;
					Invoke ("TurnBackSideUp", 1);
				}

			}
		}
	}
					
	public void RemoveCardsFromScreen()
	{
		for (int i = 0; i < hemligListaObject.GetComponent<hemliglista> ().imSorryForMakingThisProbablyUselessList.Count; i++)
		{
			GameObject currentlyLookedAtObject = hemligListaObject.GetComponent<hemliglista> ().imSorryForMakingThisProbablyUselessList [i].gameObject;

			for (int e = 0; e < hemligListaObject.GetComponent<hemliglista>().idList.Count; e++) 
			{
				if(hemligListaObject.GetComponent<hemliglista> ().idList[e] == currentlyLookedAtObject)
				{
					hemligListaObject.GetComponent<hemliglista> ().idList.RemoveAt (e);
				}
			}
				
				Destroy(currentlyLookedAtObject);
		}
		hemligListaObject.GetComponent<hemliglista> ().imSorryForMakingThisProbablyUselessList.Clear();

		hemligListaObject.GetComponent<hemliglista>().canClick = true;

	}



	public void TurnBackSideUp() 
	{
		//System.Threading.Thread.Sleep(500);
		foreach (GameObject obj in hemligListaObject.GetComponent<hemliglista> ().imSorryForMakingThisProbablyUselessList) 
		{
			obj.GetComponent<MeshRenderer>().material = backSide;

		}
		hemligListaObject.GetComponent<hemliglista>().canClick = true;
		hemligListaObject.GetComponent<hemliglista> ().imSorryForMakingThisProbablyUselessList.Clear();
		hemligListaObject.GetComponent<hemliglista>().tries++;
	}


	//Tror detta borde vara rätt och att något annat verkar va paj? 
	public void AddingGameobjectsToClickedList()
	{
		hemligListaObject.GetComponent<hemliglista> ().imSorryForMakingThisProbablyUselessList.Add(this.gameObject);
	}


	public void ClearClickedId()
	{
		hemligListaObject.GetComponent<hemliglista> ().lastClickedId = "";
	}
		
}
	
//börja om spelet
//Random.range