using System;
using System.Collections.Generic;
using UnityEngine;

namespace KerbalStats
{
	class StatsModel 
	{
		private List<KSKerbal> kerbals;

		public StatsModel() {
			//load our kerbals
			this.kerbals = SaveManager.LoadKerbals();
			if(kerbals == null) {
				Debug.Log("Checking CurrentGame");
				if(HighLogic.CurrentGame != null) {
					Debug.Log("Creating kerbals");
					CreateKerbals();
				} else {
					Debug.Log("CurrentGame null");
				}
			}
		}

		/**
		 * Create a KSKerbal for all the kerbals in our current game, then save them
		 */
		private void CreateKerbals() {
			this.kerbals = new List<KSKerbal>();
			Debug.Log("Looping through crew");
			foreach (ProtoCrewMember kerbal in HighLogic.CurrentGame.CrewRoster) {
				this.kerbals.Add(new KSKerbal(kerbal));
			}
			SaveManager.SaveKerbals(this.kerbals);
		}

		public List<KSKerbal> GetKerbals() {
			return this.kerbals;
		}

		public List<KSKerbal> GetKerbals(Vessel vessel) {
			return this.kerbals;
		}

		public KSKerbal GetKerbal(String name) {
			foreach(KSKerbal kerbal in kerbals) {
				if(kerbal.name == name) {
					return kerbal;
				}
			}
			return null;
		}
	}
}