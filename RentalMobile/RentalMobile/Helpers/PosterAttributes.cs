namespace RentalMobile.Helpers
{
    public class PosterAttributes
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfileLink { get; set; }
        public string ProfilePicturePath { get; set; }
        public string EmailAddress { get; set; }
        public string Role { get; set; }
        public int PosterId { get; set; }

        public PosterAttributes(string f, string l, string pl, string pp, string e, string r, int pid)
        {
            FirstName = f;
            LastName = l;
            ProfileLink = pl;
            ProfilePicturePath = pp;
            EmailAddress = e;
            Role = r;
            PosterId = pid;
        }
    }
}