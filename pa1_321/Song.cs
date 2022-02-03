using System;
using System.IO;
using System.Collections.Generic;

namespace pa1_321
{
    public class Song
    {
        public int Id {get; set;}
        public DateTime timePosted {get; set;}
        public string song {get; set;}
        public int count {get; set;}

        public int CompareTo(Song temp)
        {
            return this.timePosted.CompareTo(temp.timePosted);
        }

        public static List<Song> GetAllSongs()
        {
            List<Song> alsSongs = new List<Song>();
            StreamReader inFile = null;
            try
            {
                inFile = new StreamReader("songs.txt");
            }
            catch
            {
                System.Console.WriteLine("The song you attempted to retrieve does not exist");
            }
            string line = inFile.ReadLine();
            while (line != null)
            {
                string[] temp = line.Split('#');
                int id = int.Parse(temp[0]);
                DateTime timePosted = DateTime.Parse(temp[2]);
                alsSongs.Add(new Song() {Id = id, song = temp[1], timePosted = timePosted});
                line = inFile.ReadLine();
            }
            inFile.Close();
            return alsSongs;
        }

        public override string ToString()
        {
            return " Song Id: " + this.Id + " Song title: " + this.song + " Date added: " + timePosted;
        }
        
    }
}