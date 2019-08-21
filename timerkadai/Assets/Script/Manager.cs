using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
	[SerializeField]
	private Recode recode;

    /// <summary>
    /// 目標時間
    /// </summary>
	[SerializeField]
	private float targetTime = 10;

	[SerializeField]
	private Text view;

    void Start()
    {
		winnerView();
	}


    /// <summary>
    /// 判定
    /// </summary>
    /// <param name="time"></param>
	public void Result(string time)
    {
		if (float.Parse(time) == targetTime)
		{
			if (recode != null)
			{
				recode.winnerCount++;
			}
		}

		winnerView();
	}

    /// <summary>
    /// 判定更新
    /// </summary>
    private void winnerView()
    {
		view.text = recode.winnerCount.ToString();
	}
}

public enum Timerstate
{
    start = 0,
	stop = 1,
	reset = 2,
}
