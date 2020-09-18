using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Stellar.GameStates;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Stellar{
	[CreateAssetMenu(menuName = "Actions/SelectCardsToAttackAction")]
	public class SelectCardsToAttack : Action{

		private bool hasSelectedAttacker = false;

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
					if(inst.CanAttack()){
						if(inst.viz.outline.activeSelf){
							inst.viz.outline.SetActive(false);
							hasSelectedAttacker = false;
						}
						else if(hasSelectedAttacker == false){
							inst.viz.outline.SetActive(true);
							hasSelectedAttacker = true;
						}
					}
					
				}
			}
		}
	}
}
