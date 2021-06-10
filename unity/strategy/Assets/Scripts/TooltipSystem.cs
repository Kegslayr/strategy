using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipSystem : MonoBehaviour
{
    private static TooltipSystem _instance;
    public TooltipDialog TooltipDlg;

    private void Awake()
    {
        _instance = this;
    }

    public static void Show(string header, string description, string content)
    {
        _instance.TooltipDlg.SetTooltip(header, description, content);
        _instance.TooltipDlg.gameObject.SetActive(true);
    }

    public static void Hide()
    {
        _instance.TooltipDlg.gameObject.SetActive(false);
    }
}
