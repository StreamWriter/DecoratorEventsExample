using System;

namespace DecoratorEvents
{
    public class Program
    {
        public static void LogOperation(object sender, DatabaseOperationEventArgs e)
        {
            Console.WriteLine($"[DB] {e.OperationName} {e.EntityType} with id {e.AffectedEntityId}.");
        }

        public static void Main(string[] args)
        {
            IRepository<Song> songs = new Repository<Song>();
            songs = new RepositoryDecorator<Song>(songs);

            (songs as RepositoryDecorator<Song>).DatabaseOperation += LogOperation;

            songs.Add(new Song() { Id = 1, Artist = "Drake", Title = "Elevate" });
            songs.Add(new Song() { Id = 2, Artist = "Sicko Mode", Title = "Travis Scott" });

            var s = songs.Get(1);

            Console.Read();
        }

    }
}
