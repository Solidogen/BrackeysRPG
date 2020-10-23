using System;
using UnityEngine;

public static class UnityUtils
{

    public static void ToggleActive(this GameObject self)
    {
        self.SetActive(!self.activeSelf);
    }
}
