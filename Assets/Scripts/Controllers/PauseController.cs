using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
public void EnablePause(bool value)
    {
        if (value)
            Time.timeScale = 0f;
        else Time.timeScale = 1f;
    }
}
