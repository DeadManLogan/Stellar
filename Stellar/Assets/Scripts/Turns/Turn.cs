using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Stellar{

	[CreateAssetMenu(menuName="Turns/Turn")]
	public class Turn : ScriptableObject
	{

		public PlayerHolder player;
		public bool forceExit;
		// player actions are all the actions that need to happen when the turn starts
		public PlayerAction[] turnStartActions;

		public GameStates.GameState myTurnState;
		public GameStates.GameState enemyTurnState;
		
		public void OnTurnStart(){
			forceExit = false;

			if(turnStartActions == null)
				return;

			Settings.gameManager.SetState(myTurnState);

			for(int i=0; i< turnStartActions.Length; i++){
				turnStartActions[i].Execute(player);
			}
		}

		public void EndTurn(){
			forceExit = true;
			Settings.gameManager.SetState(enemyTurnState);
			foreach(CardInstance c in player.downCards){
				if(c==null){
					continue;
				}
				if(c.viz.outline.activeSelf){
					c.viz.outline.SetActive(false);
				}
			}
		}

	}
}
