using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using  UnityEngine.UI;

public class MyEffect : MonoBehaviour,IPointerClickHandler
{

    [SerializeField] 
    private float cd=2;

    [SerializeField] 
    SKillSortEnnum sKillSort;
    
    private Image _mask;
    private Text _time;
    public void OnPointerClick(PointerEventData eventData)
    {
        USeSkill();
    }
 
    
    void USeSkill()
    {

        if (_mask.fillAmount != 0)
        {
            return;
        }
        StartCoroutine(UseSkillcor());
        playeffect.Instance.UseSkill(sKillSort);
    }

    IEnumerator UseSkillcor()
    {
        float workTime = 0;
        while (true)
        {
            workTime += Time.deltaTime;
            _mask.fillAmount = Mathf.Lerp(1, 0, workTime / cd);
            _time.text = (cd - workTime).ToString("f1");
            _time.color=Color.Lerp(Color.red, Color.green, workTime/cd);
            if (workTime>3)
            {
                playeffect.Instance.stop(sKillSort);
            }
            if (workTime/cd>=1)
            {
                _time.text = "";
                
                break;
                
            }
            
            
            yield return null;
        }
    }

    void Start()
    {
        _mask = transform.Find("Image").GetComponent<Image>();
        _time = transform.Find("Text").GetComponent<Text>();
    }
}