using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    int unLoad = 0;//行っていない通路がいくつあるか
    Tile[] unLoadList = new Tile[4];//行っていない通路を取得できるように

    string tileHead = "w";//タイルの情報
    Head tileHeadEnum = Head.w;//テスト用のenum

    public string HeroOnTile(Head head)
    {
        tileHead = head.ToString();
        tileHeadEnum = head;

        return tileHead;
    }
}
