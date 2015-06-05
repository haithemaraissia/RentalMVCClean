namespace RentalMobile.Helpers.Identity.Abstract
{
    public interface IPosterHelper
    {
        PosterAttributes GetPoster(int uniId);
        PosterAttributes GetSendtoFriendPoster();
        PosterAttributes GetCommentPoster();
    }
}
