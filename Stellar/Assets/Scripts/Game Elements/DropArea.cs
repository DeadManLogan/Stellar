using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Stellar.GameElements{
	public class DropArea : MonoBehaviour{

		public CardVariable card;
		public SO.TransformVariable areaGrid;
		public GameElements.GE_Logic cardDownLogic;

		public void OnDrop(){
			
			if(card.value == null)
				return;

			Card c = card.value.viz.card;

			if(c.cardType is CreatureCard){
				bool canUse = Settings.gameManager.currentPlayer.CanUseCard(c);

				if(canUse){
					Settings.DropCreatureCard(card.value.transform,areaGrid.value.transform,card.value);
					card.value.currentLogic = cardDownLogic;
					PlayerHolder currentPlayer = Settings.gameManager.currentPlayer;
					currentPlayer.cardsPlayedThisTurn++;
					currentPlayer.cardsPlayedThisLevel++;
					if(currentPlayer.cardsPlayedThisLevel==2){
						currentPlayer.statsUI.LevelUp();
					}

					Sound.PlaySound("greeting_1");
				}
				card.value.gameObject.SetActive(true);

			}
		}

	}
}
