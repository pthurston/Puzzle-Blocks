using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PieceQueue : MonoBehaviour {

	public Transform[] pieces;
	public Vector2 spawnPoint;

	LinkedList<Transform> piecesToPlace;
	Stack<Transform> placedPieces;

	//GUI Element positions;
	Rect buttonPos;
	Rect button2Pos;
	Rect infoPos;

	bool canCreate = true;

	public int PiecesLeft{
		get { return piecesToPlace.Count; }
	}

	public int PlacedPiecesCount{
		get { return placedPieces.Count; }
	}

	public bool CanCreate{
		get { return canCreate; }
		set { canCreate = value; }
	}

	void Start(){

		piecesToPlace = new LinkedList<Transform>();
		placedPieces = new Stack<Transform>();

		for(int i = 0; i < pieces.Length; i++){

			Vector3 queuePos = transform.position + Vector3.right * i;
			Transform instantiatedPiece = Instantiate(pieces[i], queuePos, Quaternion.identity) as Transform;
			instantiatedPiece.localScale = new Vector3(0.25f, 0.25f, 0.25f);
			instantiatedPiece.parent = transform;
			piecesToPlace.AddLast(instantiatedPiece);
		}

		buttonPos = new Rect(10, 10, 100, 25);
		button2Pos = new Rect(10, 45, 100, 25);
		infoPos = new Rect(120, 10, 40, 60);
	}

	public void CreatePiece(){
	
		Transform newPiece = piecesToPlace.First.Value;
		piecesToPlace.RemoveFirst();
		foreach(Transform t in piecesToPlace){
			t.GetComponent<Tween2D>().MoveByOffset(-Vector2.right, 0.25f);
		}

		placedPieces.Push(newPiece);
		newPiece.gameObject.AddComponent("PieceControl");
		newPiece.position = spawnPoint;
		newPiece.localScale = new Vector3(1,1,1);
		canCreate = false;
	}

	void UndoPiecePlacement(){
		Transform removedPiece = placedPieces.Pop();
		removedPiece.localScale = new Vector3(0.25f, 0.25f, 0.25f);
		removedPiece.position = transform.position;
		Destroy(removedPiece.GetComponent<PieceControl>());
		foreach(Transform t in piecesToPlace){
			t.GetComponent<Tween2D>().MoveByOffset(Vector2.right, 0.25f);
		}
		piecesToPlace.AddFirst(removedPiece);
		canCreate = true;
	}

	void Update(){
		if(Input.GetKeyDown("u")){
			UndoPiecePlacement();
		}
	}

	void OnGUI(){
		if(PiecesLeft > 0){
			if((GUI.Button(buttonPos, "Place new piece") || Input.GetKeyDown("v")) && canCreate)
				CreatePiece();
		}else{
			GUI.Box(buttonPos, "No more pieces");
		}

		GUI.Box(infoPos, "There are " + PiecesLeft + " Pieces Left");
	}
}
