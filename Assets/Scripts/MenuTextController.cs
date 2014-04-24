using UnityEngine;
using System.Collections;

public class MenuTextController : MonoBehaviour {

	public enum MenuState{
		Empty,
		Controls,
		Credits
	};
	
	MenuState state;

	TextMesh text;

	void Awake(){
		text = GetComponent<TextMesh>();
	}

	public void SetState(string input){
		if(input == "Credits")
			state = MenuState.Credits;
		else if(input == "Controls")
			state = MenuState.Controls;
		else 
			state = MenuState.Empty;
	}

	// Update is called once per frame
	void Update () {
		switch(state){
			case MenuState.Empty:
				text.text = "";
				break;
			case MenuState.Controls:
				text.text = "Arrow Keys/A+D to move left/right\n" + 
							"Spacebar to jump\n" + 
							"X to create the next piece\n" + 
							"Z to undo placing a piece\n" +
							"R/Up/W to rotate piece";
				break;
			case MenuState.Credits:
				text.text = "Game Design and Coding:\n" + 
								"\tPaul Thurston\n" + 
								"Game Art/Sound:\n" +
								"\tKenney Vleugels (Licensed CC0)\n";
				break;
		}
	}
}
