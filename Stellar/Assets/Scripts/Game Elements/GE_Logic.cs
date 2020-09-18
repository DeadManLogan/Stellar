using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Stellar.GameElements{
	public abstract class GE_Logic : ScriptableObject
	{
   		public abstract void OnClick(CardInstance instance);
		
		public abstract void OnHighlight(CardInstance instance);
		
	}
}
