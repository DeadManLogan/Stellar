using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Stellar.GameStates;

namespace Stellar{
	public class GameManager : MonoBehaviour{


		[System.NonSerialized]
		public PlayerHolder[] all_players;
		public GameState currentState;
		public PlayerHolder currentPlayer;
		
		public CardHolders playerOneHolder;
		public CardHolders otherPlayersHolder;

		public GameObject cardPrefab;
		
		public int turnIndex;
		public Turn[] turns;
		public SO.GameEvent onTurnChanged;
		public SO.StringVariable turnText;

		public PlayerStatsUI[] statsUI;

		public static GameManager singleton;

		public GameObject highlightedCard;

		public PlayerAction drawOneCard;		// Game manager needs a reference to the draw one card PlayerAction to give starting cards to players

		private IEnumerator coroutine;

		private void Awake(){
			singleton = this;

			all_players = new PlayerHolder[turns.Length];
			for(int i =0; i< turns.Length; i++){
				all_players[i] = turns[i].player;
			}
			currentPlayer = turns[0].player;
			currentState = turns[0].myTurnState;
		}

		private void Start(){
			Settings.gameManager = this;
		
			SetupPlayers();

			turnText.value = turns[turnIndex].player.username;
			onTurnChanged.Raise();

			// coroutine for drawing cards
			coroutine = CreateStartingCards(0.5f);
			StartCoroutine(coroutine);
		}

		void SetupPlayers(){
			for(int i=0; i< all_players.Length; i++){
				// if(all_players[i].isHumanPlayer){
				// 	all_players[i].currentHolder = playerOneHolder;
				// }
				// else{
				// 	all_players[i].currentHolder = otherPlayersHolder;
				// }
				// if(i<2){
				// 	all_players[i].health=25;
				// 	all_players[i].statsUI = statsUI[i];
				// 	statsUI[i].player.LoadPlayerOnStatsUI();
				// }

				if( i == 0){
					all_players[i].currentHolder = playerOneHolder;
				}
				else{
					all_players[i].currentHolder = otherPlayersHolder;
				}
				if(i<2){
					all_players[i].health=25;
					all_players[i].statsUI = statsUI[i];
					statsUI[i].player.LoadPlayerOnStatsUI();
				}

				
				all_players[i].deck = new List<string>(all_players[i].startingDeck);
				all_players[i].shuffleDeck();
			}
		}

		public IEnumerator CreateStartingCards(float waitTime){
			for(int p=0; p<all_players.Length; p++){
				for(int i=0;i<4;i++){				// draw 4 cards
					drawOneCard.Execute(all_players[p]);
					yield return new WaitForSeconds(waitTime);
				}
				all_players[p].currentHolder.LoadPlayer(all_players[p], all_players[p].statsUI);
			}
		}

		public void LoadPlayerOnActive(PlayerHolder p){
			if (playerOneHolder.playerHolder != p){
				PlayerHolder prevPlayer = playerOneHolder.playerHolder;
				LoadPlayerOnHolder(prevPlayer, otherPlayersHolder, statsUI[1]);
				LoadPlayerOnHolder(p, playerOneHolder, statsUI[0]);
			}
		}

		public void LoadPlayerOnHolder(PlayerHolder p, CardHolders h, PlayerStatsUI ui){
			h.LoadPlayer(p, ui);
		}

		private void Update(){

			bool isComplete = turns[turnIndex].forceExit;
			if(isComplete){
				turns[turnIndex].forceExit = false;
				//Debug.Log("Turn is complete");
				//Settings.RegisterEvent(turns[turnIndex].name + " finished", currentPlayer.playerColor);
				turnIndex++;
				if(turnIndex > turns.Length -1){
					turnIndex = 0;
				}
				currentPlayer = turns[turnIndex].player;
				turns[turnIndex].OnTurnStart();
				turns[turnIndex].player.cardsPlayedThisTurn = 0;
				turnText.value = turns[turnIndex].player.username;
				onTurnChanged.Raise();

			}
			if(currentState!= null)
				currentState.Tick(Time.deltaTime);
		}

		public void SetState(GameState state){
			
			currentState = state;
			//Debug.Log(currentState);
		}

		public void EndTurn(){
			turns[turnIndex].EndTurn();
		}

		public PlayerHolder GetEnemyOf(PlayerHolder p){
			if(p==all_players[0]){
				return all_players[1];
			}
			else{
				return all_players[0];
			}
		}
			
	}
}
