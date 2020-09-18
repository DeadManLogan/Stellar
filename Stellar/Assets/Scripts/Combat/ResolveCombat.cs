using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Stellar{
	[CreateAssetMenu(menuName = "Combat/ResolveCombat")]
	public class ResolveCombat : ScriptableObject{

		public void Battle(CardInstance attacker,CardInstance target){
			// we're attacking a card
			CardElement attackersElement = attacker.viz.card.element;
			CardElement targetsElement = target.viz.card.element;

			int attackersAttack = attacker.GetAttack();
			int targetsAttack = target.GetAttack();

			if(attackersElement.Counters(targetsElement)){
				attackersAttack = attackersAttack + attacker.GetElementalPower();
			}
			else if(targetsElement.Counters(attackersElement)){
				targetsAttack = targetsAttack + target.GetElementalPower();
			}
			attacker.Damage(targetsAttack);
			target.Damage(attackersAttack);
		}
		public void Battle(CardInstance attacker,Player player){
			player.Damage(attacker.GetAttack());
		}
	}
}

