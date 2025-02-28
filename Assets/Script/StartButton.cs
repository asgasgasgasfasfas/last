using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    [SerializeField]
    public PlayerControl playerControl;
    [SerializeField]
    public PipeSpawer pipeSpawer;
    [SerializeField]
    public GameObject player;

    private void Awake()
    {
        player.SetActive(false);
        pipeSpawer.
    }
}
