using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBoard : MonoBehaviour
{
    public AudioSource InEarSource;
    public AudioClip NumKey1Track;
    public AudioClip NumKey2Track;
    public AudioClip NumKey3Track;
    public AudioClip NumKey4Track;
    public AudioClip NumKey5Track;
    public AudioClip NumKey6Track;
    public AudioClip NumKey7Track;
    public AudioClip NumKey8Track;
    public AudioClip NumKey9Track;
    public AudioClip NumKey0Track;

    private Dictionary<KeyCode, AudioClip> _keysToPlayOn;

    private void Start()
    {
        _keysToPlayOn = new Dictionary<KeyCode, AudioClip>();
        if (NumKey1Track != null) _keysToPlayOn.Add(KeyCode.Alpha1, NumKey1Track);
        if (NumKey2Track != null) _keysToPlayOn.Add(KeyCode.Alpha2, NumKey2Track);
        if (NumKey3Track != null) _keysToPlayOn.Add(KeyCode.Alpha3, NumKey3Track);
        if (NumKey4Track != null) _keysToPlayOn.Add(KeyCode.Alpha4, NumKey4Track);
        if (NumKey5Track != null) _keysToPlayOn.Add(KeyCode.Alpha5, NumKey5Track);
        if (NumKey6Track != null) _keysToPlayOn.Add(KeyCode.Alpha6, NumKey6Track);
        if (NumKey7Track != null) _keysToPlayOn.Add(KeyCode.Alpha7, NumKey7Track);
        if (NumKey8Track != null) _keysToPlayOn.Add(KeyCode.Alpha8, NumKey8Track);
        if (NumKey9Track != null) _keysToPlayOn.Add(KeyCode.Alpha9, NumKey9Track);
        if (NumKey0Track != null) _keysToPlayOn.Add(KeyCode.Alpha0, NumKey0Track);

        foreach(AudioClip clip in _keysToPlayOn.Values)
        {
            clip.LoadAudioData();
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach(KeyCode testKey in _keysToPlayOn.Keys)
        {
            if (Input.GetKeyDown(testKey))
                InEarSource.PlayOneShot(_keysToPlayOn[testKey], 1.0f);
        }
    }
}
