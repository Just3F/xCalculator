using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Common
{
    public class AudioManager : MonoBehaviour
    {
        public List<Sound> sounds;

        public static AudioManager instance;

        void Awake ()
        {
            if (instance == null)
                instance = this;
            else
            {
                Destroy(gameObject);
                return;
            }
            DontDestroyOnLoad(gameObject);

            sounds.ForEach(s =>
            {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;

                s.source.volume = s.volume;
                s.source.pitch = s.pitch;
            });
        }

        public void Play(string name)
        {
            var s = sounds.FirstOrDefault(x => x.Name == name);
            if (s == null)
            {
                Debug.LogWarning("Sound: " + name + "not found!");
                return;
            }
            s.source.Play();
        }
    }
}
