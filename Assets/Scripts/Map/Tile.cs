using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    int unLoad = 0;//�s���Ă��Ȃ��ʘH���������邩
    Tile[] unLoadList = new Tile[4];//�s���Ă��Ȃ��ʘH���擾�ł���悤��

    string tileHead = "w";//�^�C���̏��
    Head tileHeadEnum = Head.w;//�e�X�g�p��enum

    public string HeroOnTile(Head head)
    {
        tileHead = head.ToString();
        tileHeadEnum = head;

        return tileHead;
    }
}
