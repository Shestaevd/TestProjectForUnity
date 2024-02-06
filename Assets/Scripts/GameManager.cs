using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Player life")]
    [SerializeField] public PlayerHp Life;

    [Header("Enemy life")]
    [SerializeField] public EnemyHp EnemyLife;

    private void Update()
    {
        if (Life.IsOver() || EnemyLife.IsOver())
            SceneManager.LoadScene("Restart");
    }
}