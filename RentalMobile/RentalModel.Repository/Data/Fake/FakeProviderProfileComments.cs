using System;
using System.Collections.Generic;
using RentalMobile.Model.Models;
using RentalMobile.Model.ModelViews;

namespace RentalModel.Repository.Data.Fake
{
    public class FakeProviderProfileComments
    { 
       public List<ProviderProfileComment> MyProviderProfileComments;

       public FakeProviderProfileComments()
        {
            InitializeProviderProfileCommentList();
        }

       public void InitializeProviderProfileCommentList()
        {
            MyProviderProfileComments = new List<ProviderProfileComment> {
                FirstProviderProfileComment(), 
                SecondProviderProfileComment(),
                ThirdProviderProfileComment()
            };
        }

       public ProviderProfileComment FirstProviderProfileComment()
        {

            var firstProviderProfileComment = new ProviderProfileComment {

                 CommentId = new Int32()
,
                 ProviderId = new Int32(),
                 PosterId = new Int32(),
                 PosterRole = new Int32(),
                 PosterName = null,
                 PosterPhotoPath = null,
                 Comment = null,
                 CommentDate = new DateTime(),
                 PosterProfileLink = null
    
 };

            return firstProviderProfileComment;
        }

       public ProviderProfileComment SecondProviderProfileComment()
        {

            var secondProviderProfileComment = new ProviderProfileComment {

                 CommentId = new Int32()
,
                 ProviderId = new Int32(),
                 PosterId = new Int32(),
                 PosterRole = new Int32(),
                 PosterName = null,
                 PosterPhotoPath = null,
                 Comment = null,
                 CommentDate = new DateTime(),
                 PosterProfileLink = null
        
 };

            return secondProviderProfileComment;
        }

       public ProviderProfileComment ThirdProviderProfileComment()
        {

            var thirdProviderProfileComment = new ProviderProfileComment {

                 CommentId = new Int32()
,
                 ProviderId = new Int32(),
                 PosterId = new Int32(),
                 PosterRole = new Int32(),
                 PosterName = null,
                 PosterPhotoPath = null,
                 Comment = null,
                 CommentDate = new DateTime(),
                 PosterProfileLink = null
 
 };

            return thirdProviderProfileComment;
        }

        ~FakeProviderProfileComments()
        {
            MyProviderProfileComments = null;
        }
    }
}


    