using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Script para manejar los niveles
    [SerializeField] private GameObject level_1;
    [SerializeField] private GameObject level_2;
    [SerializeField] private GameObject meta;
    [SerializeField] private int level;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch (level)
            {
                case 1:

                    Debug.Log("<color=purple>Nivel 1: </color> Supera las <color=magenta>plataformas</color> y esquiva los <color=magenta>obstaculos</color>");

                    level_1.SetActive(true);
                    level_2.SetActive(false);
                    meta.SetActive(false);

                    break;

                case 2:

                    Debug.Log("<color=purple>Nivel 2: </color> Lleva el <color=magenta>objeto</color> a su <color=magenta>lugar</color>");

                    level_1.SetActive(false);
                    level_2.SetActive(true);
                    meta.SetActive(false);

                    break;

                case 3:

                    Debug.Log("<color=green>FELICIDADES!!!</color>");

                    level_1.SetActive(false);
                    level_2.SetActive(false);
                    meta.SetActive(true);

                    break;
            }
        }
    }

}
