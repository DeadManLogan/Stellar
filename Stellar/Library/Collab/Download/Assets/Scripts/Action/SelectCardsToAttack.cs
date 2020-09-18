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
		public ResolveCombat resolveCombat;

		public override void Execute(float d){
			if(Input.GetMouseButtonDown(0)){
				List<RaycastResult> results = Settings.GetUIObjs();
				PlayerHolder currentPlayer = Settings.gameManager.currentPlayer;
				PlayerHolder[] all_players = Settings.gameManager.all_players;
				PlayerHolder otherPlayer = all_players[1];

				foreach (RaycastResult r in results){
					Damageable target = r.gameObject.GetComponentInParent(typeof(Damageable)) as Damageable;
					if(target==null){
						continue;
					}
					if(target is Player && ((Player)target).holder==otherPlayer){
						if(attacker!=null){
							attacker.viz.outline.SetActive(false);
							attacker.state = CardInstance.State.Tired;
							resolveCombat.Battle(attacker,(Player)target);
							attacker=null;
						}
					}
					else if(target is CardInstance){
						CardInstance card = (CardInstance)target;
						if(currentPlayer.downCards.Contains(card)){
							if(card.CanAttack()){
								if(attacker!=null){						//if we already have an attacker disable it
									attacker.state = CardInstance.State.Idle;
									attacker.viz.outline.SetActive(false);
									if(attacker==card){
										attacker=null;
										continue;
									}
								}
								attacker = card;
								attacker.state = CardInstance.State.Attacking;
								attacker.viz.outline.SetActive(true);
							}
						}
						else if(otherPlayer.downCards.Contains(card)){
							if(attacker!=null){
								attacker.viz.outline.SetActive(false);
								attacker.state = CardInstance.State.Attacking;
								resolveCombat.Battle(attacker,card);
								attacker=null;
							}
						}
					}
				}
			}
		}
	}
}
