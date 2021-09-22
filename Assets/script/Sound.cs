using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Sound : MonoBehaviour
{
    public AudioSource volume;
    public void AdjustVolume(Scrollbar volumebar)
    {
        volume.volume = volumebar.value;
    }
}
