/*
 * This code written by me, SlushyRH (https://github.com/SlushyRH), and all copyright goes to me.
 * The license for this code is at https://github.com/SlushyRH/Advanced-Save-System/blob/master/LICENSE.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SRH
{
    public class SPP_Demo : MonoBehaviour
    {
        private enum PlayerStatus
        {
            WINNING,
            LOSING,
            DRAWING
        }

        private int score = 5;
        private float highscore = 5;
        private string playerName = "slushy";
        private bool hasFinished = true;
        private char randomLetter = 'a';
        private double averageWinsRatio = 2.2;
        private PlayerStatus status = PlayerStatus.DRAWING;
        private Vector2 position2D = new Vector2(2, 4);
        private Vector3 position3D = new Vector3(4, 5, 6);
        private Quaternion rotationQuaternion = new Quaternion(2, 6, 5, 2);
        private Color color = Color.blue;
        private List<int> scores = new List<int>();
        private int[] ids = new int[4];

        public bool encrypt = false;
        [Space]
        public Text scoreText;
        public Text highscoreText;
        public Text finishedText;
        public Text playerNameText;
        public Text randomLetterText;
        public Text averageWinsText;
        public Text statusText;
        public Text position2dText;
        public Text position3dText;
        public Text quaternionText;
        public Text colorText;
        public Text scoresText;
        public Text idsText;

        private void Start()
        {
            scoreText.text = $"Score:";
            highscoreText.text = $"Highscore:";
            finishedText.text = $"Finished:";
            playerNameText.text = $"Player Name:";
            randomLetterText.text = $"Random Letter:";
            averageWinsText.text = $"Average Wins:";
            statusText.text = $"Status:";
            position2dText.text = $"Position 2D:";
            position3dText.text = $"Position 3D:";
            quaternionText.text = $"Quaternion:";
            colorText.text = $"Color:";
            scoresText.text = $"Scores:";
            idsText.text = $"Ids:";
        }

        public void Set()
        {
            if (!encrypt)
            {
                SPP.Set("score", score);
                SPP.Set("highscore", highscore);
                SPP.Set("playerName", playerName);
                SPP.Set("hasFinished", hasFinished);
                SPP.Set("randomLetter", randomLetter);
                SPP.Set("averageWinsRatio", averageWinsRatio);
                SPP.Set("status", status);
                SPP.Set("position2D", position2D);
                SPP.Set("position3D", position3D);
                SPP.Set("rotationQuaternion", rotationQuaternion);
                SPP.Set("color", color);
                SPP.Set("scores", scores);
                SPP.Set("ids", ids);
            }
            else
            {
                SPP.SetEncrypted("score", score);
                SPP.SetEncrypted("highscore", highscore);
                SPP.SetEncrypted("playerName", playerName);
                SPP.SetEncrypted("hasFinished", hasFinished);
                SPP.SetEncrypted("randomLetter", randomLetter);
                SPP.SetEncrypted("averageWinsRatio", averageWinsRatio);
                SPP.SetEncrypted("status", status);
                SPP.SetEncrypted("position2D", position2D);
                SPP.SetEncrypted("position3D", position3D);
                SPP.SetEncrypted("rotationQuaternion", rotationQuaternion);
                SPP.SetEncrypted("color", color);
                SPP.SetEncrypted("scores", scores);
                SPP.SetEncrypted("ids", ids);
            }

            SetText();
        }

        public void Get()
        {
            score = SPP.Get<int>("score");
            highscore = SPP.Get<float>("highscore");
            playerName = SPP.Get<string>("playerName");
            hasFinished = SPP.Get<bool>("hasFinished");
            averageWinsRatio = SPP.Get<double>("averageWinsRatio");
            status = SPP.Get<PlayerStatus>("status");
            position2D = SPP.Get<Vector2>("position2D");
            position3D = SPP.Get<Vector3>("position3D");
            rotationQuaternion = SPP.Get<Quaternion>("rotationQuaternion");
            color = SPP.Get<Color>("color");
            scores = SPP.Get<List<int>>("scores");
            ids = SPP.Get<int[]>("ids");

            SetText();
        }

        public void GenerateRandomData()
        {
            char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            scores = new List<int>();
            ids = new int[8];

            score = Random.Range(1, 30);
            highscore = Random.Range(1f, 30f);
            hasFinished = System.Convert.ToBoolean(Random.Range(0, 2));
            randomLetter = letters[Random.Range(0, letters.Length - 1)];
            averageWinsRatio = Random.Range(1, 30);
            status = (PlayerStatus)Random.Range(1, 30);
            position2D.x = Random.Range(1, 5);
            position2D.y = Random.Range(1, 5);
            position3D.x = Random.Range(1, 5);
            position3D.y = Random.Range(1, 5);
            position3D.z = Random.Range(1, 5);
            rotationQuaternion.x = Random.Range(1, 5);
            rotationQuaternion.y = Random.Range(1, 5);
            rotationQuaternion.z = Random.Range(1, 5);

            color.r = Random.Range(1, 255);
            color.g = Random.Range(1, 255);
            color.b = Random.Range(1, 255);

            playerName = "";
            for (int i = 0; i < 8; i++)
            {
                playerName += letters[Random.Range(0, letters.Length - 1)];
            }

            for (int i = 0; i < 8; i++)
            {
                scores.Add(Random.Range(1, 10));
                ids[i] = Random.Range(1, 10);
            }

            SetText();
        }

        private void SetText()
        {
            scoreText.text = $"Score: {score}";
            highscoreText.text = $"Highscore: {highscore}";
            finishedText.text = $"Finished: {hasFinished}";
            playerNameText.text = $"Player Name: {playerName}";
            randomLetterText.text = $"Random Letter: {randomLetter}";
            averageWinsText.text = $"Average Wins: {averageWinsRatio}";
            statusText.text = $"Status: {status.ToString()}";
            position2dText.text = $"Position 2D: {position2D}";
            position3dText.text = $"Position 3D: {position3D}";
            quaternionText.text = $"Quaternion: {rotationQuaternion.ToString()}";
            colorText.text = $"Color: {color.ToString()}";
            scoresText.text = $"Scores: {string.Join(",", scores)}";
            idsText.text = $"Ids: {string.Join(",", ids)}";
        }
    }
}
