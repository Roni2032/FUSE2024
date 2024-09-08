using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//----------------------------------------------------------------------------------------------------
// サウンドの管理と再生 
//----------------------------------------------------------------------------------------------------
public class SoundManager : MonoBehaviour
{
	//--------------------------------------------------------------------------------
	// SE定義  
	//--------------------------------------------------------------------------------
	public enum SE
	{
		GET_MONEY,	// お金の獲得
		SET_X,		// 回転バーの設置 
		TIMEUP,		// 時間切れ 
	}



	//--------------------------------------------------------------------------------
	// メンバ変数  
	//--------------------------------------------------------------------------------
	static SoundManager instance;   // シングルトンインスタンス 

	[SerializeField]AudioSource sourceBGM = null;
	[SerializeField]AudioSource sourceSFX = null;
	[SerializeField]AudioClip[] clips     = null;	// SE._NUM


	//--------------------------------------------------------------------------------
	// コンストラクタ 
	//--------------------------------------------------------------------------------
	void Awake()
	{
		// シングルトン作成 
		if(instance != null)
		{
			GameObject.Destroy(this.gameObject);
			return;
		}
		instance = this;

		// オーディオリスナーなかったらつける 
		AudioListener listener = GameObject.FindFirstObjectByType<AudioListener>();
		if(listener == null){ this.gameObject.AddComponent<AudioListener>(); }
	}

	//--------------------------------------------------------------------------------
	// インスタンスの確認  
	//--------------------------------------------------------------------------------
	static void CheckInstance()
	{
		if(instance == null){ Resources.Load("SoundManager"); }
	}

	//--------------------------------------------------------------------------------
	// BGM再生  
	//--------------------------------------------------------------------------------
	public static void PlayBGM()
	{
		CheckInstance();
		instance.sourceBGM.Play();
	}

	//--------------------------------------------------------------------------------
	// BGM停止  
	//--------------------------------------------------------------------------------
	public static void StopBGM()
	{
		CheckInstance();
		instance.sourceBGM.Stop();
	}

	//--------------------------------------------------------------------------------
	// 効果音再生 
	//--------------------------------------------------------------------------------
	public static void PlaySE(SE se)
	{
		CheckInstance();
		instance.sourceSFX.PlayOneShot(instance.clips[(int)se]);
	}

	/*/--------------------------------------------------------------------------------
	// DEBUG  
	//--------------------------------------------------------------------------------
	private void OnGUI()
	{
		if(GUILayout.Button("PLAY BGM"))
		{
			PlayBGM();
		}
		if(GUILayout.Button("STOP BGM"))
		{
			StopBGM();
		}
		if(GUILayout.Button("PLAY SE1"))
		{
			PlaySE(SE.GET_MONEY);
		}
		if(GUILayout.Button("PLAY SE2"))
		{
			PlaySE(SE.SET_X);
		}
		if(GUILayout.Button("PLAY SE3"))
		{
			PlaySE(SE.TIMEUP);
		}
	}
	//*/
}
