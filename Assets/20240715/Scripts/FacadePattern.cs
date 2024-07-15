using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Renderer
{
    public void Render()
    {
        
    }
}

public class AudioManager
{
    public void PlayAudio()
    {
        
    }
}

public class FacadePattern : MonoBehaviour
{
    private AudioManager _audioManager = new();
    private Renderer _renderer = new();
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnHit()
    {
        _audioManager.PlayAudio();
        _renderer.Render();
    }
}
