using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TerminalController : MonoBehaviour
{
    {

    private void PopUpWindow()
            && !String.Equals(Manager.collectionStrArr[leftIndex], "EMPTY")
            && !String.Equals(Manager.collectionStrArr[leftIndex + 1], "EMPTY"))
            combineButton.interactable = true;
        }
        {
            // Deactivate button
            combineButton.interactable = false;
        }

    private void AddTextToCollection()
        Manager.AddToCollection(serialNo, centerText);
    }
}