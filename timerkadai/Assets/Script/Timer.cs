using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
	[SerializeField]
	private Text result;
	[SerializeField]
	private Button button;
	[SerializeField]
	private Manager manager;

    /// <summary>
    /// カウンター
    /// </summary>
	private float counter;
	private float preTime;
	private Timerstate state = Timerstate.start;
	// Start is called before the first frame update
	void Start()
	{
        if(button != null)
        {
            //ボタン押下イベントにタイマー切り替え処理を登録
			button.onClick.AddListener(TimerSwitch);
		}

	}

	// Update is called once per frame
	void Update()
	{
        if(state == Timerstate.stop)
        {
			counter += Time.realtimeSinceStartup - preTime;
    		preTime = Time.realtimeSinceStartup;
		}

	}

    /// <summary>
    /// タイマー切り替え
    /// </summary>
    void TimerSwitch()
    {
		var text = button.gameObject.GetComponentInChildren<Text>();

        switch(state)
        {

            case Timerstate.start:
    		    text.text = "Stop";
			    result.text = "????";
			    preTime = Time.realtimeSinceStartup;
				break;
			case Timerstate.stop:
				text.text = "Reset";
				result.text = string.Format("{0:00.#}", counter);
				break;
			case Timerstate.reset:
				text.text = "Start";
				counter = 0;
				manager.Result(result.text);
				result.text = "0:0";
				break;
		}

		state = (Timerstate)((int)(state+1) % 3);

	}
}
