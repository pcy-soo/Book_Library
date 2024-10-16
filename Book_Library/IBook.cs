using System;
namespace Book_Library
{
    interface IBook
    {
        bool IsBorrowed { get; set; }

        void MarkAsBorrowed();
        void MarkAsReturned();
        string GetLocation();
    }

    public class Ebook : IBook
    {
        public Ebook(string? booktitle)
        {
            Booktitle = booktitle;
            Location = "Web";
        }

        public bool IsBorrowed
        {
            get; set;
        }
        public string Location
        {
            get; set;
        }
        public string Booktitle
        {
            get; set;
        }

        public void MarkAsBorrowed()
        {
            IsBorrowed = true;
            Location = "Client";
        }

        public void MarkAsReturned()
        {
            IsBorrowed = false;
            Location = "Web";
        }

        public string GetLocation()
        {
            return Location;
        }

    }
    public class HardCover : IBook
    {
        public HardCover(string? booktitle)
        {
            Booktitle = booktitle;
            Location = "Library";
        }

        public bool IsBorrowed
        {
            get; set;
        }
        public string Location
        {
            get; set;
        }
        public string Booktitle
        {
            get;set;
        }

        public void MarkAsBorrowed()
        {
            IsBorrowed = true;
            Location = "Client";
        }

        public void MarkAsReturned()
        {
            IsBorrowed = false;
            Location = "Library";
        }

        public string GetLocation()
        {
            return Location;
        }
    }
    public class Audiobook : IBook
    {
        public Audiobook(string? booktitle)
        {
            Booktitle = booktitle;
            Location = "Web";
        }

        public bool IsBorrowed
        {
            get; set;
        }
        public string Location
        {
            get; set;
        }
        public string Booktitle
        {
            get;set;
        }

        public void MarkAsBorrowed()
        {
            IsBorrowed = true;
            Location = "Client";
        }

        public void MarkAsReturned()
        {
            IsBorrowed = false;
            Location = "Web";
        }

        public string GetLocation()
        {
            return Location;
        }

    }
}

