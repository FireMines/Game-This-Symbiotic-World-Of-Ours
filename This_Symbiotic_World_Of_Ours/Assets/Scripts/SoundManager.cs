using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundManager : MonoBehaviour
{
	[Header("Sound settings")]
	// Audio players components.
	public AudioSource EffectsSource;
	public AudioSource MusicSource;
	// Random pitch adjustment range.
	public float LowPitchRange = .95f;
	public float HighPitchRange = 1.05f;
	// Singleton instance.
	public static SoundManager Instance = null;
	[SerializeField] private SliderJoint2D volumeSlider = null;

	// Initialize the singleton instance.
	private void Awake()
	{
		// If there is not already an instance of SoundManager, set it to this.
		if (Instance == null)
		{
			Instance = this;
		}
		//If an instance already exists, destroy whatever this object is to enforce the singleton.
		else if (Instance != this)
		{
			Destroy(gameObject);
		}
		//Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
		DontDestroyOnLoad(gameObject);
	}


	/// <summary>
	/// Play a single clip through the sound effects source.
	/// </summary>
	/// <param name="clip">Sound effect clip to be played</param>
	public void Play(AudioClip clip)
	{
		EffectsSource.clip = clip;
		EffectsSource.Play();
	}


	/// <summary>
	/// Play a single clip through the music source.
	/// </summary>
	/// <param name="clip">Music clip to be played</param>
	public void PlayMusic(AudioClip clip)
	{
		MusicSource.clip = clip;
		MusicSource.Play();
	}


	/// <summary>
	/// Play a random clip from an array, and randomize the pitch slightly.
	/// </summary>
	/// <param name="clips">Array of audio clips to be randomly played</param>
	public void RandomSoundEffect(params AudioClip[] clips)
	{
		int randomIndex = Random.Range(0, clips.Length);
		float randomPitch = Random.Range(LowPitchRange, HighPitchRange);
		EffectsSource.pitch = randomPitch;
		EffectsSource.clip = clips[randomIndex];
		EffectsSource.Play();
	}


	/// <summary>
	/// Changes the volume of the game based on slider
	/// </summary>
	/// <param name="newVolume">Slider volume</param>
	public void changeVolume(float newVolume)
	{
		PlayerPrefs.SetFloat("volume", newVolume);
		AudioListener.volume = PlayerPrefs.GetFloat("volume");
	}
}