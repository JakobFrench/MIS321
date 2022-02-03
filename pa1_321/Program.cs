using System;
using System.IO;
using System.Collections.Generic;

namespace pa1_321
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            List<Song> alsSongs = Song.GetAllSongs();
            alsSongs.Sort();
            Menu(alsSongs);
        }

        static void Menu(List<Song> alsSongs)
        {
            System.Console.WriteLine("Enter:\n1 to show all of Big Als songs\n2 to add a song\n3 to delete a song\n4 to exit");
            int userInput = int.Parse(Console.ReadLine());
            if (userInput < 1 || userInput > 4)
            {
                System.Console.WriteLine("Invalid selection. Please pick again");
                Menu(alsSongs);
            }
            else if (userInput == 1)
            {
                showAllSongs(alsSongs);
            }
            else if (userInput == 2)
            {
                addSong(alsSongs);
            }
            else if (userInput == 3)
            {
                deleteSong(alsSongs);
            }
            else if (userInput == 4)
            {
                Environment.Exit(0);
            }
        }

        static void showAllSongs(List<Song> alsSongs)
        {
            foreach (Song playlist in alsSongs)
            {
                System.Console.WriteLine(playlist.ToString());
            }
            Menu(alsSongs);
        }

        static void addSong(List<Song> alsSongs)
        {

            System.Console.WriteLine("Enter the song ID (must me a number 1-100)");
            int songID = int.Parse(Console.ReadLine());
            //if (songID == )//ask for previous id
            //{
            //     //do not add to list
            // set count++ to id (don't ask for it)
            //} need count!!!!!! 
            System.Console.WriteLine("Enter the song name you'd like to add");
            string addedSong = Console.ReadLine();
            DateTime day = DateTime.Today;
            Song newSong = new Song() {Id = songID, song = addedSong,timePosted = DateTime.Today};
            alsSongs.Add(newSong);
            StreamWriter outFile = new StreamWriter("songs.txt");

            foreach(Song var in alsSongs)
            {
                outFile.WriteLine($"{var.Id}#{var.song}#{var.timePosted}");
            }
            outFile.Close();
            System.Console.WriteLine("Enter\n1 to add another song\n2 Return to menu");
            int userInput = int.Parse(Console.ReadLine());
            if (userInput < 1 || userInput > 2)
            {
                System.Console.WriteLine("Invalid selection.");
                Menu(alsSongs);
            }
            else if (userInput == 1)
            {
                addSong(alsSongs);
            }
            else if (userInput == 2)
            {
                Menu(alsSongs);
            }
        }

        static void deleteSong(List<Song> alsSongs)
        {
            System.Console.WriteLine("Enter the ID of the song in which you would like to delete");
            int userInput = int.Parse(Console.ReadLine());

            foreach(Song song in alsSongs)
            {
                alsSongs.Remove(song);
                StreamWriter outFile = new StreamWriter("songs.txt");
                foreach (Song var in alsSongs)
                {
                    outFile.WriteLine($"{var.Id}#{var.song}#{var.timePosted}");
                }
                outFile.Close();
                System.Console.WriteLine("The song has been deleted.\nEnter\n1 to delete another song\n2 Return to menu");
                userInput = int.Parse(Console.ReadLine());
                if (userInput < 1 || userInput > 2)
                {
                    System.Console.WriteLine("Invalid selection.");
                    Menu(alsSongs);
                }
                else if (userInput == 1)
                {
                    deleteSong(alsSongs);
                }
                else if (userInput == 2)
                {
                    Menu(alsSongs);
                }
            }
        }
    }
}