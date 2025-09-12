using UnityEngine.SceneManagement;
namespace CodeBase.Sevices
{
    public static class SceneLoadingService 
    {
        public static void LoadScene()
        {
            SceneManager.LoadScene("GameLoop");
        }
    }
}