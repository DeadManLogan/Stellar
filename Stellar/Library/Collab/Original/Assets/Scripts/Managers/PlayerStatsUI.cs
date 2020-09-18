using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//This one holds all the UI elements for the player.
// Has a method


namespace Stellar{
	public class PlayerStatsUI : MonoBehaviour
	{
		public PlayerHolder player;
		public Image playerPortrait;
		public Text health;
		public Text username;
		public Image level1;
		public Image level2;
		public Image level3;
		public GameObject gameOver;
		public Text gameOverText;

		public void UpdateAll(){
			UpdateUsername();
			UpdateHealth();

		}
		public void UpdateUsername(){
			username.text = player.username;
			playerPortrait.sprite =  player.portrait;
		}

		public void UpdateHealth(){
			health.text = player.health.ToString();
			// enable the game over ui
			if (player.health <= 0 && player.username == "JohnStyl2"){
				gameOver.SetActive(true);
				gameOverText.text = "Victory";
			}
			else if(player.health <= 0 && player.username == "JohnStyl"){
				gameOver.SetActive(true);
				gameOverText.text = "Victory";
			}
		}

		public void LevelUp(){
			if(!level2.gameObject.activeSelf){
				level2.gameObject.SetActive(true);
			}
			else{
				level3.gameObject.SetActive(true);
			}
		}

	}
}
