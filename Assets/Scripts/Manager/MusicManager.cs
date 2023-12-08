using System.Collections;
using System.Collections.Generic;
using Ring;
using UnityEngine;

public class MusicManager : RingSingleton<MusicManager>
{
    [HeaderTextColor(.55f, .55f, .55f, headerText = "Music")]
    public MusicController _musicController;
    private void Start()
    {
        PlayerBackGround();
    }

    public void PlayAudio_Attack()
    {
        _musicController.audioSource_.PlayOneShot(_musicController.audioClip_Attack);
    }
    public void PlayAudio_Die()
    {
        _musicController.audioSource_.PlayOneShot(_musicController.audioClip_Die);
    }
    public void PlayerBackGround()
    {
        //_musicController.audioSource_BackGround.Play();
    }
}
