using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

	public class SimpleSceneSwitch : MonoBehaviour
	{

		public void OpenStartScene()
		{
			SceneManager.LoadScene("MainMenu-001");
		}

		public void OpenGameplayScene()
		{
			SceneManager.LoadScene("Gameplay-001");
		}
//		public void OpenGameplayScene2()
//		{
//			sceneStack.Push(SceneManager.GetActiveScene().name);
//			SceneManager.LoadScene("s_Saami_Gameplay_2");
//		}

/*		public void OpenPreviousScene()
		{
			SceneManager.LoadScene(prevSceneName);
		}*/

	}
