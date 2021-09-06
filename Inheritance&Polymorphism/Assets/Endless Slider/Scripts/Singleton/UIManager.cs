using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 基底クラス Singleton<T>から派生したクラス
/// </summary>

namespace EndlessRunner
{
    [AddComponentMenu("CUSTOM / UI Manager")]
    public class UIManager : Singleton<UIManager>
    {
        [SerializeField]
        private Text m_textCurrentScore;
        [SerializeField]
        private Text m_textFinalScore;
        [SerializeField]
        private Text m_textBestScore;
        [SerializeField]
        private Button m_buttonPlay;

        void Start()
        {
            m_buttonPlay.onClick.AddListener(RestartGame);
        }


        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                Application.Quit();
        }


        public static void UpdateCurrentScore(int currentScore)
        {
            Instance.m_textCurrentScore.text = string.Format("SCORE: {0}", currentScore);
        }

        public static void UpdateResultScores(int finalScore, int bestScore)
        {
            Instance.m_textFinalScore.text = string.Format("FINAL SCORE: {0}", finalScore);

            Instance.m_textBestScore.text = string.Format("BEST SCORE: {0}", bestScore);
        }

        private void RestartGame()
        {
            SoundManager.PlaySoundEffect("ClickButton");

            ScreenFade.Close();

            GlobalVariables.Player.Reload();
        }
    }
}