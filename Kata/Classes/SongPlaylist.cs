namespace Kata.Classes
{
    internal class SongPlaylist
    {
        public class Song
        {
            private string name;

            public Song NextSong { get; set; }

            public Song(string name)
            {
                this.name = name;
            }

            public bool IsRepeatingPlaylist()
            {
                var song = this;
                var next = NextSong;

                while (song != null && next != null)
                {
                    if (ReferenceEquals(song, next))
                    {
                        return true;
                    }

                    song = song.NextSong;
                    next = next.NextSong?.NextSong;
                }

                return false;
            }
        }
    }
}