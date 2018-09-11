using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Kapu.SaamiRunner
{
	public class SimpleSceneSwitch : MonoBehaviour
	{
		private static Stack<string> sceneStack;

		private void Awake()
		{
			if (sceneStack == null || sceneStack.Count == 0)
			{
				sceneStack = new Stack<string>();
				sceneStack.Push("s_Saami_Start");
			}
		}
		
		public void OpenRewardsScene()
		{
			sceneStack.Push(SceneManager.GetActiveScene().name);
			SceneManager.LoadScene("s_Saami_Rewards");
		}
		
		public void OpenStartScene()
		{
			sceneStack.Push(SceneManager.GetActiveScene().name);
			SceneManager.LoadScene("s_Saami_Start");
		}

		public void OpenGameplayScene()
		{
			sceneStack.Push(SceneManager.GetActiveScene().name);
			SceneManager.LoadScene("s_Saami_Gameplay");
		}
//		public void OpenGameplayScene2()
//		{
//			sceneStack.Push(SceneManager.GetActiveScene().name);
//			SceneManager.LoadScene("s_Saami_Gameplay_2");
//		}

		public void OpenPreviousScene()
		{
			var prevSceneName = sceneStack.Pop();
			SceneManager.LoadScene(prevSceneName);
		}
	}
}