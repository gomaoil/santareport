using UnityEngine;

public class App {
    [RuntimeInitializeOnLoadMethod]
    static void OnRuntimeMethodLoad()
    {
        // 入力ファイルはAssets/Resources/Json/GimmickDataList
        // input.jsonをテキストファイルとして読み取り、string型で受け取る
        TextAsset textAsset = Resources.Load<TextAsset>("Json/GimmickDataList");
        Debug.Assert(textAsset != null);
        string inputString = textAsset.ToString();
        // 上で作成したクラスへデシリアライズ
        GimmickDataList.Instance = JsonUtility.FromJson<GimmickDataList>(inputString);

        // string kindList = "";
        // foreach (var each in GimmickDataList.Instance.DataList)
        // {
        //     kindList += $"{each.name},\n";
        // }
        // Debug.Log($"{kindList}");
    }
}