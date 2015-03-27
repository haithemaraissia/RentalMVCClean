namespace RentalMobile.Helpers.Identity.Abstract
{
    public interface IPosterHelper
    {
        PosterAttributes GetPoster(int uniId);
        string GetCurrencyValue(int? currencyId);
        PosterAttributes GetSendtoFriendPoster();
        PosterAttributes GetCommentPoster();
    }
}
