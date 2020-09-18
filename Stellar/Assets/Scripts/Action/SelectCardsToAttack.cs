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
				GameManager gm = GameManager.singleton;
				PlayerHolder currentPlayer = gm.currentPlayer;
				PlayerHolder[] all_players = gm.all_players;
				PlayerHolder otherPlayer = gm.GetEnemyOf(currentPlayer);

				foreach (RaycastResult r in results){
					Damageable target = r.gameObject.GetComponentInParent(typeof(Damageable)) as Damageable;
					PlayerStatsUI target2 = r.gameObject.GetComponentInParent(typeof(PlayerStatsUI)) as PlayerStatsUI;
					if(target==null){
						continue;
					}
					if(target is Player && target2.player == otherPlayer){
						if(attacker!=null){
							attacker.viz.outline.SetActive(false);
							attacker.state = CardInstance.State.Tired;
							//resolveCombat.Battle(attacker,(Player)target);
							otherPlayer.Damage(attacker.GetAttack());
							Debug.Log(attacker);
							Debug.Log(target);
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
