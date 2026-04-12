using System.Collections;
using UnityEngine;
using Zenject;

namespace Q17pD.PalmIsland
{
    public class SceneManager : MonoBehaviour
    {
        public void LoadScene(int index) { UnityEngine.SceneManagement.SceneManager.LoadScene(index); }
        public void LoadSceneDelay(int index, float delay) { StartCoroutine(LoadSceneCoroutine(index, delay)); }
        private IEnumerator LoadSceneCoroutine(int index, float delay)
        {
            yield return new WaitForSeconds(delay);
            UnityEngine.SceneManagement.SceneManager.LoadScene(index);
        }
    }
}
