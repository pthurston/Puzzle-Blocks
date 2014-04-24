using UnityEngine;
using System.Collections;

public class MenuButton : MonoBehaviour {

	public enum ActionType{
		LoadScene,
		ChangeDisplay
	}

	public ActionType actionType;
	public string actionParameter;

	public MenuTextController textDisplay;

	void OnMouseDown(){
		if(actionType == ActionType.LoadScene)
			Application.LoadLevel(actionParameter);
		else if(actionType == ActionType.ChangeDisplay){
			if(textDisplay){
				textDisplay.SetState(actionParameter);
			}
		}
	}
}
