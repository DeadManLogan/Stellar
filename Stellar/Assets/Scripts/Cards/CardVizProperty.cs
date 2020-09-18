using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


//a GameObject property on a card.

namespace Stellar{

	[System.Serializable]
	public class CardVizProperty
	{
		public TextMeshProUGUI text;
		public Image image; 
		public Element element;
	}
}
