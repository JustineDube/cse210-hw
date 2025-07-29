using System;
using System.Collections.Generic;

namespace YouTubeVideos
{
    // Comment class encapsulates a commenter's name and their comment text
    public class Comment
    {
        public string CommenterName { get; set; }
        public string Text { get; set; }

        public Comment(string commenterName, string text)
        {
            CommenterName = commenterName;
            Text = text;
        }
    }

    // Video class encapsulates title, author, length, and a list of comments
    public class Video
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int LengthInSeconds { get; set; }
        private List<Comment> Comments { get; set; } = new List<Comment>();

        public Video(string title, string author, int lengthInSeconds)
        {
            Title = title;
            Author = author;
            LengthInSeconds = lengthInSeconds;
        }

        // Method to add a comment to the video
        public void AddComment(Comment comment)
        {
            Comments.Add(comment);
        }

        // Method to return the number of comments on this video
        public int GetNumberOfComments()
        {
            return Comments.Count;
        }

        // Method to get all comments (for display purposes)
        public List<Comment> GetComments()
        {
            return Comments;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create some videos
            Video video1 = new Video("Learn C# in 10 Minutes", "John Doe", 600);
            Video video2 = new Video("Top 5 Programming Tips", "Jane Smith", 900);
            Video video3 = new Video("How to Cook Pasta Perfectly", "Chef Mike", 480);
            Video video4 = new Video("Best Travel Destinations 2025", "Travel Guru", 1200);

            // Add comments to video1
            video1.AddComment(new Comment("Alice", "Great tutorial, very clear!"));
            video1.AddComment(new Comment("Bob", "Thanks for the quick overview."));
            video1.AddComment(new Comment("Charlie", "I learned a lot!"));

            // Add comments to video2
            video2.AddComment(new Comment("Diana", "Awesome tips, very helpful."));
            video2.AddComment(new Comment("Ethan", "Can you do one on debugging?"));
            video2.AddComment(new Comment("Fiona", "Loved the examples."));

            // Add comments to video3
            video3.AddComment(new Comment("George", "Yummy, I want to try this."));
            video3.AddComment(new Comment("Hannah", "Pasta always turns out great after this video."));
            video3.AddComment(new Comment("Ian", "Very useful cooking tips."));

            // Add comments to video4
            video4.AddComment(new Comment("Jack", "Adding these places to my bucket list!"));
            video4.AddComment(new Comment("Karen", "Nice video, very informative."));
            video4.AddComment(new Comment("Liam", "Can't wait to travel again."));

            // Put videos into a list
            List<Video> videos = new List<Video>() { video1, video2, video3, video4 };

            // Display information for each video
            foreach (var video in videos)
            {
                Console.WriteLine($"Title: {video.Title}");
                Console.WriteLine($"Author: {video.Author}");
                Console.WriteLine($"Length (seconds): {video.LengthInSeconds}");
                Console.WriteLine($"Number of comments: {video.GetNumberOfComments()}");
                Console.WriteLine("Comments:");

                foreach (var comment in video.GetComments())
                {
                    Console.WriteLine($"- {comment.CommenterName}: {comment.Text}");
                }

                Console.WriteLine(new string('-', 40)); // separator line
            }
        }
    }
}

