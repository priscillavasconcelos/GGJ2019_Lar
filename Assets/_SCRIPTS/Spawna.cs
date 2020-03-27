using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawna : MonoBehaviour
{
    public List<GameObject> objsSpawn1;
    public List<GameObject> objsSpawn2;
    public List<GameObject> objsSpawn3;
    public List<GameObject> objsSpawn4;
    public List<GameObject> objsSpawn5;
    public List<Transform> pos;
    public Transform grid;
    float distancia, tempoInicial;
    Vector3 posicaoInicial, posicaoFinal;
    public float velocidade;
    public AudioSource musica;
    public PlayerScript player;

    // Use this for initialization
    void Start ()
    {
        InvokeRepeating("Spawnando1", 2f, 0.7f);
        //InvokeRepeating("MoveGrid", 30f, 30f);
        InvokeRepeating("VerificaTempo", 1f, 1f);
        StartCoroutine(WaitForSound());
    }

    IEnumerator WaitForSound()
    {
        //Wait Until Sound has finished playing
        while (musica.isPlaying)
        {
            yield return null;
        }

        //Auidio has finished playing, disable GameObject
        player.HappyEnd();
    }

    private void VerificaTempo()
    {
        int tempo = (int)musica.time;
        if (!player.over)
        {
            if (tempo == 112)
            {
                MoveGrid();
                player.ChangeHeart();
                CancelInvoke("Spawnando4");
                InvokeRepeating("Spawnando5", 5f, 0.3f);
            }
            else if (tempo == 90)
            {
                MoveGrid();
                player.ChangeHeart();
                CancelInvoke("Spawnando3");
                InvokeRepeating("Spawnando4", 2f, 0.5f);
            }
            else if (tempo == 62)
            {
                MoveGrid();
                player.ChangeHeart();
                CancelInvoke("Spawnando2");
                InvokeRepeating("Spawnando3", 2f, 0.5f);
            }
            else if (tempo == 32)
            {
                MoveGrid();
                player.ChangeHeart();
                CancelInvoke("Spawnando1");
                InvokeRepeating("Spawnando2", 2f, 0.5f);
            }
        }

    }

    void Spawnando1()
    {
        int p = Random.Range(0, objsSpawn1.Count);
        int p2 = Random.Range(0, pos.Count);
        Instantiate(objsSpawn1[p], pos[p2].position, Quaternion.identity);
    }
    void Spawnando2()
    {
        int p = Random.Range(0, objsSpawn2.Count);
        int p2 = Random.Range(0, pos.Count);
        Instantiate(objsSpawn2[p], pos[p2].position, Quaternion.identity);
    }

    void Spawnando3()
    {
        int p = Random.Range(0, objsSpawn3.Count);
        int p2 = Random.Range(0, pos.Count);
        Instantiate(objsSpawn3[p], pos[p2].position, Quaternion.identity);
    }
    void Spawnando4()
    {
        int p = Random.Range(0, objsSpawn4.Count);
        int p2 = Random.Range(0, pos.Count);
        Instantiate(objsSpawn4[p], pos[p2].position, Quaternion.identity);
    }
    void Spawnando5()
    {
        int p = Random.Range(0, objsSpawn5.Count);
        int p2 = Random.Range(0, pos.Count);
        Instantiate(objsSpawn5[p], pos[p2].position, Quaternion.identity);
    }

    void MoveGrid()
    {
        if (!player.over)
        {
            tempoInicial = Time.time;
            posicaoInicial = grid.position;
            posicaoFinal = new Vector3(grid.position.x - 21f, grid.position.y, grid.position.z);
            distancia = Vector2.Distance(posicaoInicial, posicaoFinal);
            StartCoroutine(Movement());
        }

    }

    IEnumerator Movement()
    {
        float percorrida = (Time.time - tempoInicial) * velocidade;
        float frac = percorrida / distancia;
        while (percorrida < distancia)
        {
            percorrida = (Time.time - tempoInicial) * velocidade;
            frac = percorrida / distancia;
            grid.position = Vector2.Lerp(posicaoInicial, posicaoFinal, frac);
            yield return new WaitForEndOfFrame();
        }

    }
}
