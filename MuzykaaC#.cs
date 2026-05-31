using System;
using System.Collections.Generic;

namespace SystemMuzyczny
{
    public class Track
    {
        public string Title;
        public string Artist;

        public Track(string title, string artist)
        {
            Title = title;
            Artist = artist;
        }
    }

    public class Playlist
    {
        public string Name;
        public List<Track> Tracks = new List<Track>();

        public Playlist(string name)
        {
            Name = name;
        }

        public void AddTrack(Track track)
        {
            Tracks.Add(track);
        }

        public void RemoveTrack(string title)
        {
            for (int i = 0; i < Tracks.Count; i++)
            {
                if (Tracks[i].Title == title)
                {
                    Tracks.RemoveAt(i);
                    break;
                }
            }
        }

        public void Play()
        {
            Console.WriteLine("Odtwarzanie playlisty: " + Name);
            for (int i = 0; i < Tracks.Count; i++)
            {
                Console.WriteLine("-> Grane teraz: " + Tracks[i].Title + " - " + Tracks[i].Artist);
            }
        }
    }

    public class User
    {
        public string Username;
        public List<Playlist> Playlists = new List<Playlist>();

        public User(string username)
        {
            Username = username;
        }

        public Playlist CreatePlaylist(string name)
        {
            Playlist nowa = new Playlist(name);
            Playlists.Add(nowa);
            return nowa;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            User user = new User("Kuba");

            Track piosenka1 = new Track("Bohemian Rhapsody", "Queen");
            Track piosenka2 = new Track("Smooth Criminal", "Michael Jackson");

            Playlist mojaLista = user.CreatePlaylist("Moje Hity");

            mojaLista.AddTrack(piosenka1);
            mojaLista.AddTrack(piosenka2);

            mojaLista.Play();

            mojaLista.RemoveTrack("Smooth Criminal");

            mojaLista.Play();

            Console.ReadLine();
        }
    }
}