using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour {

    public List<Quest> _listQuest;
    public List<Quest> _listSecQuest;
    public List<Quest> _listInvisbleQuest;

    public void AddSideQuest()
    {

    }

    public void RemoveSideQuest()
    {

    }

    public void AddQuest(int questID)
    {
        for(int i = 0; i < _listQuest.Count; i++)
        {
            if(_listQuest[i].ID == questID)
            {

            }
        }
    }

    public void RemoveQuest()
    {

    }

    public void AddReward()
    {

    }

    void Update ()
    {
		
	}
}
