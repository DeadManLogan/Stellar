using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Stellar.GameElements;
using UnityEngine.UI;


namespace Stellar{
	[CreateAssetMenu(menuName = "Holders/Player Holder")]
	public class PlayerHolder : ScriptableObject
	{
		public string username;
		public Sprite portrait;
		public int playerLevel;
		public int health = 20;

		public PlayerStatsUI statsUI;

		public string[] startingDeck;

		[System.NonSerialized]
		public List<string> deck;

		
		public Color playerColor;

		[System.NonSerialized]
		public int cardsPlayedThisTurn;

		public bool isHumanPlayer;

		public GE_Logic handLogic;
		public GE_Logic downLogic;
		public GE_Logic enemyHandLogic;
	
		[System.NonSerialized]
		public CardHolders currentHolder;

		[System.NonSerialized]
		public List<CardInstance> handCards = new List<CardInstance>();
		[System.NonSerialized]
		public List<CardInstance> downCards = new List<CardInstance>();

		public bool CanUseCard(Card c){

			///statsUI.LevelUp();
			//Debug.Log("It leveled up?");
			if(cardsPlayedThisTurn>=1){
				Debug.Log("You've already played a card buddy");
				return false;		
			}
			if(playerLevel < c.cost){
				Debug.Log("This card is too strong for you buddy");
				return false;
			}

			return true;
		}

		
		public void shuffleDeck(){		//fisher-yates algorithm
			System.Random rnd = new System.Random();
			for(int i=deck.Count-1;i>0;i--){
				int index = rnd.Next(i+1);
				string last_card = deck[i];		
				deck[i] = deck[index];			//put random card at last position
				deck[index] = last_card;
			}
		}
		
		public void DropCard(CardInstance inst){
			if(handCards.Contains(inst)){
				handCards.Remove(inst);
			}
			downCards.Add(inst);

			Settings.RegisterEvent(username + " used " +inst.viz.card.name, Color.white);
		}

		public void LoadPlayerOnStatsUI(){
			if(statsUI != null){
				statsUI.player = this;
				statsUI.UpdateAll();
				
			}
		}

		public void DoDamage(int v){
			health -= v;
			if(statsUI != null)
				statsUI.UpdateHealth();
		}
	}
}
