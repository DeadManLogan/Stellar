using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stellar{
	[CreateAssetMenu(menuName = "Actions/Player Actions/Draw Card")]
	public class DrawCard : PlayerAction
	{
		public override void Execute(PlayerHolder player){
			if(player.deck.Count>0){
				ResourcesManager rm = Settings.GetResourcesManager();
				GameObject go = Instantiate(GameManager.singleton.cardPrefab) as GameObject;
				CardViz v = go.GetComponent<CardViz>();
				v.LoadCard(rm.GetCardInstance(player.deck[0]));		//draw the first card
				player.deck.RemoveAt(0);							//remove the first card
				CardInstance inst = go.GetComponent<CardInstance>();
				inst.currentLogic = player.handLogic;
				Settings.SetParentForCard(go.transform,player.currentHolder.handGrid.value);
				player.handCards.Add(inst);
				Sound.PlaySound("draw_card");
			}
		}
	}
}



