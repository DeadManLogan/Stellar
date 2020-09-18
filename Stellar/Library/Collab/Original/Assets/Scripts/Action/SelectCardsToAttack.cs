using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Stellar.GameStates;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Stellar{
	[CreateAssetMenu(menuName = "Actions/SelectCardsToAttackAction")]
	public class SelectCardsToAttack : Action{

		private CardInstance attacker;

		public override void Execute(float d){

			if(Input.GetMouseButtonDown(0)){
				List<RaycastResult> results = Settings.GetUIObjs();

				foreach (RaycastResult r in results){
					CardInstance inst = r.gameObject.GetComponentInParent<CardInstance>();
					PlayerHolder currentPlayer = Settings.gameManager.currentPlayer;

					if(!currentPlayer.downCards.Contains(inst)){
						//clicking on a card thats not in our board
						return;
					}

					if(inst==attacker){	//clicked on the attacking card.
						inst.state = CardInstance.State.Idle;
						inst.viz.outline.SetActive(false);
						attacker = null;	
					}
					else{				//clicked on a new card
						if(inst.CanAttack()){
							if(attacker!=null){		//if there was a previous attacker
								attacker.state = CardInstance.State.Idle;
								attacker.viz.outline.SetActive(false);
							}
							attacker = inst;
							inst.state = CardInstance.State.Attacking;
							inst.viz.outline.SetActive(true);
						}
					}
				}
			}
		}
	}
}
