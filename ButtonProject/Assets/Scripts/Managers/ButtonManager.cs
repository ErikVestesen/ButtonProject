using System.Collections; 
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonManager : MonoBehaviour
{
    [SerializeField]
    private Button _btnMain, _btnRandom;

    [SerializeField]
    private Image _imgMainButton, _imgRandomButton;

    [SerializeField]
    private TextMeshProUGUI _txtInputTimer, _txtMainTimer; 

    private int _timesClicked = 0;

    private float _lastInputTime = 0f;
    private float _mainInputTime = 0f;

    private readonly float _lastInputTimeDefault = 5f;
    private readonly float _mainInputTimeDefault = 2f;

    private bool CoroutineIsRunningMainClick = false;
    private bool CoroutineIsRunningInputTimer = false;

    void Awake()
    {           
        //Default to green
        ChangeColor(_imgMainButton, Color.green);

        //Remove other onclicks
        _btnMain.onClick.RemoveAllListeners();
        _btnRandom.onClick.RemoveAllListeners();

        //Add onclick 
        _btnMain.onClick.AddListener(delegate { ClickMainButton(); });
        _btnRandom.onClick.AddListener(delegate { ClickRandomButton(); });

    } 

    #region OnClicks

    private void ClickMainButton()
    {
        //Increment
        _timesClicked++;

        //Determine Color
        Color color = DetermineColorByClicks(_timesClicked);

        //Set Color
        ChangeColor(_imgMainButton, color);

        //Reset last input
        _lastInputTime = _lastInputTimeDefault;

        //Play Click Sound
        SoundManager.Instance.PlayClickSound();

        //Animate Button
        StartCoroutine(AnimationManager.Instance.BounceGOUnscaled(_btnMain.gameObject));

        //Start Coroutine timers
        if (!CoroutineIsRunningInputTimer)
            StartCoroutine(StartInputTimer());

        if(!CoroutineIsRunningMainClick)
            StartCoroutine(StartMainTimer());
    }

    private void ClickRandomButton()
    {
        //Generate Random Color
        Color color = GenerateRandomColor();
         
        //Play Click Sound
        SoundManager.Instance.PlayClickSound();

        //Animate Button
        StartCoroutine(AnimationManager.Instance.BounceGOUnscaled(_btnRandom.gameObject));

        //Apply Random color to button image
        ChangeColor(_imgRandomButton, color);
    }

    #endregion

    #region Coroutines

    private IEnumerator StartMainTimer()
    { 
        CoroutineIsRunningMainClick = true;

        _mainInputTime = _mainInputTimeDefault;

        while (_mainInputTime > 0f)
        {
            //Continue timer
            _mainInputTime -= Time.unscaledDeltaTime;

            //Update text
            _txtMainTimer.text = _mainInputTime.ToString("0.00");

            yield return new WaitForEndOfFrame();
        }

        //Update text
        if(_mainInputTime < 0f)
        {
            _mainInputTime = 0f;
            _txtMainTimer.text = _mainInputTime.ToString("0.00");
        } 

        //Reset Fields
        _timesClicked = 0;

        CoroutineIsRunningMainClick = false;
    }

    private IEnumerator StartInputTimer()
    {
        CoroutineIsRunningInputTimer = true;

        while (_lastInputTime > 0f)
        {
            //Substract time
            _lastInputTime -= Time.unscaledDeltaTime;

            //Update Text
            _txtInputTimer.text = _lastInputTime.ToString("0.00");

            yield return new WaitForEndOfFrame();
        }

        //Update text
        if (_lastInputTime < 0f)
        {
            _lastInputTime = 0f;
            _txtInputTimer.text = _lastInputTime.ToString("0.00");
        }

        //Reset Color
        ChangeColor(_imgMainButton, Color.green);

        CoroutineIsRunningInputTimer = false;
    }

    #endregion

    #region Colors

    private void ChangeColor(Image image, Color color)
    {
        image.color = color;
    }

    private Color DetermineColorByClicks(int timesClicked)
    {
        switch(timesClicked)
        {
            case 1:
                return Color.blue;

            case int n when timesClicked > 1 && timesClicked < 5:
                return Color.red;

            case int n when timesClicked >= 5: 
                return new Color(0.56f,0.07f,0.7f);

            default:
                return Color.green;

        } 
    }

    private Color GenerateRandomColor()
    {
        float r = Random.Range(0f, 1f);
        float g = Random.Range(0f, 1f);
        float b = Random.Range(0f, 1f);  

        return new Color(r,g,b); 
    }

    #endregion

}



