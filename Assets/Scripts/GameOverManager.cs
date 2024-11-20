using UnityEngine;
public class GameOverManager : MonoBehaviour{//manager
    public void GameOver(){
        Time.timeScale = 0f; // Pauses the game
    }
}