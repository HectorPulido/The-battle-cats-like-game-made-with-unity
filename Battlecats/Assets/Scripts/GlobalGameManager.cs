using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalGameManager : MonoBehaviour {

	public static GlobalGameManager singleton;

	public List<Troop> sellingCats = new List<Troop>();

	public List<Troop> allyTroops = new List<Troop>();
	public List<Troop> enemyTroops = new List<Troop>();


	public int score;

	void Awake () 
	{
		if (singleton != null) {
			Destroy (this);
			return;		
		}
		singleton = this;
		DontDestroyOnLoad (singleton);

		SceneManager.sceneLoaded += SceneLoaded	;
	}

	void SceneLoaded(Scene scene, LoadSceneMode lsc)
	{
		if (scene.name == "Menu") {
		
		
		} else if(scene.name == "Battle"){
			var bm = GameObject.FindObjectOfType<BattleManager>();
			bm.Init(enemyTroops.ToArray(),allyTroops.ToArray());
		}
	}

	public void GoToScene(string sceneToGo)
	{
		SceneManager.LoadScene (sceneToGo);

	}

}
