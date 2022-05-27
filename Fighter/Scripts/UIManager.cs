using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Image vidaPlayer;
    public Image vidaEnemy;

    public GameManager gameManager;

    private float vidaActualPlayer;
    private float vidaMaximaPlayer;
    private float vidaActualEnemy;
    private float vidaMaximaEnemy;

    void Update()
    {
        VidaUpdatePlayer();
        VidaUpdateEnemy();
        ActualizarBarraVidaPlayer();
        ActualizarBarraVidaEnemy();

    }

    private void VidaUpdatePlayer()
    {
        float numeroVidasHero = gameManager.NumeroVidasHero;
        vidaActualPlayer = numeroVidasHero;
        vidaMaximaPlayer = 10;
    }
    private void VidaUpdateEnemy()
    {
        vidaActualEnemy = gameManager.NumeroVidasEnemy;
        vidaMaximaEnemy = 10;
    }
    private void ActualizarBarraVidaPlayer()
    {
        vidaPlayer.fillAmount = Mathf.Lerp(vidaPlayer.fillAmount,vidaActualPlayer/vidaMaximaPlayer,1 * Time.deltaTime);
    }
    private void ActualizarBarraVidaEnemy()
    {
        vidaEnemy.fillAmount = Mathf.Lerp(vidaEnemy.fillAmount, vidaActualEnemy / vidaMaximaEnemy, 1 * Time.deltaTime);
    }
}
