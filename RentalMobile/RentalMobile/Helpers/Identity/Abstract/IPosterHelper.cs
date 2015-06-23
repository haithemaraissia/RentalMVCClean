using System;

namespace RentalMobile.Helpers.Identity.Abstract
{
    public interface IPosterHelper
    {
        PosterAttributes GetPoster(int uniId, Uri requestUri);
        PosterAttributes GetSendtoFriendPoster(Uri requestUri);
        PosterAttributes GetCommentPoster(Uri requestUri);
    }
}
